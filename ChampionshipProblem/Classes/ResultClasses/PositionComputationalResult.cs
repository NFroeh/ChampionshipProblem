namespace ChampionshipProblem.Classes.ResultClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// Die Klasse repräsentiert das Ergebnis des Algorithmus, wenn die Mannschaft eine bestmöglche/schlechtmögliche Position erreichen muss.
    /// </summary>
    public class PositionComputationalResult : IComputationalResult
    {
        #region Position
        /// <summary>
        /// Die Position.
        /// </summary>
        public int Position { get; set; }
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
