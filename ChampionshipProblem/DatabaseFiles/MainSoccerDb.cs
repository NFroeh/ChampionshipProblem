namespace ChampionshipProblem.DatabaseFiles
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.WorldCup;
    using SQLite.CodeFirst;
    using System.Data.Entity;
    using System.Data.SQLite;
    using System.Windows.Forms;

    /// <summary>
    /// Der HauptSoccerDb-Kontext.
    /// </summary>
    public class MainSoccerDb : DbContext
    {
        /// <summary>
        /// Konstruktor zum Erstellen des DbContextes.
        /// </summary>
        public MainSoccerDb()
            : base(new SQLiteConnection() {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = System.AppDomain.CurrentDomain.BaseDirectory + "DatabaseFiles\\MainSoccerDb.sqlite",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        {
        }

        /// <summary>
        /// Bei Generierung der Datenbank.
        /// </summary>
        /// <param name="modelBuilder">Der Modelbuilder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<MainSoccerDb>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }

        /// <summary>
        /// Die Ligen.
        /// </summary>
        public virtual DbSet<League> Leagues { get; set; }

        /// <summary>
        /// Die Mannschaften.
        /// </summary>
        public virtual DbSet<Team> Teams { get; set; }

        /// <summary>
        /// Die Spiele.
        /// </summary>
        public virtual DbSet<Match> Matches { get; set; }

        /// <summary>
        /// Die Weltmeisterschaften.
        /// </summary>
        public virtual DbSet<WorldCup> WorldCups { get; set; }

        /// <summary>
        /// Die WorldCup-Matches.
        /// </summary>
        public virtual DbSet<WorldCupMatch> WorldCupMatches { get; set; }
    }
}