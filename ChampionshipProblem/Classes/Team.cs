namespace ChampionshipProblem.Classes
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Klasse repräsentiert ein Team.
    /// </summary>
    public class Team
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
    }
}
