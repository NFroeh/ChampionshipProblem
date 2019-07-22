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
        /// Wettquote B365-Heim.
        /// </summary>
        public decimal? B365H { get; set; }

        /// <summary>
        /// Wettquote B365-Unentschieden.
        /// </summary>
        public decimal? B365D { get; set; }

        /// <summary>
        /// Wettquote B365-Auswärts.
        /// </summary>
        public decimal? B365A { get; set; }

        /// <summary>
        /// Wettquote Blue Square-Heim.
        /// </summary>
        public decimal? BSH { get; set; }

        /// <summary>
        /// Wettquote Blue Square-Unentschieden.
        /// </summary>
        public decimal? BSD { get; set; }

        /// <summary>
        /// Wettquote Blue Square-Auswärts.
        /// </summary>
        public decimal? BSA { get; set; }

        /// <summary>
        /// Wettquote Bet&Win-Heim.
        /// </summary>
        public decimal? BWH { get; set; }

        /// <summary>
        /// Wettquote Bet&Win-Unentschieden.
        /// </summary>
        public decimal? BWD { get; set; }

        /// <summary>
        /// Wettquote Bet&Win-Auswärts.
        /// </summary>
        public decimal? BWA { get; set; }

        /// <summary>
        /// Wettquote Gamebookers-Heim.
        /// </summary>
        public decimal? GBH { get; set; }

        /// <summary>
        /// Wettquote Gamebookers-Unentschieden.
        /// </summary>
        public decimal? GBD { get; set; }

        /// <summary>
        /// Wettquote Gamebookers-Auswärts.
        /// </summary>
        public decimal? GBA { get; set; }

        /// <summary>
        /// Wettquote Interwetten-Heim.
        /// </summary>
        public decimal? IWH { get; set; }

        /// <summary>
        /// Wettquote Interwetten-Unentschieden.
        /// </summary>
        public decimal? IWD { get; set; }

        /// <summary>
        /// Wettquote Interwetten-Auswärts.
        /// </summary>
        public decimal? IWA { get; set; }

        /// <summary>
        /// Wettquote Ladbrokes-Heim.
        /// </summary>
        public decimal? LBH { get; set; }

        /// <summary>
        /// Wettquote Ladbrokes-UNentschieden.
        /// </summary>
        public decimal? LBD { get; set; }

        /// <summary>
        /// Wettquote Ladbrokes-Auswärts.
        /// </summary>
        public decimal? LBA { get; set; }

        /// <summary>
        /// Wettquote Pinnacle-Heim.
        /// </summary>
        public decimal? PSH { get; set; }

        /// <summary>
        /// Wettquote Pinnacle-Unentschieden.
        /// </summary>
        public decimal? PSD { get; set; }

        /// <summary>
        /// Wettquote Pinnacle-Auswärts.
        /// </summary>
        public decimal? PSA { get; set; }

        /// <summary>
        /// Wettquote Stan James-Heim.
        /// </summary>
        public decimal? SJH { get; set; }

        /// <summary>
        /// Wettquote Stan James-Unentschieden.
        /// </summary>
        public decimal? SJD { get; set; }

        /// <summary>
        /// Wettquote Stan James-Auswärts.
        /// </summary>
        public decimal? SJA { get; set; }

        /// <summary>
        /// Wettquote VC Bet-Heim.
        /// </summary>
        public decimal? VCH { get; set; }

        // <summary>
        /// Wettquote VC Bet-Unentschieden.
        /// </summary>
        public decimal? VCD { get; set; }

        // <summary>
        /// Wettquote VC Bet-Auswärts.
        /// </summary>
        public decimal? VCA { get; set; }

        /// <summary>
        /// Wettquote William Hill-Heim.
        /// </summary>
        public decimal? WHH { get; set; }

        /// <summary>
        /// Wettquote William Hill-Unentschieden.
        /// </summary>
        public decimal? WHD { get; set; }

        /// <summary>
        /// Wettquote William Hill-Auswärts.
        /// </summary>
        public decimal? WHA { get; set; }

        /// <summary>
        /// Das Ergebnis.
        /// </summary>
        public MatchResult MatchResult { get; set; }
    }
}
