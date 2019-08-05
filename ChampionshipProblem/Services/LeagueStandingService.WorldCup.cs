namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.WorldCup;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasse enthält die Methoden des WorldCups des LeagueStandingServices.
    /// </summary>
    public partial class LeagueStandingService
    {
        #region fields
        /// <summary>
        /// Der WorldCup.
        /// </summary>
        public WorldCup WorldCup;
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Services.
        /// </summary>
        /// <param name="championshipViewModel">Die Daten.</param>
        /// <param name="worldCupId">Die Id des WorldCups.</param>
        public LeagueStandingService(ChampionshipViewModel championshipViewModel, int worldCupId)
        {
            this.ChampionshipViewModel = championshipViewModel;
            this.LeagueId = worldCupId;
            this.WorldCup = championshipViewModel.LeagueService.GetWorldCup(worldCupId);
            this.Teams = this.ChampionshipViewModel.TeamService.GetTeamsByWorldCupId(this.WorldCup.Id);
        }
        #endregion

        #region CalculateStanding
        /// <summary>
        /// Methode zum Ermitteln der Tabelle für eine Liga anhand des Spieltags.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="groupStage">Der Gruppenspieltag.</param>
        /// <returns>Die Liste der Tabelle.</returns>
        public List<LeagueStandingEntry> CalculateStanding(int stage, GroupStage groupStage)
        {
            // Entitäten und Services erzeugen
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();

            // Die Spiele und Teams ermitteln
            IEnumerable<WorldCupMatch> matchesTilStage = this.ChampionshipViewModel.MatchService.GetMatchesUntilStage(this.LeagueId, stage, groupStage);
            IEnumerable<Team> teamsInGroupStage = this.ChampionshipViewModel.TeamService.GetTeamsByWorldCupAndGroup(this.LeagueId, groupStage);

            // Für jedes Team einen Eintrag anlegen
            foreach (Team team in teamsInGroupStage)
            {
                LeagueStandingEntry entry = new LeagueStandingEntry(team.Id, team.Name);
                leagueStandings.Add(entry);
            }

            // Die Spiele durchlaufen und werten
            foreach (WorldCupMatch match in matchesTilStage)
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
        /// <param name="groupStage">Der Gruppenspieltag.</param>
        /// <returns>Die Liste der Tabelle.</returns>
        public List<CompleteLeagueStandingEntry> CalculateCompleteStanding(int stage, GroupStage groupStage)
        {
            List<CompleteLeagueStandingEntry> leagueStandings = new List<CompleteLeagueStandingEntry>();
            
            // Die Spiele ermitteln
            IEnumerable<WorldCupMatch> matchesTilStage = this.ChampionshipViewModel.MatchService.GetMatchesUntilStage(this.LeagueId, stage, groupStage);
            IEnumerable<Team> teamsInGroupStage = this.ChampionshipViewModel.TeamService.GetTeamsByWorldCupAndGroup(this.LeagueId, groupStage);

            // Für jedes Team einen Eintrag anlegen
            foreach (Team team in teamsInGroupStage)
            {
                CompleteLeagueStandingEntry entry = new CompleteLeagueStandingEntry((int)team.Id, team.Name);
                leagueStandings.Add(entry);
            }

            // Die Spiele durchlaufen und werten
            foreach (WorldCupMatch match in matchesTilStage)
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
    }
}
