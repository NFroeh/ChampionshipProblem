using System.Collections.Generic;

namespace ChampionshipProblem.Classes.ResultClasses
{
    /// <summary>
    /// Interface für das Ergebnis eines Algorithmus.
    /// </summary>
    public interface IComputationalResult
    {
        /// <summary>
        /// Die Tabelle, welche aus der Berechnung resultiert.
        /// </summary>
        List<LeagueStandingEntry> ComputationalStanding { get; set; }

        /// <summary>
        /// Die benötigte Tordifferenz.
        /// </summary>
        int? NeededGoalDifference { get; set; }
    }
}
