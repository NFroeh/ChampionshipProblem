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
                        string homeTeam = values[2].Trim();
                        string awayTeam = values[3].Trim();

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
                teamReader.Dispose();
            }

            // Liga und Teams speichern und währendessen Teams-Collection zusammenbauen
            List<Classes.Team> teamsById = new List<Classes.Team>();
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
                    Classes.Team existingTeam = mainSoccerDb.Teams.SingleOrDefault((t) => t.Name == team);
                    if (existingTeam == null)
                    {
                        Classes.Team newTeam = new Classes.Team()
                        {
                            Name = team
                        };
                        mainSoccerDb.Teams.Add(newTeam);
                        teamsById.Add(newTeam);
                    }
                    else
                    {
                        teamsById.Add(existingTeam);
                    }
                }

                mainSoccerDb.SaveChanges();
                mainSoccerDb.Dispose();
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

                    // Bei fehlerhaften Werten abbrechen
                    if (values[1] == "")
                    {
                        break;
                    }

                    // Match erstellen
                    Classes.Match match = new Classes.Match();

                    match.LeagueId = league.Id;
                    match.Season = season;
                    match.Stage = stage;
                    // 0 div
                    match.Date = Convert.ToDateTime(values[1]);
                    var homeTeamName = values[2].Replace(".", string.Empty).Trim();
                    var awayTeamName = values[3].Replace(".", string.Empty).Trim();
                    match.HomeId = teamsById.Single((team) => team.Name == homeTeamName).Id;
                    match.AwayId = teamsById.Single((team) => team.Name == awayTeamName).Id;

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
                    match.B365H = (values[23] != "") ? Convert.ToDecimal(values[24]) : 0;
                    match.B365D = (values[24] != "") ? Convert.ToDecimal(values[24]) : 0;
                    match.B365A = (values[25] != "") ? Convert.ToDecimal(values[25]) : 0;
                    match.BWH = (values[26] != "") ? Convert.ToDecimal(values[26]) : 0;
                    match.BWD = (values[27] != "")? Convert.ToDecimal(values[27]) : 0;
                    match.BWA = (values[28] != "")? Convert.ToDecimal(values[28]) : 0;
                    match.IWH = (values[29] != "")? Convert.ToDecimal(values[29]) : 0;
                    match.IWD = (values[30] != "")? Convert.ToDecimal(values[30]) : 0;
                    match.IWA = (values[31] != "") ? Convert.ToDecimal(values[31]) : 0;
                    match.LBH = (values[32] != "")? Convert.ToDecimal(values[32]) : 0;
                    match.LBD = (values[33] != "")? Convert.ToDecimal(values[33]) : 0;
                    match.LBA = (values[34] != "")? Convert.ToDecimal(values[34]) : 0;
                    match.PSH = (values[35] != "")? Convert.ToDecimal(values[35]) : 0;
                    match.PSD = (values[36] != "")? Convert.ToDecimal(values[36]) : 0;
                    match.PSA = (values[37] != "")? Convert.ToDecimal(values[37]) : 0;
                    match.WHH = (values[38] != "")? Convert.ToDecimal(values[38]) : 0;
                    match.WHD = (values[39] != "")? Convert.ToDecimal(values[39]) : 0;
                    match.WHA = (values[40] != "")? Convert.ToDecimal(values[40]) : 0;
                    match.VCH = (values[41] != "")? Convert.ToDecimal(values[41]) : 0;
                    match.VCD = (values[42] != "")? Convert.ToDecimal(values[42]) : 0;
                    match.VCA = (values[43] != "") ? Convert.ToDecimal(values[43]) : 0;
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

                reader.Dispose();
            }

            using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
            {
                mainSoccerDb.Matches.AddRange(newMatches);
                mainSoccerDb.SaveChanges();
                mainSoccerDb.Dispose();
            }
        }
        #endregion
    }
}
