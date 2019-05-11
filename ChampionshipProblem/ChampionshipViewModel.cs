using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem
{
    public class ChampionshipViewModel
    {
        public List<League> Leagues { get; }

        public List<Match> Matches { get; }
        
        public List<Team> Teams { get; }

        public LeagueService LeagueService { get; }

        public LeagueStandingService LeagueStandingService { get; set; }

        public MatchService MatchService { get; }

        public TeamService TeamService { get;  }

        public ChampionshipViewModel()
        {
            using (EuropeanSoccerEntities soccerDb = new EuropeanSoccerEntities())
            {
                this.Leagues = soccerDb.Leagues.ToList();
                this.Matches = soccerDb.Matches.ToList();
                this.Teams = soccerDb.Teams.ToList();
            }

            this.LeagueService = new LeagueService(this);
            this.MatchService = new MatchService(this);
            this.TeamService = new TeamService(this);
        }

        public void SetLeagueAndSeason(string leagueName, string season)
        {
            this.LeagueStandingService = new LeagueStandingService(this, leagueName, season);
        }
    }
}
