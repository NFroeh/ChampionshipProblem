namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.ResultClasses;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// Klasse repräsentiert Methoden zum Verwalten von <see cref="LeagueStandingEntry"/>.
    /// </summary>
    public class LeagueStandingService
    {
        #region fields
        /// <summary>
        /// Die Daten.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel { get; set; }

        /// <summary>
        /// Die Liganummer.
        /// </summary>
        public int LeagueId { get; set; }

        /// <summary>
        /// Die Saison der Liga.
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// Die Liga als Entität.
        /// </summary>
        public League League { get; set; }

        /// <summary>
        /// Die Mannschaften
        /// </summary>
        public IEnumerable<Team> Teams { get; set; }

        /// <summary>
        /// Der Service für die beste Position.
        /// </summary>
        internal BestPossiblePositionService BestPossiblePositionService { get; set; }

        /// <summary>
        /// Der Service für die schlechteste Position.
        /// </summary>
        internal WorstPossiblePositionService WorstPossiblePositionService { get; set; }
        
        /// <summary>
        /// Der Service für die Meisterfrage.
        /// </summary>
        internal ChampionService ChampionService { get; set; }
        #endregion

        #region LeagueStandingService
        /// <summary>
        /// Konstruktor zum Erstellen der Klasse.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage.</param>
        /// <param name="soccerDb">Die Datenbankverbindung.</param>
        /// <param name="country">Das Land.</param>
        /// <param name="leagueName">Der Name der Liga.</param>
        /// <param name="season">Die Saison.</param>
        public LeagueStandingService(ChampionshipViewModel championshipViewModel, Country country, string leagueName, string season)
        {
            // Parameter merken und ermitteln
            this.ChampionshipViewModel = championshipViewModel;
            this.League = this.ChampionshipViewModel.LeagueService.GetLeagueByNameAndCountry(leagueName, country);
            this.LeagueId = this.League.Id;
            this.Season = season;
            this.Teams = this.ChampionshipViewModel.TeamService.GetTeamsByLeagueAndSeason(this.League.Id, season);
            this.BestPossiblePositionService = new BestPossiblePositionService(this.ChampionshipViewModel, this.League, this.LeagueId, this.Season, this);
            this.WorstPossiblePositionService = new WorstPossiblePositionService(this.ChampionshipViewModel, this.League, this.LeagueId, this.Season, this);
            this.ChampionService = new ChampionService(this.ChampionshipViewModel, this.League, this.LeagueId, this.Season, this);
        }
        #endregion

        #region CalculateBestPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der besten möglichen Position für ein Team zu einem bestimmten Spieltag in der LIga.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die bestmögliche Position.</returns>
        public PositionComputationalResult CalculateBestPossibleFinalPositionForTeam(int stage, int teamId, bool computeStanding)
        {
            return this.BestPossiblePositionService.CalculateBestPossibleFinalPositionForTeam(stage, teamId, computeStanding);
        }
        #endregion

        #region CalculateBestPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der besten möglichen Position eines Teams.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die bestmögliche Position</returns>
        public static PositionComputationalResult CalculateBestPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, int teamId, int numberOfMissingStages, bool computeStanding)
        {
            return BestPossiblePositionService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, teamId, numberOfMissingStages, computeStanding);
        }
        #endregion

        #region CalculateWorstPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der schlechtmöglichsten Position für ein Team zu einem bestimmten Spieltag in der Liga.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die schlechtmöglichste Position.</returns>
        public PositionComputationalResult CalculateWorstPossibleFinalPositionForTeam(int stage, int teamId, bool computeStanding)
        {
            return this.WorstPossiblePositionService.CalculateWorstPossibleFinalPositionForTeam(stage, teamId, computeStanding);
        }
        #endregion

        #region CalculateWorstPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der schlechtmöglichsten Position eines Teams.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die schlechtmöglichste Position</returns>
        public static PositionComputationalResult CalculateWorstPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, int teamId, int numberOfMissingStages, bool computeStanding)
        {
            return WorstPossiblePositionService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, teamId, numberOfMissingStages, computeStanding);
        }
        #endregion

        #region CalculateIfTeamCanWinChampionship
        /// <summary>
        /// Methode zum Ermitteln, ob eine bestimmte Mannschaft noch Meister werden kann.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public ChampionComputationalResult CalculateIfTeamCanWinChampionship(int stage, int teamId, bool computeStanding)
        {
            return this.ChampionService.CalculateIfTeamCanWinChampionship(stage, teamId, computeStanding);
        }
        #endregion

        #region CalculateIfTeamCanWinChampionship
        /// <summary>
        /// Methode zum Ermitteln, ob ein bestimmtes Team noch meister werden kann.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public static ChampionComputationalResult CalculateIfTeamCanWinChampionship(List<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, int teamId, int numberOfMissingStages, bool computeStanding)
        {
            return ChampionService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, teamId, numberOfMissingStages, computeStanding);
        }
        #endregion

        #region CalculateStanding
        /// <summary>
        /// Methode zum Ermitteln der Tabelle für eine Liga anhand des Spieltags.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die Liste der Tabelle.</returns>
        public List<LeagueStandingEntry> CalculateStanding(int stage)
        {
            // Entitäten und Services erzeugen
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();

            // Die Liga ermitteln
            League currentLeague = this.ChampionshipViewModel.LeagueService.GetLeague(this.LeagueId);

            // Für jedes Team einen Eintrag anlegen
            foreach (Team team in this.Teams)
            {
                LeagueStandingEntry entry = new LeagueStandingEntry(team.Id, team.Name);
                leagueStandings.Add(entry);
            }

            // Die Spiele ermitteln
            IEnumerable<Match> matchesTilStage = this.ChampionshipViewModel.MatchService.GetMatchesUntilStage(this.LeagueId, this.Season, stage);

            // Die Spiele durchlaufen und werten
            foreach (Match match in matchesTilStage)
            {
                LeagueStandingEntry home = leagueStandings.Single((entry) => entry.TeamId == match.HomeId);
                LeagueStandingEntry away = leagueStandings.Single((entry) => entry.TeamId == match.AwayId);

                if (match.HomeGoals > match.AwayGoals)
                {
                    home.Points += 3;
                }
                else if (match.HomeGoals < match.AwayGoals)
                {
                    away.Points += 3;
                }
                else
                {
                    home.Points += 1;
                    away.Points += 1;
                }

                home.Games++;
                away.Games++;
                home.Goals += (int)match.HomeGoals;
                home.GoalsConceded += (int)match.AwayGoals;
                away.Goals += (int)match.AwayGoals;
                away.GoalsConceded += (int)match.HomeGoals;
            }

            leagueStandings = leagueStandings
                .OrderByDescending((entry) => entry.Points)
                .ThenByDescending((entry) => entry.Goals - entry.GoalsConceded)
                .ThenByDescending((entry) => entry.Goals)
                .ToList();

            return leagueStandings;
        }
        #endregion

        #region CalculateCompleteStanding
        /// <summary>
        /// Methode zum Ermitteln der kompletten Tabelle für eine Liga anhand des Spieltags.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die Liste der Tabelle.</returns>
        public List<CompleteLeagueStandingEntry> CalculateCompleteStanding(int stage)
        {
            // Entitäten und Services erzeugen
            List<CompleteLeagueStandingEntry> leagueStandings = new List<CompleteLeagueStandingEntry>();

            // Die Liga ermitteln
            League currentLeague = this.ChampionshipViewModel.LeagueService.GetLeague(this.LeagueId);

            // Für jedes Team einen Eintrag anlegen
            foreach (Team team in this.Teams)
            {
                CompleteLeagueStandingEntry entry = new CompleteLeagueStandingEntry((int)team.Id, team.Name);
                leagueStandings.Add(entry);
            }

            // Die Spiele ermitteln
            IEnumerable<Match> matchesTilStage = this.ChampionshipViewModel.MatchService.GetMatchesUntilStage(this.LeagueId, this.Season, stage);

            // Die Spiele durchlaufen und werten
            foreach (Match match in matchesTilStage)
            {
                CompleteLeagueStandingEntry home = leagueStandings.Single((entry) => entry.TeamId == match.HomeId);
                CompleteLeagueStandingEntry away = leagueStandings.Single((entry) => entry.TeamId == match.AwayId);

                if (match.HomeGoals > match.AwayGoals)
                {
                    home.Points += 3;
                    home.Wins++;
                    away.Losses++;
                }
                else if (match.HomeGoals < match.AwayGoals)
                {
                    home.Losses++;
                    away.Points += 3;
                    away.Wins++;
                }
                else
                {
                    home.Ties++;
                    home.Points += 1;
                    away.Ties++;
                    away.Points += 1;
                }

                home.Games++;
                home.Goals += match.HomeGoals;
                home.GoalsConceded += match.AwayGoals;
                away.Games++;
                away.Goals += match.AwayGoals;
                away.GoalsConceded += match.HomeGoals;
            }

            foreach (CompleteLeagueStandingEntry entry in leagueStandings)
            {
                entry.GoalDifference = entry.Goals - entry.GoalsConceded;
            }

            leagueStandings = leagueStandings
                .OrderByDescending((entry) => entry.Points)
                .ThenByDescending((entry) => entry.Goals - entry.GoalsConceded)
                .ThenByDescending((entry) => entry.Goals)
                .ToList();

            // Position für die Anzeige setzen
            for (int entryIndex = 0; entryIndex < leagueStandings.Count(); entryIndex++)
            {
                leagueStandings.ElementAt(entryIndex).Position = entryIndex + 1;
            }

            return leagueStandings;
        }
        #endregion

        #region PrintLeagueStanding
        /// <summary>
        /// Methode zum Ausgeben der Tabelle auf der Konsole.
        /// </summary>
        /// <param name="leagueStandingEntries">Die Tabelle.</param>
        public static void PrintLeagueStanding(IEnumerable<LeagueStandingEntry> leagueStandingEntries)
        {
            int i = 1;
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                Debug.WriteLine(string.Format("{0, -3}", i + ".") + string.Format("{0, -25}", entry.Name) + " - " +
                    string.Format("{0, -2}", entry.Goals) + ":" + string.Format("{0, -2}", entry.GoalsConceded) + " (" + string.Format("{0, -3}", entry.Goals - entry.GoalsConceded) + ")"
                    + " - " + string.Format("{0, -3}", entry.Points));
                i++;
            }
        }
        #endregion

        #region CalculateLeagueStandingForRemainingMatches
        /// <summary>
        /// Methode zum Ermitteln der Tabelle für eine bestimmte Tabelle und den fehlenden Spielen und deren Ergebnissen.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <returns>Die Tabelle als Liste.</returns>
        public static List<LeagueStandingEntry> CalculateLeagueStandingForRemainingMatches(IEnumerable<ILeagueStandingEntry> leagueStandingEntries, IEnumerable<RemainingMatch> remainingMatches)
        {
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();

            // Liste befüllen
            foreach (ILeagueStandingEntry entry in leagueStandingEntries)
            {
                LeagueStandingEntry newEntry = new LeagueStandingEntry(entry.TeamId, entry.Name)
                {
                    Points = entry.Points,
                    Games = entry.Games
                };

                leagueStandings.Add(newEntry);
            }

            foreach(RemainingMatch remainingMatch in remainingMatches)
            {
                LeagueStandingEntry homeTeam = leagueStandings.Single((entry) => entry.TeamId == remainingMatch.HomeTeamId);
                LeagueStandingEntry awayTeam = leagueStandings.Single((entry) => entry.TeamId == remainingMatch.AwayTeamId);
                homeTeam.Games++;
                awayTeam.Games++;
                switch (remainingMatch.MatchResult)
                {
                    case MatchResult.Tie:
                        homeTeam.Points += 1;
                        awayTeam.Points += 1;
                        break;
                    case MatchResult.WinHome:
                        homeTeam.Points += 3;
                        break;
                    case MatchResult.WinGuest:
                        awayTeam.Points += 3;
                        break;
                }
            }

            leagueStandings = leagueStandings
                .OrderByDescending((entry) => entry.Points)
                .ThenBy((entry) => entry.Name)
                .ToList();

            return leagueStandings;
        }
        #endregion

        #region CalculateNumberOfRemainingMatchesForBestPossiblePosition
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="teamApiId"></param>
        public int CalculateNumberOfRemainingMatchesForBestPossiblePosition(int stage, int teamId)
        {
            return this.BestPossiblePositionService.CalculateNumberOfRemainingMatchesForBestPossiblePosition(stage, teamId);
        }
        #endregion

        #region CalculateNumberOfRemainingMatchesForWorstPossiblePosition
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        public int CalculateNumberOfRemainingMatchesForWorstPossiblePosition(int stage, int teamId)
        {
            return WorstPossiblePositionService.CalculateNumberOfRemainingMatchesForWorstPossiblePosition(stage, teamId);
        }
        #endregion

        #region CalculateNumberOfRemainingMatchesForChampion
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="teamId">Die Id des Teams..</param>
        public int CalculateNumberOfRemainingMatchesForChampion(int stage, int teamId)
        {
            return ChampionService.CalculateNumberOfRemainingMatchesForChampion(stage, teamId);
        }
        #endregion
    }
}
