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
        public ChampionshipViewModel ChampionshipViewModel { get; set; }

        public LeagueService(ChampionshipViewModel championshipViewModel)
        {
            ChampionshipViewModel = championshipViewModel;
        }

        public League GetLeague(long leagueId)
        {
            return ChampionshipViewModel.Leagues.Single((league) => league.id == leagueId);
        }

        public League GetLeagueByName(string name)
        {
            return ChampionshipViewModel.Leagues.Single((league) => league.name == name);
        }

        public IEnumerable<League> GetLeagues()
        {
            return ChampionshipViewModel.Leagues;
        }
    }
}
