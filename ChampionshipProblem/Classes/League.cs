namespace ChampionshipProblem.Classes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Die Klasse repräsentiert eine Liga.
    /// </summary>
    public class League
    {
        #region consts
        /// <summary>
        /// Der belgische Liganame.
        /// </summary>
        public const string BelgiumLeagueName = "Belgium Jupiler League";

        /// <summary>
        /// Der englische Liganame.
        /// </summary>
        public const string EnglandLeagueName = "England Premier League";

        /// <summary>
        /// Der französische Liganame.
        /// </summary>
        public const string FranceLeagueName = "France Ligue 1";

        /// <summary>
        /// Der deutsche Liganame.
        /// </summary>
        public const string GermanyLeagueName = "Germany 1. Bundesliga";

        /// <summary>
        /// Der italienische Liganame.
        /// </summary>
        public const string ItalyLeagueName = "Italy Serie A";

        /// <summary>
        /// Der niederländische Liganame.
        /// </summary>
        public const string NetherlandsLeagueName = "Netherlands Eredivisie";

        /// <summary>
        /// Der polnische Liganame.
        /// </summary>
        public const string PolandLeagueName = "Poland Ekstraklasa";

        /// <summary>
        /// Der portugisische Liganame.
        /// </summary>
        public const string PortugalLeagueName = "Portugal Liga ZON Sagres";

        /// <summary>
        /// Der schottische Liganame.
        /// </summary>
        public const string ScotlandLeagueName = "Scotland Premier League";

        /// <summary>
        /// Der spanische Liganame.
        /// </summary>
        public const string SpainLeagueName = "Spain LIGA BBVA";

        /// <summary>
        /// Der schweizer Liganame.
        /// </summary>
        public const string SwitzerlandLeagueName = "Switzerland Super League";
        #endregion

        /// <summary>
        /// Die Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Der Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Das Land.
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// Die Division.
        /// </summary>
        public string Division { get; set; }

        /// <summary>
        /// Die Spiele der Liga.
        /// </summary>
        public IEnumerable<RemainingMatch> Matches { get; set; }
    }
}
