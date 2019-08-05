namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes.WorldCup;
    using System.Linq;

    /// <summary>
    /// Klasse für die WorldCup-Methoden.
    /// </summary>
    public partial class LeagueService
    {
        #region GetWorldCup
        /// <summary>
        /// Methode zum Ermitteln einer Liga.
        /// </summary>
        /// <param name="worldCupId">Die Liganummer.</param>
        /// <returns>Die Liga.</returns>
        public WorldCup GetWorldCup(int worldCupId)
        {
            return ChampionshipViewModel.WorldCups.Single((worldCup) => worldCup.Id == worldCupId);
        }
        #endregion
    }
}
