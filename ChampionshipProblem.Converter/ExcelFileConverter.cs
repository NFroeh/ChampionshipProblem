using ChampionshipProblem.DatabaseFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChampionshipProblem.Converter
{
    /// <summary>
    /// Klasse für die Konvertierung der Excel-Files.
    /// </summary>
    public class ExcelFileConverter
    {
        #region consts
        /// <summary>
        /// Pfad zum Ordner des Excel-Ordners.
        /// </summary>
        private const string PathToExcelFolder = "C:\\Users\\NicolaiFröhlig\\source\\repos\\ChampionshipProblem\\ChampionshipProblem.Converter\\ExcelFiles\\";
        #endregion

        #region ConvertExcelFile
        /// <summary>
        /// Konvertiert ein Excel-File (.csv) von https://www.football-data.co.uk/ in die Datenbank.
        /// </summary>
        /// <param name="filename">Der Dateiname.</param>
        /// <param name="leagueName">Der Name der Liga.</param>
        /// <param name="country">Das Land.</param>
        /// <param name="numberOfTeams">Die Anzahl de rTeams.</param>
        /// <param name="season">Die Saison.</param>
        public static void ConvertExcelFile(string filename, string leagueName, Classes.Country country, int numberOfTeams, string season)
        {
            string excelPath = PathToExcelFolder + filename;
            Classes.League league = new Classes.League()
            {
                Name = leagueName,
                Country = country
            };

            List<string> teams = new List<string>();
            int count = 0;
            using (var teamReader = new StreamReader(excelPath))
            {
                // Werte und Zeile holen (Erste Zeile überspringen)
                teamReader.ReadLine();
                string line = teamReader.ReadLine();
                string[] values = line.Split(',');
                string division = values[0];
                league.Division = division;

                while (!teamReader.EndOfStream)
                {
                    if (count < numberOfTeams)
                    {
                        string homeTeam = values[2];
                        string awayTeam = values[3];

                        if (!teams.Any((t) => t == homeTeam))
                        {
                            teams.Add(homeTeam);
                        }

                        if (!teams.Any((t) => t == awayTeam))
                        {
                            teams.Add(awayTeam);
                        }
                    }

                    count++;
                    line = teamReader.ReadLine();
                    values = line.Split(',');
                }
            }

            // Liga und Teams speichern
            using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
            {
                // Falls die Liga schon existiert updaten, sonst nichts tun
                Classes.League existingLeague = mainSoccerDb.Leagues.SingleOrDefault((l) => l.Name == league.Name && l.Country == country);
                if (existingLeague == null)
                {
                    mainSoccerDb.Leagues.Add(league);
                }
                else
                {
                    league.Id = existingLeague.Id;
                    existingLeague.Division = existingLeague.Division;
                }

                foreach (string team in teams)
                {
                    if (!mainSoccerDb.Teams.Any((t) => t.Name == team))
                    {
                        mainSoccerDb.Teams.Add(new Classes.Team()
                        {
                            Name = team
                        });
                    }
                }

                mainSoccerDb.SaveChanges();
            }

            // Matches lesen
            int stage = 1;
            count = 0;
            List<Classes.Match> newMatches = new List<Classes.Match>();
            using (var reader = new StreamReader(excelPath))
            {
                // Erste Zeile überspringen
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    // Alle Mannschaften durch 2 Anzahl der Spiele den Spieltag erhöhen
                    if ((count != 0) && (count % (numberOfTeams / 2) == 0))
                    {
                        stage++;
                    }

                    // Werte und Zeile holen  (Erste Zeile überspringen)
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    // Match erstellen
                    Classes.Match match = new Classes.Match();

                    match.LeagueId = league.Id;
                    match.Season = season;
                    match.Stage = stage;
                    // 0 div
                    match.Date = Convert.ToDateTime(values[1]);
                    using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
                    {
                        var homeTeamName = values[2];
                        var awayTeamName = values[3];
                        match.HomeId = mainSoccerDb.Teams.Single((team) => team.Name == homeTeamName).Id;
                        match.AwayId = mainSoccerDb.Teams.Single((team) => team.Name == awayTeamName).Id;
                    }

                    match.HomeGoals = Convert.ToInt32(values[4]);
                    match.AwayGoals = Convert.ToInt32(values[5]);
                    // 6 FTR
                    // 7 HTHG
                    // 8 HTAG
                    // 9 HTR
                    // 10 Referee
                    // 11 HS
                    // 12 AS
                    // 13 HST
                    // 14 AST
                    // 15 HF
                    // 16 AF
                    // 17 HC
                    // 18 AC
                    // 19 HY
                    // 20 AY 
                    // 21 HR
                    // 22 AR
                    match.B365H = Convert.ToDecimal(values[23]);
                    match.B365D = Convert.ToDecimal(values[24]);
                    match.B365A = Convert.ToDecimal(values[25]);
                    match.BWH = Convert.ToDecimal(values[26]);
                    match.BWD = Convert.ToDecimal(values[27]);
                    match.BWA = Convert.ToDecimal(values[28]);
                    match.IWH = Convert.ToDecimal(values[29]);
                    match.IWD = Convert.ToDecimal(values[30]);
                    match.IWA = Convert.ToDecimal(values[31]);
                    match.LBH = Convert.ToDecimal(values[32]);
                    match.LBD = Convert.ToDecimal(values[33]);
                    match.LBA = Convert.ToDecimal(values[34]);
                    match.PSH = Convert.ToDecimal(values[35]);
                    match.PSD = Convert.ToDecimal(values[36]);
                    match.PSA = Convert.ToDecimal(values[37]);
                    match.WHH = Convert.ToDecimal(values[38]);
                    match.WHD = Convert.ToDecimal(values[39]);
                    match.WHA = Convert.ToDecimal(values[40]);
                    match.VCH = Convert.ToDecimal(values[41]);
                    match.VCD = Convert.ToDecimal(values[42]);
                    match.VCA = Convert.ToDecimal(values[43]);
                    // 44 Bb1X2
                    // 45 BbMxH
                    // 46 BbAvH
                    // 47 BbMxD
                    // 48 BbAvD
                    // 49 BbMxA
                    // 50 BbAvA
                    // 51 BbOU
                    // 52 BbMx > 2.5
                    // 53 BbAv > 2.5
                    // 54 BbMx < 2.5
                    // 55 BbAv < 2.5
                    // 56 BbAH
                    // 57 BbAHh
                    // 58 BbMxAHH
                    // 59 BbAvAHH
                    // 60 BbMxAHA
                    // 61 BbAvAHA
                    // 62 PSCH
                    // 63 PSCD
                    // 64 PSCA

                    newMatches.Add(match);
                    count++;
                }
            }

            using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
            {
                mainSoccerDb.Matches.AddRange(newMatches);
                mainSoccerDb.SaveChanges();
            }
        }
        #endregion
    }
}
