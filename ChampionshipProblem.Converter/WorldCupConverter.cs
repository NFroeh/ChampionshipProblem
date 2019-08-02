namespace ChampionshipProblem.Converter
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.WorldCup;
    using ChampionshipProblem.DatabaseFiles;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Klasse konvertiert die WorldCups in die vorgegebene Struktur.
    /// </summary>

    public class WorldCupConverter
    {
        #region consts
        /// <summary>
        /// Pfad zum Ordner des Excel-Ordners.
        /// </summary>
        private const string PathToExcelFolder = "C:\\Users\\NicolaiFröhlig\\source\\repos\\ChampionshipProblem\\ChampionshipProblem.Converter\\ExcelFiles\\WorldCup\\";
        #endregion

        /// <summary>
        /// Methode konvertiert die WorldCups in die neue SoccerDb.
        /// </summary>
        public static void ConvertWorldCups()
        {
            string excelPath = PathToExcelFolder + "WorldCups.csv";
            List<WorldCup> worldCups = new List<WorldCup>();
            using (var worldCupReader = new StreamReader(excelPath))
            {
                // Werte und Zeile holen (Erste Zeile überspringen)
                worldCupReader.ReadLine();

                while (!worldCupReader.EndOfStream)
                {
                    string line = worldCupReader.ReadLine();
                    string[] values = line.Split(',');
                    string year = values[0];
                    string country = values[1];

                    worldCups.Add(new WorldCup()
                    {
                        Name = $"{year} {country}",
                        Year = year,
                        CountryName = country
                    });
                }

                worldCupReader.Dispose();
            }

            string matchesPath = PathToExcelFolder + "WorldCupMatches.csv";
            List<Classes.Team> teams = new List<Classes.Team>();
            List<WorldCupMatch> matches = new List<WorldCupMatch>();

            using (var matchesReader = new StreamReader(matchesPath))
            {
                // Werte und Zeile holen (Erste Zeile überspringen)
                matchesReader.ReadLine();

                while (!matchesReader.EndOfStream)
                {
                    string line = matchesReader.ReadLine();
                    string[] values = line.Split(',');
                    string year = values[0];
                    string dateTime = values[1];
                    string groupStage = values[2];
                    // stadium
                    // city
                    string homeTeamName = values[5];
                    string homeTeamGoals = values[6];
                    string awayTeamGoals = values[7];
                    string awayTeamName = values[8];

                    if (!teams.Any((t) => t.Name == homeTeamName))
                    {
                        teams.Add(new Classes.Team()
                        {
                            Name = homeTeamName
                        });
                    }

                    if (!teams.Any((t) => t.Name == awayTeamName))
                    {
                        teams.Add(new Classes.Team()
                        {
                            Name = awayTeamName
                        });
                    }
                }

                matchesReader.Dispose();
            }

            // WorldCups und Teams abspeichern
            using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
            {
                mainSoccerDb.WorldCups.AddRange(worldCups);
                mainSoccerDb.Teams.AddRange(teams);
                mainSoccerDb.SaveChanges();
                mainSoccerDb.Dispose();
            }

            using (var matchesReader = new StreamReader(matchesPath))
            {
                // Werte und Zeile holen (Erste Zeile überspringen)
                matchesReader.ReadLine();

                while (!matchesReader.EndOfStream)
                {
                    string line = matchesReader.ReadLine();
                    string[] values = line.Split(',');
                    string year = values[0];
                    string dateTime = values[1];
                    string groupStage = values[2];
                    // stadium
                    // city
                    string homeTeamName = values[5];
                    string homeTeamGoals = values[6];
                    string awayTeamGoals = values[7];
                    string awayTeamName = values[8];

                    GroupStage wcStage = GroupStage.None;
                    switch (groupStage)
                    {
                        case "Group 1":
                        case "Group A":
                            wcStage = GroupStage.GroupA;
                            break;
                        case "Group 2":
                        case "Group B":
                            wcStage = GroupStage.GroupB;
                            break;
                        case "Group 3":
                        case "Group C":
                            wcStage = GroupStage.GroupC;
                            break;
                        case "Group 4":
                        case "Group D":
                            wcStage = GroupStage.GroupD;
                            break;
                        case "Group 5":
                        case "Group E":
                            wcStage = GroupStage.GroupE;
                            break;
                        case "Group 6":
                        case "Group F":
                            wcStage = GroupStage.GroupF;
                            break;
                        case "Group 7":
                        case "Group G":
                            wcStage = GroupStage.GroupG;
                            break;
                        case "Group 8":
                        case "Group H":
                            wcStage = GroupStage.GroupH;
                            break;
                        case "Round of 16":
                        case "First round":
                        case "Preliminary round":
                            wcStage = GroupStage.RoundOf16;
                            break;
                        case "Quarter-finals":
                            wcStage = GroupStage.Quarterfinal;
                            break;
                        case "Semi-finals":
                            wcStage = GroupStage.Semifinal;
                            break;
                        case "Match for third place":
                        case "Play-off for third place":
                        case "Third place":
                            wcStage = GroupStage.ThirdPlaceMatch;
                            break;
                        case "Final":
                            wcStage = GroupStage.Final;
                            break;
                    }

                    string[] dateValues = dateTime.Split(' ');
                    int day = Convert.ToInt32(Regex.Replace(dateValues[0], "[^0-9]", ""));
                    int dateYear = Convert.ToInt32(year);
                    int monthIndex = 1;
                    string[] time = dateValues[4].Split(':');
                    int hour = Convert.ToInt32(time[0]);
                    int minutes = Convert.ToInt32(time[1]);
                    switch (dateValues[1])
                    {
                        case "May":
                            monthIndex = 5;
                            break;
                        case "Jun":
                        case "June":
                            monthIndex = 6;
                            break;
                        case "Jul":
                        case "July":
                            monthIndex = 7;
                            break;
                    }
                    DateTime date = new DateTime(dateYear, monthIndex, day, hour, minutes, 0);
                    matches.Add(new WorldCupMatch()
                    {
                        WorldCupId = worldCups.Single((wc) => wc.Year == year).Id,
                        HomeId = teams.Single((t) => t.Name == homeTeamName).Id,
                        AwayId = teams.Single((t) => t.Name == awayTeamName).Id,
                        HomeGoals = Convert.ToInt32(homeTeamGoals),
                        AwayGoals = Convert.ToInt32(awayTeamGoals),
                        GroupStage = wcStage,
                        Date = date
                    });
                }

                matchesReader.Dispose();
            }

            using (MainSoccerDb mainSoccerDb = new MainSoccerDb())
            {
                mainSoccerDb.WorldCupMatches.AddRange(matches);
                mainSoccerDb.SaveChanges();
                mainSoccerDb.Dispose();
            }
        }
    }
}
