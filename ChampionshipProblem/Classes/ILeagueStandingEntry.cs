namespace ChampionshipProblem.Classes
{
    /// <summary>
    /// Das Interface des LeagueStandingEntries. 
    /// </summary>
    public interface ILeagueStandingEntry
    {
        /// <summary>
        /// Die TeamApiId.
        /// </summary>
        long? TeamApiId { get; set; }

        /// <summary>
        /// Der Kurzname.
        /// </summary>
        string TeamShortName { get; set; }

        /// <summary>
        /// Der Langname.
        /// </summary>
        string TeamLongName { get; set; }

        /// <summary>
        /// Die Anzahl der Spiele.
        /// </summary>
        int Games { get; set; }

        /// <summary>
        /// Die Anzahl der Punkte.
        /// </summary>
        int Points { get; set; }

        /// <summary>
        /// Die Anzahl der Tore.
        /// </summary>
        int Goals { get; set; }

        /// <summary>
        /// Die Anzahl der gefangenen Tore.
        /// </summary>
        int GoalsConceded { get; set; }
    }
}
