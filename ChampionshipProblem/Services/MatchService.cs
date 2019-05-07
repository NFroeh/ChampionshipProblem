using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem.Services
{
    public class MatchService
    {
        EuropeanSoccerEntities SoccerDb { get; set; }

        public MatchService(EuropeanSoccerEntities soccerDb)
        {
            SoccerDb = soccerDb;
        }

        public IEnumerable<Match> GetMatchesUntilStage(long leagueId, string season, int stage)
        {
            return SoccerDb.Matches.Where((match) => match.league_id == leagueId && match.season == season && match.stage <= stage);
        }

        public IEnumerable<Match> GetMatchesByLeagueAndSeason(long leagueId, string season)
        {
            return SoccerDb.Matches.Where((match) => match.league_id == leagueId && match.season == season);
        }

        public List<RemainingMatch> GetRemainingMatches(string leagueName, string season, int stage)
        {
            return this.GetRemainingMatches(new LeagueService(this.SoccerDb).GetLeagueByName(leagueName).id, season, stage);
        }

        public List<RemainingMatch> GetRemainingMatches(long leagueId, string season, int stage)
        {
            // Services erzeugen
            TeamService teamService = new TeamService(this.SoccerDb);

            IEnumerable<Match> matchesToConvert = SoccerDb.Matches.Where((match) => match.league_id == leagueId && match.season == season && match.stage > stage);

            List<RemainingMatch> remainingMatches = new List<RemainingMatch>();
            IEnumerable<Team> teams = teamService.GetTeamsByLeagueAndSeason(leagueId, season);
            Dictionary<long, string> teamNameToId = teamService.GetIdNameCollectionByLeagueAndSeason(leagueId, season);

            foreach (Match match in matchesToConvert)
            {
                RemainingMatch remainingMatch = new RemainingMatch()
                {
                    Id = match.id,
                    MatchApiId = match.match_api_id.Value,
                    CountryId = match.country_id.Value,
                    LeagueId = match.league_id.Value,
                    Season = match.season,
                    Stage = match.stage.Value,
                    Date = match.date,
                    AwayTeamApiId = match.away_team_api_id.Value,
                    AwayTeamGoal = match.away_team_goal.Value,
                    HomeTeamName = teamNameToId[match.home_team_api_id.Value],
                    AwayTeamName = teamNameToId[match.away_team_api_id.Value],
                    HomeTeamApiId = match.home_team_api_id.Value,
                    HomeTeamGoal = match.home_team_goal.Value,
                };
                remainingMatches.Add(remainingMatch);
            }

            return remainingMatches;
        }

        public List<RemainingMatch> GetRemainingMatchesForSingleStage(long leagueId, string season, int stage)
        {
            // Services erzeugen
            TeamService teamService = new TeamService(this.SoccerDb);

            IEnumerable<Match> matchesToConvert = SoccerDb.Matches.Where((match) => match.league_id == leagueId && match.season == season && match.stage == stage);

            List<RemainingMatch> remainingMatches = new List<RemainingMatch>();
            IEnumerable<Team> teams = teamService.GetTeamsByLeagueAndSeason(leagueId, season);
            Dictionary<long, string> teamNameToId = teamService.GetIdNameCollectionByLeagueAndSeason(leagueId, season);

            foreach (Match match in matchesToConvert)
            {
                RemainingMatch remainingMatch = new RemainingMatch()
                {
                    Id = match.id,
                    MatchApiId = match.match_api_id.Value,
                    CountryId = match.country_id.Value,
                    LeagueId = match.league_id.Value,
                    Season = match.season,
                    Stage = match.stage.Value,
                    Date = match.date,
                    AwayTeamApiId = match.away_team_api_id.Value,
                    AwayTeamGoal = match.away_team_goal.Value,
                    HomeTeamName = teamNameToId[match.home_team_api_id.Value],
                    AwayTeamName = teamNameToId[match.away_team_api_id.Value],
                    HomeTeamApiId = match.home_team_api_id.Value,
                    HomeTeamGoal = match.home_team_goal.Value,
                };
                remainingMatches.Add(remainingMatch);
            }

            return remainingMatches;
        }

        public long GetNumberOfMatches(long leagueId)
        {
            return SoccerDb.Matches.Where((match) => match.league_id == leagueId).Max((match) => match.stage).Value;
        }

        public IEnumerable<string> GetSeasonsByLeagueId(long leagueId)
        {
            return SoccerDb.Matches.Where((match) => match.league_id == leagueId).Select((match) => match.season).Distinct();
        }
    }
}
