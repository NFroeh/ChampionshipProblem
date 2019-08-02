namespace ChampionshipProblem.Classes.WorldCup
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Klasse repräsentiert ein Spiel der Weltmeisterschaft.
    /// </summary>
    public class WorldCupMatch
    {
        public WorldCupMatch()
        {
            MatchResult = MatchResult.Tie;
        }

        /// <summary>
        /// Die Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Das Land.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Die Liganummer.
        /// </summary>
        [ForeignKey("WorldCup")]
        public int WorldCupId { get; set; }

        /// <summary>
        /// Die Saison.
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// Das Datum.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Der Spieltag.
        /// </summary>
        public int Stage { get; set; }

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
        /// Die GroupStage.
        /// </summary>
        public GroupStage GroupStage { get; set; }

        /// <summary>
        /// Der WorldCup.
        /// </summary>
        public WorldCup WorldCup { get; set; }

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
