namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Scheme;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasse repräsentiert den Service für die SPiele.
    /// </summary>
    public class MatchService
    {
        #region fields
        /// <summary>
        /// Die Datengrundlage.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel { get; set; }
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen der Services.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage.</param>
        public MatchService(ChampionshipViewModel championshipViewModel)
        {
            ChampionshipViewModel = championshipViewModel;
        }
        #endregion

        #region GetMatchesUntilStage
        /// <summary>
        /// Methode zum Ermitteln der Spiele bis zu einem bestimmten Spieltag.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Dia Saison</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns></returns>
        public IEnumerable<Match> GetMatchesUntilStage(long leagueId, string season, int stage)        
        {
            return ChampionshipViewModel.Matches.Where((match) => match.league_id == leagueId && match.season == season && match.stage <= stage);
        }
        #endregion

        #region GetMatchesByLeagueAndSeason
        /// <summary>
        /// Methode zum Ermitteln der Spiele für eine Liga zu einer bestimmten Saison.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <returns>Die Spiele.</returns>
        public IEnumerable<Match> GetMatchesByLeagueAndSeason(long leagueId, string season)
        {
            return ChampionshipViewModel.Matches.Where((match) => match.league_id == leagueId && match.season == season);
        }
        #endregion

        #region GetRemainingMatches
        /// <summary>
        /// Methode zum Ermitteln der fehlenden Spiele ab eines bestimmten Spieltags.
        /// </summary>
        /// <param name="leagueName">Der Liga-Name</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die fehlenden Spiele.</returns>
        public List<RemainingMatch> GetRemainingMatches(string leagueName, string season, int stage)
        {
            return this.GetRemainingMatches(this.ChampionshipViewModel.LeagueService.GetLeagueByName(leagueName).id, season, stage);
        }

        /// <summary>
        /// Methode zum Ermitteln der fehlenden Spiele ab eines bestimmten Spieltags.
        /// </summary>
        /// <param name="leagueId">Der Ligaid</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die fehlenden Spiele.</returns>
        public List<RemainingMatch> GetRemainingMatches(long leagueId, string season, int stage)
        {
            // Services erzeugen
            TeamService teamService = new TeamService(this.ChampionshipViewModel);

            IEnumerable<Match> matchesToConvert = ChampionshipViewModel.Matches.Where((match) => match.league_id == leagueId && match.season == season && match.stage > stage);

            List<RemainingMatch> remainingMatches = new List<RemainingMatch>();
            IEnumerable<Team> teams = teamService.GetTeamsByLeagueAndSeason(leagueId, season);
            Dictionary<long, string> teamNameToId = teamService.GetIdNameCollectionByLeagueAndSeason(leagueId, season);

            foreach (Match match in matchesToConvert)
            {
                RemainingMatch remainingMatch = new RemainingMatch()
                {
                    Id = match.id,
                    MatchApiId = match.match_api_id.Value,
                    CountryId = match.country_id.Value,
                    LeagueId = match.league_id.Value,
                    Season = match.season,
                    Stage = match.stage.Value,
                    Date = match.date,
                    AwayTeamApiId = match.away_team_api_id.Value,
                    AwayTeamGoal = match.away_team_goal.Value,
                    HomeTeamName = teamNameToId[match.home_team_api_id.Value],
                    AwayTeamName = teamNameToId[match.away_team_api_id.Value],
                    HomeTeamApiId = match.home_team_api_id.Value,
                    HomeTeamGoal = match.home_team_goal.Value,
                };
                remainingMatches.Add(remainingMatch);
            }

            return remainingMatches;
        }
        #endregion

        #region GetRemainingMatchesForSingleStage
        /// <summary>
        /// Ermittelt die fehlenden Spiele für einen bestimmten Spieltag.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns></returns>
        public List<RemainingMatch> GetRemainingMatchesForSingleStage(long leagueId, string season, int stage)
        {
            // Spiele ermitteln
            IEnumerable<Match> matchesToConvert = ChampionshipViewModel.Matches.Where((match) => match.league_id == leagueId && match.season == season && match.stage == stage);

            // Anlegen der Liste
            List<RemainingMatch> remainingMatches = new List<RemainingMatch>();

            // Mannschaften ermitteln
            Dictionary<long, string> teamNameToId = this.ChampionshipViewModel.TeamService.GetIdNameCollectionByLeagueAndSeason(leagueId, season);

            // In die neue Klasse konvertieren
            foreach (Match match in matchesToConvert)
            {
                RemainingMatch remainingMatch = new RemainingMatch()
                {
                    Id = match.id,
                    MatchApiId = match.match_api_id.Value,
                    CountryId = match.country_id.Value,
                    LeagueId = match.league_id.Value,
                    Season = match.season,
                    Stage = match.stage.Value,
                    Date = match.date,
                    AwayTeamApiId = match.away_team_api_id.Value,
                    AwayTeamGoal = match.away_team_goal.Value,
                    HomeTeamName = teamNameToId[match.home_team_api_id.Value],
                    AwayTeamName = teamNameToId[match.away_team_api_id.Value],
                    HomeTeamApiId = match.home_team_api_id.Value,
                    HomeTeamGoal = match.home_team_goal.Value,
                };
                remainingMatches.Add(remainingMatch);
            }

            return remainingMatches;
        }
        #endregion

        #region GetNumberOfMatches
        /// <summary>
        /// Methode zum Ermitteln der Anzahl der Spiele einer Saison.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <returns>Die Anzahl der Spieltage.</returns>
        public long GetNumberOfMatches(long leagueId, string season)
        {
            return ChampionshipViewModel.Matches.Where((match) => match.league_id == leagueId && match.season == season).Max((match) => match.stage).Value;
        }
        #endregion

        #region GetSeasonsByLeagueId
        /// <summary>
        /// Methode zum Ermitteln der Saisons einer Liga.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <returns>Die verschiedenen Saisons.</returns>
        public IEnumerable<string> GetSeasonsByLeagueId(long leagueId)
        {
            return ChampionshipViewModel.Matches.Where((match) => match.league_id == leagueId).Select((match) => match.season).Distinct();
        }
        #endregion
    }
}
