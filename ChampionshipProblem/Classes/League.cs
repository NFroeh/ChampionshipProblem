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
        public const string BelgiumD0LeagueName = "Jupiler League";

        /// <summary>
        /// Der englische Liganame.
        /// </summary>
        public const string EnglandD0LeagueName = "Premier League";

        /// <summary>
        /// Der englische Zweitliganame.
        /// </summary>
        public const string EnglandD1LeagueName = "Championship";

        /// <summary>
        /// Der französische Liganame.
        /// </summary>
        public const string FranceD0LeagueName = "Ligue 1";

        /// <summary>
        /// Der französische Zweitliganame.
        /// </summary>
        public const string FranceD1LeagueName = "Division 2";

        /// <summary>
        /// Der deutsche Liganame.
        /// </summary>
        public const string GermanyD0LeagueName = "1. Bundesliga";

        /// <summary>
        /// Der deutsche Zweitliganame.
        /// </summary>
        public const string GermanyD1LeagueName = "2. Bundesliga";

        /// <summary>
        /// Der griechische Liganame.
        /// </summary>
        public const string GreeceD0LeagueName = "Ethniki Katigoria";

        /// <summary>
        /// Der italienische Liganame.
        /// </summary>
        public const string ItalyD0LeagueName = "Serie A";

        /// <summary>
        /// Der italienische Zweitliganame.
        /// </summary>
        public const string ItalyD1LeagueName = "Serie B";

        /// <summary>
        /// Der niederländische Liganame.
        /// </summary>
        public const string NetherlandsD0LeagueName = "Eredivisie";

        /// <summary>
        /// Der polnische Liganame.
        /// </summary>
        public const string PolandD0LeagueName = "Ekstraklasa";

        /// <summary>
        /// Der portugisische Liganame.
        /// </summary>
        public const string PortugalD0LeagueName = "Liga ZON Sagres";

        /// <summary>
        /// Der schottische Liganame.
        /// </summary>
        public const string ScotlandD0LeagueName = "Premier League";

        /// <summary>
        /// Der spanische Liganame.
        /// </summary>
        public const string SpainD0LeagueName = "LIGA BBVA";

        /// <summary>
        /// Der spanische Zweitliganame.
        /// </summary>
        public const string SpainD1LeagueName = "LIGA Segunda";

        /// <summary>
        /// Der schweizer Liganame.
        /// </summary>
        public const string SwitzerlandD0LeagueName = "Super League";

        /// <summary>
        /// Der türkische LIganame.
        /// </summary>
        public const string TurkeyD0LeagueName = "Ligi 1";
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
