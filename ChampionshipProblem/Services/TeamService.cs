using ChampionshipProblem.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem.Services
{
    public class TeamService
    {
        public ChampionshipViewModel ChampionshipViewModel { get; set; }

        public TeamService(ChampionshipViewModel championshipViewModel)
        {
            ChampionshipViewModel = championshipViewModel;
        }

        public IEnumerable<Team> GetTeamsByLeagueAndSeason(long leagueId, string season)
        {
            IEnumerable<Match> matches = ChampionshipViewModel.MatchService.GetMatchesByLeagueAndSeason(leagueId, season);
            List<Team> teams = new List<Team>();
            foreach(Match match in matches)
            {
                Team homeTeam = this.GetTeamById(match.home_team_api_id);
                Team awayTeam = this.GetTeamById(match.away_team_api_id);

                if (!teams.Contains(homeTeam)) teams.Add(homeTeam);
                if (!teams.Contains(awayTeam)) teams.Add(awayTeam);
            }

            return teams;
        }

        public int GetNumberOfTeamsByLeagueAndSeason(long leagueId, string season)
        {
            return this.GetTeamsByLeagueAndSeason(leagueId, season).Count();
        }

        public Team GetTeamById(long? teamApiId)
        {
            return ChampionshipViewModel.Teams.Single((team) => team.team_api_id == teamApiId);
        }

        public Dictionary<long, string> GetIdNameCollectionByLeagueAndSeason(long leagueId, string season)
        {
            IEnumerable<Team> teams = this.GetTeamsByLeagueAndSeason(leagueId, season);
            Dictionary<long, string> idNameCollection = new Dictionary<long, string>();

            foreach(Team team in teams)
            {
                idNameCollection.Add(team.team_api_id.Value, team.team_long_name);
            }

            return idNameCollection;
        }
    }
}
