namespace ChampionshipProblem.Classes
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Die Klasse repräsentiert eine Liga.
    /// </summary>
    public class League
    {
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
