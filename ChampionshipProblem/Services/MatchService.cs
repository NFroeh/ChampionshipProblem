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

        public MatchService()
        {
            SoccerDb = new EuropeanSoccerEntities();
        }

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
    }
}
