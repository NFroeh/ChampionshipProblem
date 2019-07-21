﻿namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasse repräsentiert den Service für die Mannschaften.
    /// </summary>
    public class TeamService
    {
        #region fields
        /// <summary>
        /// Die Datengrundlage.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel { get; set; }
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Services.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage.</param>
        public TeamService(ChampionshipViewModel championshipViewModel)
        {
            ChampionshipViewModel = championshipViewModel;
        }
        #endregion

        #region GetTeamsByLeagueAndSeason
        /// <summary>
        /// Ermitteln der Mannschaften anhand der Liga und der Saison.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <returns>Die Mannschaften.</returns>
        public IEnumerable<Team> GetTeamsByLeagueAndSeason(long leagueId, string season)
        {
            IEnumerable<Match> matches = ChampionshipViewModel.MatchService.GetMatchesByLeagueAndSeason(leagueId, season);
            List<Team> teams = new List<Team>();
            foreach(Match match in matches)
            {
                Team homeTeam = this.GetTeamById(match.HomeId);
                Team awayTeam = this.GetTeamById(match.AwayId);

                if (!teams.Contains(homeTeam)) teams.Add(homeTeam);
                if (!teams.Contains(awayTeam)) teams.Add(awayTeam);
            }

            return teams;
        }
        #endregion

        #region GetNumberOfTeamsByLeagueAndSeason
        /// <summary>
        /// Ermittelt die Anzahl der Mannschaften anhand der Liga und der Saison
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <returns>Die Anzahl der Mannschaften.</returns>
        public int GetNumberOfTeamsByLeagueAndSeason(long leagueId, string season)
        {
            return this.GetTeamsByLeagueAndSeason(leagueId, season).Count();
        }
        #endregion

        #region GetTeamById
        /// <summary>
        /// Methode zum Ermitteln einer Mannschaft anhand der Id.
        /// </summary>
        /// <param name="teamId">Die TeamApiId.</param>
        /// <returns>Die Mannschaft.</returns>
        public Team GetTeamById(int teamId)
        {
            return ChampionshipViewModel.Teams.Single((team) => team.Id == teamId);
        }
        #endregion

        #region GetIdNameCollectionByLeagueAndSeason
        /// <summary>
        /// Methode zum Ermitteln der Zuordnung der TeamId zu dem Namen eines Teams.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <returns>Die Zuordnung der TeamApiId zum Namen.</returns>
        public Dictionary<int, string> GetIdNameCollectionByLeagueAndSeason(int leagueId, string season)
        {
            IEnumerable<Team> teams = this.GetTeamsByLeagueAndSeason(leagueId, season);
            Dictionary<int, string> idNameCollection = new Dictionary<int, string>();

            foreach(Team team in teams)
            {
                idNameCollection.Add(team.Id, team.Name);
            }

            return idNameCollection;
        }
        #endregion
    }
}
