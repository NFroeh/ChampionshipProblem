namespace ChampionshipProblem.Classes
{
    /// <summary>
    /// Klasse repräsentiert einen Tabelleneintrag.
    /// </summary>
    public class LeagueStandingEntry : ILeagueStandingEntry
    {
        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellend es Tabelleneintrags.
        /// </summary>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="shortName">Der Kurzname des Teams.</param>
        /// <param name="longName">Der Langname des Teams.</param>
        public LeagueStandingEntry(long? teamApiId, string shortName, string longName)
        {
            this.TeamApiId = teamApiId;
            this.TeamShortName = shortName;
            this.TeamLongName = longName;
            this.Points = 0;
            this.Goals = 0;
            this.GoalsConceded = 0;
            this.Games = 0;
        }
        #endregion

        /// <summary>
        /// Die TeamApiId.
        /// </summary>
        public long? TeamApiId { get; set; }

        /// <summary>
        /// Der Kurzname.
        /// </summary>
        public string TeamShortName { get; set; }

        /// <summary>
        /// Der Langname.
        /// </summary>
        public string TeamLongName { get; set; }

        /// <summary>
        /// Die Anzahl der Spiele.
        /// </summary>
        public int Games { get; set; }

        /// <summary>
        /// Die Anzahl der Punkte.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Die Anzahl der Tore.
        /// </summary>
        public int Goals { get; set; }

        /// <summary>
        /// Die Anzahl der gefangenen Tore.
        /// </summary>
        public int GoalsConceded { get; set; }
    }
}
