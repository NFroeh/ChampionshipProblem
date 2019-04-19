using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem.Services
{
    public class LeagueService
    {
        EuropeanSoccerEntities SoccerDb { get; set; }

        public LeagueService()
        {
            SoccerDb = new EuropeanSoccerEntities();
        }

        public LeagueService(EuropeanSoccerEntities soccerDb)
        {
            SoccerDb = soccerDb;
        }

        public List<LeagueStandingEntry> CalculateStandingForLeague(string leagueName, string season, int stage)
        {
            League league = this.GetLeagueByName(leagueName);
            return this.CalculateStandingForLeague(league.id, season, stage);
        }

        public List<LeagueStandingEntry> CalculateStandingForLeague(long leagueId, string season, int stage)
        {
            // Entitäten und Services erzeugen
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();
            MatchService matchService = new MatchService(SoccerDb);
            TeamService teamService = new TeamService(SoccerDb);

            // Die Liga ermitteln
            League currentLeague = this.GetLeague(leagueId);

            // Die Vereine der Liga ermitteln
            IEnumerable<Team> teamsByLeague = teamService.GetTeamsByLeagueAndSeason(leagueId, season);

            // Für jedes Team einen Eintrag anlegen
            foreach(Team team in teamsByLeague)
            {
                LeagueStandingEntry entry = new LeagueStandingEntry((int) team.id, team.team_api_id, team.team_short_name, team.team_long_name);
                leagueStandings.Add(entry);
            }

            // Die Spiele ermitteln
            IEnumerable<Match> matchesTilStage = matchService.GetMatchesUntilStage(leagueId, season, stage);

            // Die Spiele durchlaufen und werten
            foreach (Match match in matchesTilStage)
            {
                LeagueStandingEntry home = leagueStandings.Single((entry) => entry.TeamApiId == match.home_team_api_id);
                LeagueStandingEntry away = leagueStandings.Single((entry) => entry.TeamApiId == match.away_team_api_id);

                if (match.home_team_goal > match.away_team_goal)
                {
                    home.Points += 3;
                }
                else if (match.home_team_goal < match.away_team_goal)
                {
                    away.Points += 3;
                }
                else
                {
                    home.Points += 1;
                    away.Points += 1;
                }

                home.Goals += (int) match.home_team_goal.Value;
                home.GoalsConceded += (int)match.away_team_goal.Value;
                away.Goals += (int)match.away_team_goal.Value;
                away.GoalsConceded += (int)match.home_team_goal.Value;
            }

            leagueStandings = leagueStandings
                .OrderByDescending((entry) => entry.Points)
                .ThenByDescending((entry) => entry.Goals - entry.GoalsConceded)
                .ThenByDescending((entry) => entry.Goals)
                .ToList();
            return leagueStandings;
        }

        public League GetLeague(long leagueId)
        {
            return SoccerDb.Leagues.Single((league) => league.id == leagueId);
        }

        public League GetLeagueByName(string name)
        {
            return SoccerDb.Leagues.Single((league) => league.name == name);
        }
    }
}
