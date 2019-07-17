namespace ChampionshipProblem.Classes
{
    /// <summary>
    /// Klasse repräsentiert die komplette Darstellung eines Tabeleleneintrags.
    /// </summary>
    public class CompleteLeagueStandingEntry : ILeagueStandingEntry
    {
        #region ctors
        /// <summary>
        /// Konstruktor zum Initialisieren der Klasse.
        /// </summary>
        /// <param name="teamId">Die Team-Id.</param>
        /// <param name="teamApiId">Die Team-Api-Id.</param>
        /// <param name="shortName">Der Kurzname des Teams.</param>
        /// <param name="longName">Der lange Name des Teams.</param>
        public CompleteLeagueStandingEntry(int teamId, long? teamApiId, string shortName, string longName)
        {
            this.TeamId = teamId;
            this.TeamApiId = teamApiId;
            this.TeamShortName = shortName;
            this.TeamLongName = longName;
            this.Points = 0;
            this.Goals = 0;
            this.GoalsConceded = 0;
            this.GoalDifference = 0;
            this.BestPossiblePosition = null;
            this.WorstPossiblePosition = null;
            this.CanWinChampionship = null;
            this.Position = 0;
            this.LastElapsedTime = null;
        }
        #endregion

        /// <summary>
        /// Die TeamId.
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Die API-Id des Teams.
        /// </summary>
        public long? TeamApiId { get; set; }

        /// <summary>
        /// Der Kurzname des Teams.
        /// </summary>
        public string TeamShortName { get; set; }

        /// <summary>
        /// Der Langname des Teams.
        /// </summary>
        public string TeamLongName { get; set; }

        /// <summary>
        /// Die Anzahl der Spiele.
        /// </summary>
        public int Games { get; set; }

        /// <summary>
        /// Die Anzahl der Siege.
        /// </summary>
        public int Wins { get; set; }

        /// <summary>
        /// DIe Anzahl der Unentschieden.
        /// </summary>
        public int Ties { get; set; }

        /// <summary>
        /// Die Anzahl der Niederlagen.
        /// </summary>
        public int Losses { get; set; }

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

        /// <summary>
        /// Die Tordifferenz.
        /// </summary>
        public int GoalDifference { get; set; }

        /// <summary>
        /// Die Position.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Die bestmögliche Position.
        /// </summary>
        public int? BestPossiblePosition { get; set; }

        /// <summary>
        /// Die schlechtmöglichste Position.
        /// </summary>
        public int? WorstPossiblePosition { get; set; }

        /// <summary>
        /// Ob die Mannschaft noch Meister werden kann.
        /// </summary>
        public bool? CanWinChampionship { get; set; }

        /// <summary>
        /// Die verstrichene Zeit der letzten Berechnung.
        /// </summary>
        public double? LastElapsedTime { get; set; }
    }
}
