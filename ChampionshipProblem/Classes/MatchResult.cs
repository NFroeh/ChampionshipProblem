namespace ChampionshipProblem.Classes
{
    /// <summary>
    /// Die Aufzählung für ein Spielergebnis.
    /// </summary>
    public enum MatchResult : byte
    {
        /// <summary>
        /// Unentschieden.
        /// </summary>
        Tie = 0,

        /// <summary>
        /// Sieg Heimmannschaft.
        /// </summary>
        WinHome = 1,
        
        /// <summary>
        /// Sieg Auswärtsmannschaft.
        /// </summary>
        WinGuest = 2
    }
}
