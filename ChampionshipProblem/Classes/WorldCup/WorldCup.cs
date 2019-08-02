namespace ChampionshipProblem.Classes.WorldCup
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Klasse repräsentiert einen WorldCup.
    /// </summary>
    public class WorldCup
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
        /// Das Jahr.
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// Der Name des Landes.
        /// </summary>
        public string CountryName { get; set; }
    }
}
