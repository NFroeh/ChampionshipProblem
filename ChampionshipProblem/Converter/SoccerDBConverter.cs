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
        /// Die Größe eines Batches.
        /// </summary>
        private const int batchCount = 500;
        #endregion

        #region ConvertToNewDb
        /// <summary>
        /// Methode zum Konvertieren der WorldDb in die Klassen der Datenbank und Speicherung in eine neue DB.
        /// </summary>
        public static void ConvertToNewDb()
        {
            SimpleLogger logger = new SimpleLogger();

            // Verbindung öffnen
            SQLiteConnection connection = new SQLiteConnection
            {
                ConnectionString = "Data Source=" + Path
            };
            connection.Open();
            
            // Die Anzahl der Zeilen holen
            SQLiteCommand GetNumberOfRowsCommand = new SQLiteCommand(
                "SELECT COUNT(*) FROM football_data",
                connection
            );

            // Den Befehl zum holen der Daten ausführen
            string getRowsCommand = "SELECT * FROM football_data LIMIT {0} OFFSET {1}";
            SQLiteCommand getAllRowsCommand = new SQLiteCommand(
                string.Format(getRowsCommand, batchCount, 0), 
                connection
            );
            
            // Den Befehl ausführen
            SQLiteDataReader rowReader = getAllRowsCommand.ExecuteReader();
            int rowCount = Convert.ToInt32(GetNumberOfRowsCommand.ExecuteScalar());
            int currentCount = batchCount;

            do
            {
                Trace.TraceInformation($"Starting batch {currentCount}");
                logger.Info($"Starting batch {currentCount}");
                using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
                {
                    List<Classes.League> existingLeagues = mainSoccerDb.Leagues.ToList();
                    List<Classes.Team> currentTeams = mainSoccerDb.Teams.ToList();

                    while (rowReader.Read())
                    {
                        // Als Erstes die Liga ermitteln
                        string country = rowReader["Country"].ToString();
                        string leagueName = rowReader["League"].ToString();
                        string division = rowReader["Div"].ToString();
                        Classes.League league = existingLeagues.SingleOrDefault((l) => l.Name == leagueName);
                        if (league == null)
                        {
                            league = new Classes.League()
                            {
                                Name = leagueName,
                                Division = division,
                                Country = (Classes.Country)Enum.Parse(typeof(Classes.Country), country)
                            };
                            mainSoccerDb.Leagues.Add(league);
                            existingLeagues.Add(league);
                        }

                        // Die Teams ermitteln
                        string homeTeamString = rowReader["HomeTeam"].ToString();
                        string awayTeamString = rowReader["AwayTeam"].ToString();
                        if (homeTeamString == "" || awayTeamString == "")
                        {
                            continue;
                        }

                        Classes.Team homeTeam = currentTeams.SingleOrDefault((t) => t.Name == homeTeamString);
                        Classes.Team awayTeam = currentTeams.SingleOrDefault((t) => t.Name == awayTeamString);
                        if (homeTeam == null)
                        {
                            homeTeam = new Classes.Team()
                            {
                                Name = homeTeamString
                            };
                            mainSoccerDb.Teams.Add(homeTeam);
                            currentTeams.Add(homeTeam);
                        }

                        if (awayTeam == null)
                        {
                            awayTeam = new Classes.Team()
                            {
                                Name = awayTeamString
                            };
                            mainSoccerDb.Teams.Add(awayTeam);
                            currentTeams.Add(awayTeam);
                        }

                        // Das Match ermitteln
                        Classes.Match match = new Classes.Match()
                        {
                            Season = rowReader["Season"].ToString(),
                            Date = rowReader["Date"].ToString(),
                            HomeGoals = Convert.ToInt32(rowReader["FTHG"]),
                            AwayGoals = Convert.ToInt32(rowReader["FTAG"]),
                            League = league,
                            HomeTeam = homeTeam,
                            AwayTeam = awayTeam,
                        };

                        match.B365H = rowReader["B365H"].ConvertToDecimal();
                        match.B365D = rowReader["B365H"].ConvertToDecimal();
                        match.B365A = rowReader["B365H"].ConvertToDecimal();
                        match.BSH = rowReader["BSH"].ConvertToDecimal();
                        match.BSD = rowReader["BSD"].ConvertToDecimal();
                        match.BSA = rowReader["BSA"].ConvertToDecimal();
                        match.BWH = rowReader["BWH"].ConvertToDecimal();
                        match.BWD = rowReader["BWD"].ConvertToDecimal();
                        match.BWA = rowReader["BWA"].ConvertToDecimal();
                        match.GBH = rowReader["GBH"].ConvertToDecimal();
                        match.GBD = rowReader["GBD"].ConvertToDecimal();
                        match.GBA = rowReader["GBA"].ConvertToDecimal();
                        match.IWH = rowReader["IWH"].ConvertToDecimal();
                        match.IWD = rowReader["IWD"].ConvertToDecimal();
                        match.IWA = rowReader["IWA"].ConvertToDecimal();
                        match.LBH = rowReader["LBH"].ConvertToDecimal();
                        match.LBD = rowReader["LBD"].ConvertToDecimal();
                        match.LBA = rowReader["LBA"].ConvertToDecimal();
                        match.PSH = rowReader["PSH"].ConvertToDecimal();
                        match.PSD = rowReader["PSD"].ConvertToDecimal();
                        match.PSA = rowReader["PSA"].ConvertToDecimal();
                        match.SOH = rowReader["SOH"].ConvertToDecimal();
                        match.SOD = rowReader["SOD"].ConvertToDecimal();
                        match.SOA = rowReader["SOA"].ConvertToDecimal();
                        match.SBH = rowReader["SBH"].ConvertToDecimal();
                        match.SBD = rowReader["SBD"].ConvertToDecimal();
                        match.SBA = rowReader["SBA"].ConvertToDecimal();
                        match.SJH = rowReader["SJH"].ConvertToDecimal();
                        match.SJD = rowReader["SJD"].ConvertToDecimal();
                        match.SJA = rowReader["SJA"].ConvertToDecimal();
                        match.SYH = rowReader["SYH"].ConvertToDecimal();
                        match.SYD = rowReader["SYD"].ConvertToDecimal();
                        match.SYA = rowReader["SYA"].ConvertToDecimal();
                        match.VCH = rowReader["VCH"].ConvertToDecimal();
                        match.VCD = rowReader["VCD"].ConvertToDecimal();
                        match.VCA = rowReader["VCA"].ConvertToDecimal();
                        match.WHH = rowReader["WHH"].ConvertToDecimal();
                        match.WHD = rowReader["WHD"].ConvertToDecimal();
                        match.WHA = rowReader["WHA"].ConvertToDecimal();
                        mainSoccerDb.Matches.Add(match);
                    }

                    // Änderungen speichern
                    mainSoccerDb.SaveChanges();

                    // Den neuen Befehl anlegen unda usführen
                    getAllRowsCommand = new SQLiteCommand(
                        string.Format(getRowsCommand, currentCount + batchCount, currentCount),
                        connection
                    );
                    rowReader = getAllRowsCommand.ExecuteReader();
                    Trace.TraceInformation($"Ended batch {currentCount}");
                    logger.Info($"Ended batch {currentCount}");
                    currentCount += batchCount;
                }
            }
            while (currentCount - batchCount < rowCount);

            // Verbindung schließen
            connection.Close();

            Trace.TraceInformation("Starting missing leagues.");
            logger.Info("Starting missing leagues.");

            // Konvertieren der fehlenden Ligen von der ersten europäischen Datenbank (Schweiz, Polen)
            using (EuropeanSoccerEntities europeanSoccerEntities = new EuropeanSoccerEntities())
            {
                using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
                {
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
                    mainSoccerDb.Leagues.Add(polandLeague);
                    mainSoccerDb.Leagues.Add(swissLeague);

                    // Ermittle die Teams
                    IEnumerable<Scheme.Team> polandOrSwissTeams = europeanSoccerEntities
                        .Teams
                        .Where((team) =>
                            europeanSoccerEntities.Matches.Any((match) => (match.home_team_api_id == team.team_api_id || match.away_team_api_id == team.team_api_id) && (match.league_id == 15722 || match.league_id == 24558)));
                    foreach (Scheme.Team team in polandOrSwissTeams)
                    {
                        if (!mainSoccerDb.Teams.Any((t) => t.Name == team.team_long_name))
                        {
                            mainSoccerDb.Teams.Add(new Classes.Team()
                            {
                                Name = team.team_long_name
                            });
                        }
                    }

                    // Ermittle die Spiele
                    IEnumerable<Scheme.Match> polandMatches = europeanSoccerEntities
                        .Matches
                        .Where((match) => match.league_id == 15722);

                    IEnumerable<Scheme.Match> swissMatches = europeanSoccerEntities
                        .Matches
                        .Where((match) => match.league_id == 24558);

                    foreach (Scheme.Match polandMatch in polandMatches)
                    {
                        mainSoccerDb.Matches.Add(new Classes.Match()
                        {
                            Season = polandMatch.season,
                            Date = polandMatch.date,
                            League = polandLeague,
                            HomeTeam = mainSoccerDb.Teams.Single((team) => team.Name == (europeanSoccerEntities.Teams.Single((t) => t.team_api_id == polandMatch.home_team_api_id)).team_long_name),
                            AwayTeam = mainSoccerDb.Teams.Single((team) => team.Name == (europeanSoccerEntities.Teams.Single((t) => t.team_api_id == polandMatch.away_team_api_id)).team_long_name),
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
                        });
                    }

                    foreach (Scheme.Match swissMatch in swissMatches)
                    {
                        mainSoccerDb.Matches.Add(new Classes.Match()
                        {
                            Season = swissMatch.season,
                            Date = swissMatch.date,
                            League = polandLeague,
                            HomeTeam = mainSoccerDb.Teams.Single((team) => team.Name == (europeanSoccerEntities.Teams.Single((t) => t.team_api_id == swissMatch.home_team_api_id)).team_long_name),
                            AwayTeam = mainSoccerDb.Teams.Single((team) => team.Name == (europeanSoccerEntities.Teams.Single((t) => t.team_api_id == swissMatch.away_team_api_id)).team_long_name),
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

                    mainSoccerDb.SaveChanges();
                }
            }
        }
        #endregion
    }
}
