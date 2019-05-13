using ChampionshipProblem.Scheme;
using System.Collections.Generic;
using System.Linq;

namespace ChampionshipProblem.Services
{
    /// <summary>
    /// Klasse repräsentiert den Service für die Ligen.
    /// </summary>
    public class LeagueService
    {
        #region fields
        /// <summary>
        /// Die Datengrundlage.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel { get; set; }
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Services.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage.</param>
        public LeagueService(ChampionshipViewModel championshipViewModel)
        {
            ChampionshipViewModel = championshipViewModel;
        }
        #endregion

        #region GetLeague
        /// <summary>
        /// Methode zum Ermitteln einer Liga.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <returns>Die Liga.</returns>
        public League GetLeague(long leagueId)
        {
            return ChampionshipViewModel.Leagues.Single((league) => league.id == leagueId);
        }
        #endregion

        #region GetLeagueByName
        /// <summary>
        /// Methode zum Ermitteln der Liga anhand des Namens.
        /// </summary>
        /// <param name="name">Der Name.</param>
        /// <returns>Die Liga.</returns>
        public League GetLeagueByName(string name)
        {
            return ChampionshipViewModel.Leagues.Single((league) => league.name == name);
        }
        #endregion

        #region GetLeagues
        /// <summary>
        /// Methode zum Ermitteln aller Ligen.
        /// </summary>
        /// <returns>Die Ligen.</returns>
        public List<League> GetLeagues()
        {
            return ChampionshipViewModel.Leagues;
        }
        #endregion
    }
}
