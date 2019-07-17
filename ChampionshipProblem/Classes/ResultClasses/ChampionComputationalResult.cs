namespace ChampionshipProblem.Classes.ResultClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// Die Klasse repräsentiert das Ergebnis des Algorithmus, ob ein Verein noch Meister werden kann.
    /// </summary>
    public class ChampionComputationalResult : IComputationalResult
    {
        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des ChampionComputationalResult.
        /// </summary>
        public ChampionComputationalResult()
        {
            this.ComputationalStanding = new List<LeagueStandingEntry>();
            this.MissingRemainingMatches = new List<RemainingMatch>();
        }
        #endregion

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

        #region MissingRemainingMatches
        /// <summary>
        /// Die Liste der fehlenden Spiele mit den Ergebnissen.
        /// </summary>
        public List<RemainingMatch> MissingRemainingMatches { get; set; }
        #endregion

        #region NeededGoalDifference
        /// <summary>
        /// Die benötigte Tordifferenz.
        /// </summary>
        public int? NeededGoalDifference { get; set; }
        #endregion
    }
}
