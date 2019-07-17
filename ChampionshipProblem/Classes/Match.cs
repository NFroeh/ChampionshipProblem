namespace ChampionshipProblem.Classes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Klasse repräsentiert ein Spiel.
    /// </summary>
    public class Match
    {
        public Match()
        {
            MatchResult = MatchResult.Tie;
        }

        /// <summary>
        /// Die Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Die Liganummer.
        /// </summary>
        [ForeignKey("League")]
        public int LeagueId { get; set; }
        
        /// <summary>
        /// Die Saison.
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// Das Datum.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Die Id für das Heimteam.
        /// </summary>
        [ForeignKey("HomeTeam")]
        public int HomeId { get; set; }

        /// <summary>
        /// Die Id für das Auswärtsteam.
        /// </summary>
        [ForeignKey("AwayTeam")]
        public int AwayId { get; set; }

        /// <summary>
        /// Die Tore des Heimteams.
        /// </summary>
        public int HomeGoals { get; set; }

        /// <summary>
        /// Die Auswärtstore.
        /// </summary>
        public int AwayGoals { get; set; }

        /// <summary>
        /// Das Ergebnis.
        /// </summary>
        public MatchResult MatchResult { get; set; }

        /// <summary>
        /// Wettquote B365-Heim.
        /// </summary>
        public double B365H { get; set; }

        /// <summary>
        /// Wettquote B365-Unentschieden.
        /// </summary>
        public double B365D { get; set; }

        /// <summary>
        /// Wettquote B365-Auswärts.
        /// </summary>
        public double B365A { get; set; }

        /// <summary>
        /// Wettquote Blue Square-Heim.
        /// </summary>
        public double BSH { get; set; }

        /// <summary>
        /// Wettquote Blue Square-Unentschieden.
        /// </summary>
        public double BSD { get; set; }

        /// <summary>
        /// Wettquote Blue Square-Auswärts.
        /// </summary>
        public double BSA { get; set; }

        /// <summary>
        /// Wettquote Bet&Win-Heim.
        /// </summary>
        public double BWH { get; set; }

        /// <summary>
        /// Wettquote Bet&Win-Unentschieden.
        /// </summary>
        public double BWD { get; set; }

        /// <summary>
        /// Wettquote Bet&Win-Auswärts.
        /// </summary>
        public double BWA { get; set; }

        /// <summary>
        /// Wettquote Gamebookers-Heim.
        /// </summary>
        public double GBH { get; set; }

        /// <summary>
        /// Wettquote Gamebookers-Unentschieden.
        /// </summary>
        public double GBD { get; set; }

        /// <summary>
        /// Wettquote Gamebookers-Auswärts.
        /// </summary>
        public double GBA { get; set; }

        /// <summary>
        /// Wettquote Interwetten-Heim.
        /// </summary>
        public double IWH { get; set; }

        /// <summary>
        /// Wettquote Interwetten-Unentschieden.
        /// </summary>
        public double IWD { get; set; }

        /// <summary>
        /// Wettquote Interwetten-Auswärts.
        /// </summary>
        public double IWA { get; set; }

        /// <summary>
        /// Wettquote Ladbrokes-Heim.
        /// </summary>
        public double LBH { get; set; }

        /// <summary>
        /// Wettquote Ladbrokes-UNentschieden.
        /// </summary>
        public double LBD { get; set; }

        /// <summary>
        /// Wettquote Ladbrokes-Auswärts.
        /// </summary>
        public double LBA { get; set; }

        /// <summary>
        /// Wettquote Pinnacle-Heim.
        /// </summary>
        public double PSH { get; set; }

        /// <summary>
        /// Wettquote Pinnacle-Unentschieden.
        /// </summary>
        public double PSD { get; set; }

        /// <summary>
        /// Wettquote Pinnacle-Auswärts.
        /// </summary>
        public double PSA { get; set; }

        /// <summary>
        /// Wettquote Sporting Odds-Heim.
        /// </summary>
        public double SOH { get; set; }

        /// <summary>
        /// Wettquote Sporting Odds-Unentschieden.
        /// </summary>
        public double SOD { get; set; }

        /// <summary>
        /// Wettquote Sporting Odds-Auswärts.
        /// </summary>
        public double SOA { get; set; }

        /// <summary>
        /// Wettquote Sportingbet-Home.
        /// </summary>
        public double SBH { get; set; }

        /// <summary>
        /// Wettquote Sportingbet-Unentschieden.
        /// </summary>
        public double SBD { get; set; }

        /// <summary>
        /// Wettquote Sportingbet-Auswärts.
        /// </summary>
        public double SBA { get; set; }

        /// <summary>
        /// Wettquote Stan James-Heim.
        /// </summary>
        public double SJH { get; set; }

        /// <summary>
        /// Wettquote Stan James-Unentschieden.
        /// </summary>
        public double SJD { get; set; }

        /// <summary>
        /// Wettquote Stan James-Auswärts.
        /// </summary>
        public double SJA { get; set; }

        /// <summary>
        /// Wettquote Stanleybet-Heim.
        /// </summary>
        public double SYH { get; set; }

        /// <summary>
        /// Wettquote Stanleybet-Unentschieden.
        /// </summary>
        public double SYD { get; set; }

        /// <summary>
        /// Wettquote Stanleybet-Auswärts.
        /// </summary>
        public double SYA { get; set; }

        /// <summary>
        /// Wettquote VC Bet-Heim.
        /// </summary>
        public double VCH { get; set; }

        // <summary>
        /// Wettquote VC Bet-Unentschieden.
        /// </summary>
        public double VCD { get; set; }

        // <summary>
        /// Wettquote VC Bet-Auswärts.
        /// </summary>
        public double VCA { get; set; }

        /// <summary>
        /// Wettquote Wiliam Hill-Heim.
        /// </summary>
        public double WHH { get; set; }

        /// <summary>
        /// Wettquote Wiliam Hill-Unentschieden.
        /// </summary>
        public double WHD { get; set; }

        /// <summary>
        /// Wettquote Wiliam Hill-Auswärts.
        /// </summary>
        public double WHA { get; set; }

        /// <summary>
        /// Die Liga.
        /// </summary>
        public League League { get; set; }

        /// <summary>
        /// Das Heimteam.
        /// </summary>
        public Team HomeTeam { get; set; }

        /// <summary>
        /// Das Gegnerteam.
        /// </summary>
        public Team AwayTeam { get; set; }
    }
}
