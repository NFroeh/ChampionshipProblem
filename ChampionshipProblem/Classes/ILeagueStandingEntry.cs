namespace ChampionshipProblem.Classes
{
    /// <summary>
    /// Das Interface des LeagueStandingEntries. 
    /// </summary>
    public interface ILeagueStandingEntry
    {
        /// <summary>
        /// Die TeamId.
        /// </summary>
        int TeamId { get; set; }

        /// <summary>
        /// Der Langname.
        /// </summary>
        string Name { get; set; }

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
