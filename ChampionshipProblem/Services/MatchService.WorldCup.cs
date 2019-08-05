

namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.WorldCup;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasse enthält Methoden zum Arbeiten mit den WorldCupMatches.
    /// </summary>
    public partial class MatchService
    {
        #region GetMatchesUntilStageByGroupStage
        /// <summary>
        /// Methode zum Ermitteln der Spiele bis zu einem bestimmten Spieltag.
        /// </summary>
        /// <param name="worldCupId">Die WorldCupNummmer.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="groupStage">Der Gruppenspieltag.</param>
        /// <returns></returns>
        public IEnumerable<WorldCupMatch> GetMatchesUntilStage(long worldCupId, int stage, GroupStage groupStage)
        {
            return ChampionshipViewModel.WorldCupMatches.Where((match) => match.WorldCupId == worldCupId && match.Stage <= stage && match.GroupStage == groupStage);
        }
        #endregion

        #region GetMatchesByWorldCupId
        /// <summary>
        /// Methode zum Ermitteln der Spiele für eine Liga zu einer bestimmten Saison.
        /// </summary>
        /// <param name="worldCupId">Die Id des WorldCup.</param>
        /// <returns>Die Spiele.</returns>
        public IEnumerable<WorldCupMatch> GetMatchesByWorldCupId(long worldCupId)
        {
            return ChampionshipViewModel.WorldCupMatches.Where((match) => match.WorldCupId == worldCupId);
        }
        #endregion

        #region GetMatchesByWorldCupIdAndGroupStage
        /// <summary>
        /// Methode zum Ermitteln der Spiele für eine Liga zu einer bestimmten Saison.
        /// </summary>
        /// <param name="worldCupId">Die Id des WorldCup.</param>
        /// <param name="groupStage">Die Gruppenphase.</param>
        /// <returns>Die Spiele.</returns>
        public IEnumerable<WorldCupMatch> GetMatchesByWorldCupIdAndGroupStage(long worldCupId, GroupStage groupStage)
        {
            return ChampionshipViewModel.WorldCupMatches.Where((match) => match.WorldCupId == worldCupId && match.GroupStage == groupStage);
        }
        #endregion

        #region GetNumberOfStages
        /// <summary>
        /// Methode zum Ermitteln der Anzahl der Spiele einer Saison.
        /// </summary>
        /// <param name="worldCupId">Die Id des WorldCups.</param>
        /// <returns>Die Anzahl der Spieltage.</returns>
        public int GetNumberOfStages(int worldCupId)
        {
            return ChampionshipViewModel.WorldCupMatches.Where((match) => match.WorldCupId == worldCupId).Max((match) => match.Stage);
        }
        #endregion

        #region GetRemainingMatchesForSingleStage
        /// <summary>
        /// Ermittelt die fehlenden Spiele für einen bestimmten Spieltag.
        /// </summary>
        /// <param name="worldCupId">Die Id des WorldCups.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns></returns>
        public List<RemainingMatch> GetRemainingMatchesForSingleStage(int worldCupId, int stage)
        {
            // Spiele ermitteln
            IEnumerable<WorldCupMatch> matchesToConvert = ChampionshipViewModel.WorldCupMatches.Where((match) => match.WorldCupId == worldCupId && match.Stage == stage);

            // Anlegen der Liste
            List<RemainingMatch> remainingMatches = new List<RemainingMatch>();

            // Mannschaften ermitteln
            Dictionary<int, string> teamNameToId = this.ChampionshipViewModel.TeamService.GetIdNameCollectionByWorldCup(worldCupId);

            // In die neue Klasse konvertieren
            foreach (WorldCupMatch match in matchesToConvert)
            {
                RemainingMatch remainingMatch = new RemainingMatch()
                {
                    Id = match.Id,
                    Country = match.Country,
                    LeagueId = match.WorldCupId,
                    Season = match.Season,
                    Stage = match.Stage,
                    Date = match.Date,
                    AwayTeamId = match.AwayId,
                    AwayTeamGoal = match.AwayGoals,
                    HomeTeamName = teamNameToId[match.HomeId],
                    AwayTeamName = teamNameToId[match.AwayId],
                    HomeTeamId = match.HomeId,
                    HomeTeamGoal = match.HomeGoals,
                };
                remainingMatches.Add(remainingMatch);
            }

            return remainingMatches;
        }
        #endregion
    }
}
