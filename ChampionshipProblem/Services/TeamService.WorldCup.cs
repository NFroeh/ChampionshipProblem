namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.WorldCup;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Klasse repräsentiert den TeamService für den WorldCup.
    /// </summary>
    public partial class TeamService
    {
        #region GetTeamsByWorldCupId
        /// <summary>
        /// Ermitteln der Mannschaften anhand der Liga und der Saison.
        /// </summary>
        /// <param name="worldCupId">Die Id des WorldCups</param>
        /// <returns>Die Mannschaften.</returns>
        public IEnumerable<Team> GetTeamsByWorldCupId(long worldCupId)
        {
            IEnumerable<WorldCupMatch> matches = ChampionshipViewModel.MatchService.GetMatchesByWorldCupId(worldCupId);
            List<Team> teams = new List<Team>();
            foreach (WorldCupMatch match in matches)
            {
                Team homeTeam = this.GetTeamById(match.HomeId);
                Team awayTeam = this.GetTeamById(match.AwayId);

                if (!teams.Contains(homeTeam)) teams.Add(homeTeam);
                if (!teams.Contains(awayTeam)) teams.Add(awayTeam);
            }

            return teams;
        }
        #endregion

        #region GetTeamsByWorldCupAndGroup
        /// <summary>
        /// Ermitteln der Mannschaften anhand der Liga und der Saison.
        /// </summary>
        /// <param name="worldCupId">Die Id des WorldCups</param>
        /// <param name="groupStage">Die Gruppe.</param>
        /// <returns>Die Mannschaften.</returns>
        public IEnumerable<Team> GetTeamsByWorldCupAndGroup(long worldCupId, GroupStage groupStage)
        {
            IEnumerable<WorldCupMatch> matches = ChampionshipViewModel.MatchService.GetMatchesByWorldCupId(worldCupId)
                .Where((match) => match.GroupStage == groupStage);
            List<Team> teams = new List<Team>();
            foreach (WorldCupMatch match in matches)
            {
                Team homeTeam = this.GetTeamById(match.HomeId);
                Team awayTeam = this.GetTeamById(match.AwayId);

                if (!teams.Contains(homeTeam)) teams.Add(homeTeam);
                if (!teams.Contains(awayTeam)) teams.Add(awayTeam);
            }

            return teams;
        }
        #endregion

        #region GetIdNameCollectionByWorldCup
        /// <summary>
        /// Methode zum Ermitteln der Zuordnung der TeamId zu dem Namen eines Teams.
        /// </summary>
        /// <param name="worldCupId">Die Id des WorldCups.</param>
        /// <returns>Die Zuordnung der TeamApiId zum Namen.</returns>
        public Dictionary<int, string> GetIdNameCollectionByWorldCup(int worldCupId)
        {
            IEnumerable<Team> teams = this.GetTeamsByWorldCupId(worldCupId);
            Dictionary<int, string> idNameCollection = new Dictionary<int, string>();

            foreach (Team team in teams)
            {
                idNameCollection.Add(team.Id, team.Name);
            }

            return idNameCollection;
        }
        #endregion
    }
}
