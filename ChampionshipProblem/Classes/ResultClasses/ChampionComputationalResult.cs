namespace ChampionshipProblem.Classes.ResultClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// Die Klasse repräsentiert das Ergebnis des Algorithmus, ob ein Verein noch Meister werden kann.
    /// </summary>
    public class ChampionComputationalResult : IComputationalResult
    {
        #region CanWinChampionship
        /// <summary>
        /// Ob der Verein die Meisterschaft gewinnen kann.
        /// </summary>
        public bool CanWinChampionship { get; set; }
        #endregion

        #region ComputationalStanding
        /// <summary>
        /// Die Tabelle, welche aus der Berechnung resultiert.
        /// </summary>
        public List<LeagueStandingEntry> ComputationalStanding { get; set; }
        #endregion

        #region NeededGoalDifference
        /// <summary>
        /// Die benötigte Tordifferenz.
        /// </summary>
        public int? NeededGoalDifference { get; set; }
        #endregion
    }
}
