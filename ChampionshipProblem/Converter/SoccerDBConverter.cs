namespace ChampionshipProblem.Converter
{
    using ChampionshipProblem.Classes;
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    /// <summary>
    /// Klasse zum Konvertieren der WorldDB in die League-Klassen.
    /// </summary>
    public class SoccerDBConverter
    {
        #region consts
        /// <summary>
        /// Pfad zur WorldDB.
        /// </summary>
        private const string path = "C:\\Users\\NicolaiFröhlig\\source\\repos\\ChampionshipProblem\\ChampionshipProblem\\DatabaseFiles\\SoccerComplete.sqlite";
        #endregion

        #region ConvertToNewDb
        /// <summary>
        /// Methode zum Konvertieren der WorldDb in die Klassen der Datenbank und Speicherung in eine neue DB.
        /// </summary>
        public static void ConvertToNewDb()
        {
            SQLiteConnection connection = new SQLiteConnection
            {
                ConnectionString = "Data Source=" + path
            };
            string getRowsCommand = "SELECT * FROM football_data";

            connection.Open();
            SQLiteCommand getAllRowsCommand = new SQLiteCommand(getRowsCommand, connection);
            
            // Den Befehl ausführen
            SQLiteDataReader rowReader = getAllRowsCommand.ExecuteReader();

            // Listen anlegen für die Daten
            List<League> leagues = new List<League>();
            List<Team> teams = new List<Team>();
            List<Match> matches = new List<Match>();
            while (rowReader.Read())
            {
                // Als Erstes die Liga ermitteln
                string country = rowReader["Country"].ToString();
                string leagueName = rowReader["League"].ToString();
                string division = rowReader["Div"].ToString();
                League league = leagues.Single((l) => l.Name == leagueName);
                if (league == null)
                {
                    league = new League()
                    {
                        Name = leagueName,
                        Division = division,
                        Country = (Country)Enum.Parse(typeof(Country), country)
                    };
                    leagues.Add(league);
                }

                // Die Teams ermitteln
                string homeTeamString = rowReader["HomeTeam"].ToString();
                string awayTeamString = rowReader["AwayTeam"].ToString();
                Team homeTeam = teams.Single((t) => t.Name == homeTeamString);
                Team awayTeam = teams.Single((t) => t.Name == awayTeamString);
                if (homeTeam == null)
                {
                    homeTeam = new Team()
                    {
                        Name = homeTeamString
                    };
                    teams.Add(homeTeam);
                }

                if (awayTeam == null)
                {
                    awayTeam = new Team()
                    {
                        Name = awayTeamString
                    };
                    teams.Add(awayTeam);
                }

                // Das Match ermitteln
                matches.Add(new Match()
                {
                    Season = rowReader["Season"].ToString(),
                    Date = Convert.ToDateTime(rowReader["Date"]),
                    HomeGoals = Convert.ToInt32(rowReader["FTHG"]),
                    AwayGoals = Convert.ToInt32(rowReader["FTAG"]),
                    League = league,
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    B365H = Convert.ToDouble(rowReader["B365H"]),
                    B365D = Convert.ToDouble(rowReader["B365D"]),
                    B365A = Convert.ToDouble(rowReader["B365A"]),
                    BSH = Convert.ToDouble(rowReader["BSH"]),
                    BSD = Convert.ToDouble(rowReader["BSD"]),
                    BSA = Convert.ToDouble(rowReader["BSA"]),
                    BWH = Convert.ToDouble(rowReader["BWH"]),
                    BWD = Convert.ToDouble(rowReader["BWD"]),
                    BWA = Convert.ToDouble(rowReader["BWA"]),
                    GBH = Convert.ToDouble(rowReader["GBH"]),
                    GBD = Convert.ToDouble(rowReader["GBD"]),
                    GBA = Convert.ToDouble(rowReader["GBA"]),
                    IWH = Convert.ToDouble(rowReader["IWH"]),
                    IWD = Convert.ToDouble(rowReader["IWD"]),
                    IWA = Convert.ToDouble(rowReader["IWA"]),
                    LBH = Convert.ToDouble(rowReader["LBH"]),
                    LBD = Convert.ToDouble(rowReader["LBD"]),
                    LBA = Convert.ToDouble(rowReader["LBA"]),
                    PSH = Convert.ToDouble(rowReader["PSH"]),
                    PSD = Convert.ToDouble(rowReader["PSD"]),
                    PSA = Convert.ToDouble(rowReader["PSA"]),
                    SOH = Convert.ToDouble(rowReader["SOH"]),
                    SOD = Convert.ToDouble(rowReader["SOD"]),
                    SOA = Convert.ToDouble(rowReader["SOA"]),
                    SBH = Convert.ToDouble(rowReader["SBH"]),
                    SBD = Convert.ToDouble(rowReader["SBD"]),
                    SBA = Convert.ToDouble(rowReader["SBA"]),
                    SJH = Convert.ToDouble(rowReader["SJH"]),
                    SJD = Convert.ToDouble(rowReader["SJD"]),
                    SJA = Convert.ToDouble(rowReader["SJA"]),
                    SYH = Convert.ToDouble(rowReader["SYH"]),
                    SYD = Convert.ToDouble(rowReader["SYD"]),
                    SYA = Convert.ToDouble(rowReader["SYA"]),
                    VCH = Convert.ToDouble(rowReader["VCH"]),
                    VCD = Convert.ToDouble(rowReader["VCD"]),
                    VCA = Convert.ToDouble(rowReader["VCA"]),
                    WHH = Convert.ToDouble(rowReader["WHH"]),
                    WHD = Convert.ToDouble(rowReader["WHD"]),
                    WHA = Convert.ToDouble(rowReader["WHA"]),
                });
            }

            connection.Close();

            // Konvertieren der fehlenden Ligen von der ersten europäischen Datenbank (Schweiz, Polen)
        }
        #endregion
    }
}
