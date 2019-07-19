namespace ChampionshipProblem.Converter
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.DatabaseFiles;
    using ChampionshipProblem.Logger;
    using ChampionshipProblem.Scheme;
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Diagnostics;
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
        private const string Path = "C:\\Users\\NicolaiFröhlig\\source\\repos\\ChampionshipProblem\\ChampionshipProblem\\DatabaseFiles\\SoccerComplete.sqlite";

        /// <summary>
        /// Die Größe eines Batches eines Inserts..
        /// </summary>
        private const int InsertBatch = 1000;
        #endregion

        #region ConvertToNewDb
        /// <summary>
        /// Methode zum Konvertieren der WorldDb in die Klassen der Datenbank und Speicherung in eine neue DB.
        /// </summary>
        public static void ConvertToNewDb()
        {
            // Logger erstellen
            SimpleLogger logger = new SimpleLogger();
            logger.Info("Starting convertion.");

            // Verbindung öffnen
            SQLiteConnection connection = new SQLiteConnection
            {
                ConnectionString = "Data Source=" + Path
            };
            connection.Open();

            // Als Erstes unterschiedliche Ligen laden
            logger.Info("Converting leagues and teams.");
            SQLiteCommand GetDistinctLeaguesCommand = new SQLiteCommand(
                "SELECT DISTINCT League, Div, Country FROM football_data",
                connection);
            SQLiteDataReader leagueReader = GetDistinctLeaguesCommand.ExecuteReader();
            using (MainSoccerDb mainSoccerDb1 = new MainSoccerDb())
            {
                // Als Erstes die Ligen konvertieren
                while (leagueReader.Read())
                {
                    string country = leagueReader["Country"].ToString();
                    string leagueName = leagueReader["League"].ToString();
                    string division = leagueReader["Div"].ToString();

                    Classes.League league = new Classes.League()
                    {
                        Name = leagueName,
                        Division = division,
                        Country = (Classes.Country)Enum.Parse(typeof(Classes.Country), country)
                    };
                    mainSoccerDb1.Leagues.Add(league);
                }

                // Als Zweites die unterschiedlichen Teams laden
                SQLiteCommand GetDistinctTeamsCommand = new SQLiteCommand(
                    "SELECT HomeTeam FROM football_data WHERE HomeTeam != ''" +
                    "UNION SELECT AwayTeam FROM football_data WHERE AwayTeam != ''",
                    connection);
                SQLiteDataReader teamReader = GetDistinctTeamsCommand.ExecuteReader();
                while(teamReader.Read())
                {
                    string teamString = teamReader["HomeTeam"].ToString();
                    Classes.Team team = new Classes.Team()
                    {
                        Name = teamString
                    };
                    mainSoccerDb1.Teams.Add(team);
                }

                // Speichern der Ligen und Teams
                mainSoccerDb1.SaveChanges();
            }

            // Loggen
            logger.Info("Done converting leagues and teams.");

            // Die Teams und Ligen laden
            List<Classes.League> existingLeagues = new List<Classes.League>();
            List<Classes.Team> existingTeams = new List<Classes.Team>();
            using (MainSoccerDb mainSoccerDb1 = new MainSoccerDb())
            {
                 existingLeagues = mainSoccerDb1.Leagues.ToList();
                 existingTeams = mainSoccerDb1.Teams.ToList();
            }

            // Kontext erstellen und Changes nicht verfolgen
            logger.Info("Start of match convertion.");
            MainSoccerDb mainSoccerDb = new MainSoccerDb();
            mainSoccerDb.Configuration.AutoDetectChangesEnabled = false;

            // Den Befehl zum holen der Daten ausführen
            string getRowsCommand = "SELECT * FROM football_data";
            SQLiteCommand getAllRowsCommand = new SQLiteCommand(
                getRowsCommand,
                connection
            );
            SQLiteDataReader matchReader = getAllRowsCommand.ExecuteReader();

            // Lesen
            int rowCount = 0;
            while (matchReader.Read())
            {
                try
                {
                    rowCount++;

                    // Nachdem der Batch erstellt wurde, muss ein neuer Kontext erstellt werden und die Änderung speichern
                    if (rowCount % InsertBatch == 0)
                    {
                        logger.Info($"Starting item {rowCount}. Recreating context and saving changes.");
                        mainSoccerDb.SaveChanges();
                        mainSoccerDb.Dispose();
                        mainSoccerDb = new MainSoccerDb();
                        mainSoccerDb.Configuration.AutoDetectChangesEnabled = false;
                    }

                    // Falls etwas im Match nicht stimmt, dann überspringen und vermerken
                    if (matchReader["League"].ToString() == "" || matchReader["Country"].ToString() == "" || matchReader["HomeTeam"].ToString() == "" || matchReader["AwayTeam"].ToString() == "")
                    {
                        logger.Warning($"Error on match conversion (League: '{matchReader["League"]}, Country: '{matchReader["Country"]}', HomeTeam: '{matchReader["HomeTeam"]}', AwayTeam: '{matchReader["AwayTeam"]}', RowCount: '{rowCount}'");
                        continue;
                    }

                    // Das Match ermitteln
                    Classes.Match match = new Classes.Match()
                    {
                        Season = matchReader["Season"].ToString(),
                        Date = matchReader["Date"].ToString(),
                        HomeGoals = Convert.ToInt32(matchReader["FTHG"]),
                        AwayGoals = Convert.ToInt32(matchReader["FTAG"]),
                        League = existingLeagues.Single((league) => (league.Name == matchReader["League"].ToString()) && (league.Country.ToString() == matchReader["Country"].ToString())),
                        HomeTeam = existingTeams.Single((team) => team.Name == matchReader["HomeTeam"].ToString()),
                        AwayTeam = existingTeams.Single((team) => team.Name == matchReader["AwayTeam"].ToString()),
                    };

                    // Die Wettquoten übertragen
                    match.B365H = matchReader["B365H"].ConvertToDecimal();
                    match.B365D = matchReader["B365H"].ConvertToDecimal();
                    match.B365A = matchReader["B365H"].ConvertToDecimal();
                    match.BSH = matchReader["BSH"].ConvertToDecimal();
                    match.BSD = matchReader["BSD"].ConvertToDecimal();
                    match.BSA = matchReader["BSA"].ConvertToDecimal();
                    match.BWH = matchReader["BWH"].ConvertToDecimal();
                    match.BWD = matchReader["BWD"].ConvertToDecimal();
                    match.BWA = matchReader["BWA"].ConvertToDecimal();
                    match.GBH = matchReader["GBH"].ConvertToDecimal();
                    match.GBD = matchReader["GBD"].ConvertToDecimal();
                    match.GBA = matchReader["GBA"].ConvertToDecimal();
                    match.IWH = matchReader["IWH"].ConvertToDecimal();
                    match.IWD = matchReader["IWD"].ConvertToDecimal();
                    match.IWA = matchReader["IWA"].ConvertToDecimal();
                    match.LBH = matchReader["LBH"].ConvertToDecimal();
                    match.LBD = matchReader["LBD"].ConvertToDecimal();
                    match.LBA = matchReader["LBA"].ConvertToDecimal();
                    match.PSH = matchReader["PSH"].ConvertToDecimal();
                    match.PSD = matchReader["PSD"].ConvertToDecimal();
                    match.PSA = matchReader["PSA"].ConvertToDecimal();
                    match.SOH = matchReader["SOH"].ConvertToDecimal();
                    match.SOD = matchReader["SOD"].ConvertToDecimal();
                    match.SOA = matchReader["SOA"].ConvertToDecimal();
                    match.SBH = matchReader["SBH"].ConvertToDecimal();
                    match.SBD = matchReader["SBD"].ConvertToDecimal();
                    match.SBA = matchReader["SBA"].ConvertToDecimal();
                    match.SJH = matchReader["SJH"].ConvertToDecimal();
                    match.SJD = matchReader["SJD"].ConvertToDecimal();
                    match.SJA = matchReader["SJA"].ConvertToDecimal();
                    match.SYH = matchReader["SYH"].ConvertToDecimal();
                    match.SYD = matchReader["SYD"].ConvertToDecimal();
                    match.SYA = matchReader["SYA"].ConvertToDecimal();
                    match.VCH = matchReader["VCH"].ConvertToDecimal();
                    match.VCD = matchReader["VCD"].ConvertToDecimal();
                    match.VCA = matchReader["VCA"].ConvertToDecimal();
                    match.WHH = matchReader["WHH"].ConvertToDecimal();
                    match.WHD = matchReader["WHD"].ConvertToDecimal();
                    match.WHA = matchReader["WHA"].ConvertToDecimal();
                    mainSoccerDb.Matches.Add(match);
                }
                catch (Exception exception)
                {
                    // Fehler werfen und match spezifizieren
                    throw new InvalidOperationException($"Error on match conversion (League: '{matchReader["League"]}, Country: '{matchReader["Country"]}', HomeTeam: '{matchReader["HomeTeam"]}', AwayTeam: '{matchReader["AwayTeam"]}'", exception);
                }
            }

            // Speichern und Verbindungen schließen
            mainSoccerDb.SaveChanges();
            mainSoccerDb.Dispose();
            connection.Close();
            logger.Info($"Ended match convertion. Converted {rowCount} matches.");
        }
        #endregion

        #region ConvertMissingLeagues
        /// <summary>
        /// Methode zum konvertieren der fehlenden Ligen.
        /// </summary>
        public static void ConvertMissingLeagues()
        {
            // Logger erstellen
            SimpleLogger logger = new SimpleLogger();
            logger.Info("Starting missing leagues.");

            // Konvertieren der fehlenden Ligen von der ersten europäischen Datenbank (Schweiz, Polen)
            List<Scheme.Match> polandMatches = new List<Scheme.Match>();
            List<Scheme.Match> swissMatches = new List<Scheme.Match>();
            Dictionary<long?, string> teamIdDictionary = new Dictionary<long?, string>();
            List<Classes.League> newLeagues = new List<Classes.League>();
            List<Classes.Team> newTeams = new List<Classes.Team>();
            List<Classes.Match> newMatches = new List<Classes.Match>();

            using (EuropeanSoccerEntities europeanSoccerEntities = new EuropeanSoccerEntities())
            {
                // Dictionary für teams und id
                teamIdDictionary = europeanSoccerEntities
                    .Teams
                    .Join(
                        europeanSoccerEntities.Matches,
                        (t) => t.team_api_id,
                        (m) => m.home_team_api_id,
                        (t, m) => new { t.team_api_id, t.team_long_name, m.league_id })
                    .Where((m) => m.league_id == 15722 || m.league_id == 24558)
                    .Distinct()
                    .AsEnumerable()
                    .ToDictionary((team) => team.team_api_id, (team) => team.team_long_name);

                // Ermittle die Spiele
                polandMatches = europeanSoccerEntities
                    .Matches
                    .Where((match) => match.league_id == 15722)
                    .ToList();
                swissMatches = europeanSoccerEntities
                    .Matches
                    .Where((match) => match.league_id == 24558)
                    .ToList();

                // Erstelle Polen- und Schweiz-Liga
                Classes.League polandLeague = new Classes.League()
                {
                    Country = Classes.Country.Poland,
                    Division = "P1",
                    Name = "Poland Ekstraklasa"
                };
                Classes.League swissLeague = new Classes.League()
                {
                    Country = Classes.Country.Swiss,
                    Division = "S1",
                    Name = "Switzerland Super League"
                };
                newLeagues.Add(polandLeague);
                newLeagues.Add(swissLeague);

                // Die Teams verarbeiten
                foreach (string teamString in teamIdDictionary.Values)
                {
                    if (!newTeams.Any((t) => t.Name == teamString))
                    {
                        newTeams.Add(new Classes.Team()
                        {
                            Name = teamString
                        });
                    }
                }

                // Die polnischen Spiele verarbeiten
                foreach (Scheme.Match polandMatch in polandMatches)
                {
                    var h = newTeams.Single((team) => team.Name == teamIdDictionary[polandMatch.home_team_api_id]);
                    var a = newTeams.Single((team) => team.Name == teamIdDictionary[polandMatch.away_team_api_id]);
                    Classes.Match match = new Classes.Match()
                    {
                        Season = polandMatch.season,
                        Date = polandMatch.date,
                        League = polandLeague,
                        HomeTeam = newTeams.Single((team) => team.Name == teamIdDictionary[polandMatch.home_team_api_id]),
                        AwayTeam = newTeams.Single((team) => team.Name == teamIdDictionary[polandMatch.away_team_api_id]),
                        HomeGoals = (int)polandMatch.home_team_goal.Value,
                        AwayGoals = (int)polandMatch.away_team_goal.Value,
                        B365H = Convert.ToDecimal(polandMatch.B365H),
                        B365D = Convert.ToDecimal(polandMatch.B365D),
                        B365A = Convert.ToDecimal(polandMatch.B365A),
                        BSH = Convert.ToDecimal(polandMatch.BSH),
                        BSD = Convert.ToDecimal(polandMatch.BSD),
                        BSA = Convert.ToDecimal(polandMatch.BSA),
                        BWH = Convert.ToDecimal(polandMatch.BWH),
                        BWD = Convert.ToDecimal(polandMatch.BWD),
                        BWA = Convert.ToDecimal(polandMatch.BWA),
                        GBH = Convert.ToDecimal(polandMatch.GBH),
                        GBD = Convert.ToDecimal(polandMatch.GBD),
                        GBA = Convert.ToDecimal(polandMatch.GBA),
                        IWH = Convert.ToDecimal(polandMatch.IWH),
                        IWD = Convert.ToDecimal(polandMatch.IWD),
                        IWA = Convert.ToDecimal(polandMatch.IWA),
                        LBH = Convert.ToDecimal(polandMatch.LBH),
                        LBD = Convert.ToDecimal(polandMatch.LBD),
                        LBA = Convert.ToDecimal(polandMatch.LBA),
                        PSH = Convert.ToDecimal(polandMatch.PSH),
                        PSD = Convert.ToDecimal(polandMatch.PSD),
                        PSA = Convert.ToDecimal(polandMatch.PSA),
                        SOH = 0,
                        SOD = 0,
                        SOA = 0,
                        SBH = 0,
                        SBD = 0,
                        SBA = 0,
                        SJH = Convert.ToDecimal(polandMatch.SJH),
                        SJD = Convert.ToDecimal(polandMatch.SJD),
                        SJA = Convert.ToDecimal(polandMatch.SJA),
                        SYH = 0,
                        SYD = 0,
                        SYA = 0,
                        VCH = Convert.ToDecimal(polandMatch.VCH),
                        VCD = Convert.ToDecimal(polandMatch.VCD),
                        VCA = Convert.ToDecimal(polandMatch.VCA),
                        WHH = Convert.ToDecimal(polandMatch.WHH),
                        WHD = Convert.ToDecimal(polandMatch.WHD),
                        WHA = Convert.ToDecimal(polandMatch.WHA),
                    };
                    newMatches.Add(match);
                }

                // Schweizer Spiele verarbeiten
                foreach (Scheme.Match swissMatch in swissMatches)
                {
                    newMatches.Add(new Classes.Match()
                    {
                        Season = swissMatch.season,
                        Date = swissMatch.date,
                        League = polandLeague,
                        HomeTeam = newTeams.Single((team) => team.Name == teamIdDictionary[swissMatch.home_team_api_id]),
                        AwayTeam = newTeams.Single((team) => team.Name == teamIdDictionary[swissMatch.away_team_api_id]),
                        HomeGoals = (int)swissMatch.home_team_goal.Value,
                        AwayGoals = (int)swissMatch.away_team_goal.Value,
                        B365H = Convert.ToDecimal(swissMatch.B365H),
                        B365D = Convert.ToDecimal(swissMatch.B365D),
                        B365A = Convert.ToDecimal(swissMatch.B365A),
                        BSH = Convert.ToDecimal(swissMatch.BSH),
                        BSD = Convert.ToDecimal(swissMatch.BSD),
                        BSA = Convert.ToDecimal(swissMatch.BSA),
                        BWH = Convert.ToDecimal(swissMatch.BWH),
                        BWD = Convert.ToDecimal(swissMatch.BWD),
                        BWA = Convert.ToDecimal(swissMatch.BWA),
                        GBH = Convert.ToDecimal(swissMatch.GBH),
                        GBD = Convert.ToDecimal(swissMatch.GBD),
                        GBA = Convert.ToDecimal(swissMatch.GBA),
                        IWH = Convert.ToDecimal(swissMatch.IWH),
                        IWD = Convert.ToDecimal(swissMatch.IWD),
                        IWA = Convert.ToDecimal(swissMatch.IWA),
                        LBH = Convert.ToDecimal(swissMatch.LBH),
                        LBD = Convert.ToDecimal(swissMatch.LBD),
                        LBA = Convert.ToDecimal(swissMatch.LBA),
                        PSH = Convert.ToDecimal(swissMatch.PSH),
                        PSD = Convert.ToDecimal(swissMatch.PSD),
                        PSA = Convert.ToDecimal(swissMatch.PSA),
                        SOH = 0,
                        SOD = 0,
                        SOA = 0,
                        SBH = 0,
                        SBD = 0,
                        SBA = 0,
                        SJH = Convert.ToDecimal(swissMatch.SJH),
                        SJD = Convert.ToDecimal(swissMatch.SJD),
                        SJA = Convert.ToDecimal(swissMatch.SJA),
                        SYH = 0,
                        SYD = 0,
                        SYA = 0,
                        VCH = Convert.ToDecimal(swissMatch.VCH),
                        VCD = Convert.ToDecimal(swissMatch.VCD),
                        VCA = Convert.ToDecimal(swissMatch.VCA),
                        WHH = Convert.ToDecimal(swissMatch.WHH),
                        WHD = Convert.ToDecimal(swissMatch.WHD),
                        WHA = Convert.ToDecimal(swissMatch.WHA),
                    });
                }
            }

            // Die neuen Entitäten hinzufügen
            using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
            {
                mainSoccerDb.Leagues.AddRange(newLeagues);
                mainSoccerDb.Teams.AddRange(newTeams);
                mainSoccerDb.Matches.AddRange(newMatches);
                mainSoccerDb.SaveChanges();
            }

            // Loggen
            logger.Info("Finished generating databases.");
        }
        #endregion
    }
}
