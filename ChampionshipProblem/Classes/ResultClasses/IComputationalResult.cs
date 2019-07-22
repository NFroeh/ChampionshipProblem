namespace ChampionshipProblem.Classes.ResultClasses
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface für das Ergebnis eines Algorithmus.
    /// </summary>
    public interface IComputationalResult
    {
        /// <summary>
        /// Die Tabelle, welche aus der Berechnung resultiert.
        /// </summary>
        List<LeagueStandingEntry> ComputationalStanding { get; }

        /// <summary>
        /// Die benötigte Tordifferenz.
        /// </summary>
        int? NeededGoalDifference { get; }
    }
}
