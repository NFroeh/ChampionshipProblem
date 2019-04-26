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

        public LeagueService(EuropeanSoccerEntities soccerDb)
        {
            SoccerDb = soccerDb;
        }

        public League GetLeague(long leagueId)
        {
            return SoccerDb.Leagues.Single((league) => league.id == leagueId);
        }

        public League GetLeagueByName(string name)
        {
            return SoccerDb.Leagues.Single((league) => league.name == name);
        }

        public IEnumerable<League> GetLeagues()
        {
            return SoccerDb.Leagues;
        }
    }
}
