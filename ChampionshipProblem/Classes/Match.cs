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
        public string Date { get; set; }

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
        /// Wettquote Sporting Odds-Heim.
        /// </summary>
        public decimal? SOH { get; set; }

        /// <summary>
        /// Wettquote Sporting Odds-Unentschieden.
        /// </summary>
        public decimal? SOD { get; set; }

        /// <summary>
        /// Wettquote Sporting Odds-Auswärts.
        /// </summary>
        public decimal? SOA { get; set; }

        /// <summary>
        /// Wettquote Sportingbet-Home.
        /// </summary>
        public decimal? SBH { get; set; }

        /// <summary>
        /// Wettquote Sportingbet-Unentschieden.
        /// </summary>
        public decimal? SBD { get; set; }

        /// <summary>
        /// Wettquote Sportingbet-Auswärts.
        /// </summary>
        public decimal? SBA { get; set; }

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
        /// Wettquote Stanleybet-Heim.
        /// </summary>
        public decimal? SYH { get; set; }

        /// <summary>
        /// Wettquote Stanleybet-Unentschieden.
        /// </summary>
        public decimal? SYD { get; set; }

        /// <summary>
        /// Wettquote Stanleybet-Auswärts.
        /// </summary>
        public decimal? SYA { get; set; }

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
        /// Wettquote Wiliam Hill-Heim.
        /// </summary>
        public decimal? WHH { get; set; }

        /// <summary>
        /// Wettquote Wiliam Hill-Unentschieden.
        /// </summary>
        public decimal? WHD { get; set; }

        /// <summary>
        /// Wettquote Wiliam Hill-Auswärts.
        /// </summary>
        public decimal? WHA { get; set; }

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
