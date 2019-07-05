namespace ChampionshipProblem
{
    using ChampionshipProblem.Scheme;
    using ChampionshipProblem.Services;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionshipViewModel
    {
        #region fields
        /// <summary>
        /// Die Ligen.
        /// </summary>
        public List<League> Leagues { get; }

        /// <summary>
        /// Die Spiele.
        /// </summary>
        public List<Match> Matches { get; }
        
        /// <summary>
        /// Die Mannschaften.
        /// </summary>
        public List<Team> Teams { get; }

        /// <summary>
        /// Die Ligenservice.
        /// </summary>
        public LeagueService LeagueService { get; }

        /// <summary>
        /// Der Tabellenservice.
        /// </summary>
        public LeagueStandingService LeagueStandingService { get; set; }

        /// <summary>
        /// Der Spielservice.
        /// </summary>
        public MatchService MatchService { get; }

        /// <summary>
        /// Der Mannschaftsservice.
        /// </summary>
        public TeamService TeamService { get;  }
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Models.
        /// </summary>
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
        #endregion

        #region SetLeagueAndSeason
        /// <summary>
        /// Methode zum Setzen des LeagueStandingServices.
        /// </summary>
        /// <param name="leagueName">Der Liganame.</param>
        /// <param name="season">Die Saison.</param>
        public void SetLeagueAndSeason(string leagueName, string season)
        {
            this.LeagueStandingService = new LeagueStandingService(this, leagueName, season);
        }
        #endregion
    }
}
