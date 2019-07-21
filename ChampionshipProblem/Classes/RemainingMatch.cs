using System;

namespace ChampionshipProblem.Classes
{
    /// <summary>
    /// Klasse repräsentiert ein fehlendes Match.
    /// </summary>
    public class RemainingMatch
    {
        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Spiels.
        /// </summary>
        public RemainingMatch()
        {
            MatchResult = MatchResult.Tie;
        }
        #endregion

        /// <summary>
        /// Die Id des Spiels.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Die Landesnummer des SPiels.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Die Liganummer des Spiels.
        /// </summary>
        public int LeagueId { get; set; }

        /// <summary>
        /// Die Saison.
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// Der Spieltag.
        /// </summary>
        public int Stage { get; set; }

        /// <summary>
        /// Das Datum.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Die Id der Heimmannschaft.
        /// </summary>
        public int HomeTeamId { get; set; }

        /// <summary>
        /// Die Id der Auswärtsmannschaft.
        /// </summary>
        public int AwayTeamId { get; set; }

        /// <summary>
        /// Der Name des Heimteams.
        /// </summary>
        public string HomeTeamName { get; set; }

        /// <summary>
        /// Der Name des Auswärtsteams.
        /// </summary>
        public string AwayTeamName { get; set; }

        /// <summary>
        /// Die Anzahl der Tore der Heimmannschaft.
        /// </summary>
        public int HomeTeamGoal { get; set; }

        /// <summary>
        /// Die Anzahl der Tore der Auswärtsmannschaft.
        /// </summary>
        public int AwayTeamGoal { get; set; }

        /// <summary>
        /// Das Ergebnis.
        /// </summary>
        public MatchResult MatchResult { get; set; }
    }
}
