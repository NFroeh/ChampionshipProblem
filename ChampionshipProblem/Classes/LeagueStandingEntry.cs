namespace ChampionshipProblem.Classes
{
    /// <summary>
    /// Klasse repräsentiert einen Tabelleneintrag.
    /// </summary>
    public class LeagueStandingEntry : ILeagueStandingEntry
    {
        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Tabelleneintrags.
        /// </summary>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="name">Der Langname des Teams.</param>
        public LeagueStandingEntry(int teamId, string name)
        {
            this.TeamId = teamId;
            this.Name = name;
            this.Points = 0;
            this.Goals = 0;
            this.GoalsConceded = 0;
            this.Games = 0;
        }
        #endregion

        /// <summary>
        /// Die TeamId.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Der Langname.
        /// </summary>
        public string Name { get; set; }

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
