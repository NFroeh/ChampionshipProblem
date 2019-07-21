namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Klasse repräsentiert den Service für die Spiele.
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
            return ChampionshipViewModel.Matches.Where((match) => match.LeagueId == leagueId && match.Season == season && match.Stage <= stage);
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
            return ChampionshipViewModel.Matches.Where((match) => match.LeagueId == leagueId && match.Season == season);
        }
        #endregion

        #region GetRemainingMatches
        /// <summary>
        /// Methode zum Ermitteln der fehlenden Spiele ab eines bestimmten Spieltags.
        /// </summary>
        /// <param name="country">Das Land.</param>
        /// <param name="leagueName">Der Liga-Name</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die fehlenden Spiele.</returns>
        public List<RemainingMatch> GetRemainingMatches(Country country, string leagueName, string season, int stage)
        {
            return this.GetRemainingMatches(this.ChampionshipViewModel.LeagueService.GetLeagueByNameAndCountry(leagueName, country).Id, season, stage);
        }

        /// <summary>
        /// Methode zum Ermitteln der fehlenden Spiele ab eines bestimmten Spieltags.
        /// </summary>
        /// <param name="leagueId">Der Ligaid</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die fehlenden Spiele.</returns>
        public List<RemainingMatch> GetRemainingMatches(int leagueId, string season, int stage)
        {
            // Services erzeugen
            TeamService teamService = new TeamService(this.ChampionshipViewModel);

            IEnumerable<Match> matchesToConvert = ChampionshipViewModel.Matches.Where((match) => match.LeagueId == leagueId && match.Season == season && match.Stage > stage);

            List<RemainingMatch> remainingMatches = new List<RemainingMatch>();
            IEnumerable<Team> teams = teamService.GetTeamsByLeagueAndSeason(leagueId, season);
            Dictionary<int, string> teamNameToId = teamService.GetIdNameCollectionByLeagueAndSeason(leagueId, season);

            foreach (Match match in matchesToConvert)
            {
                RemainingMatch remainingMatch = new RemainingMatch()
                {
                    Id = match.Id,
                    Country = match.Country,
                    LeagueId = match.LeagueId,
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

        #region GetRemainingMatchesForSingleStage
        /// <summary>
        /// Ermittelt die fehlenden Spiele für einen bestimmten Spieltag.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns></returns>
        public List<RemainingMatch> GetRemainingMatchesForSingleStage(int leagueId, string season, int stage)
        {
            // Spiele ermitteln
            IEnumerable<Match> matchesToConvert = ChampionshipViewModel.Matches.Where((match) => match.LeagueId == leagueId && match.Season == season && match.Stage == stage);

            // Anlegen der Liste
            List<RemainingMatch> remainingMatches = new List<RemainingMatch>();

            // Mannschaften ermitteln
            Dictionary<int, string> teamNameToId = this.ChampionshipViewModel.TeamService.GetIdNameCollectionByLeagueAndSeason(leagueId, season);

            // In die neue Klasse konvertieren
            foreach (Match match in matchesToConvert)
            {
                RemainingMatch remainingMatch = new RemainingMatch()
                {
                    Id = match.Id,
                    Country = match.Country,
                    LeagueId = match.LeagueId,
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

        #region GetNumberOfMatches
        /// <summary>
        /// Methode zum Ermitteln der Anzahl der Spiele einer Saison.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <returns>Die Anzahl der Spieltage.</returns>
        public int GetNumberOfMatches(int leagueId, string season)
        {
            return ChampionshipViewModel.Matches.Where((match) => match.LeagueId == leagueId && match.Season == season).Max((match) => match.Stage);
        }
        #endregion

        #region GetSeasonsByLeagueId
        /// <summary>
        /// Methode zum Ermitteln der Saisons einer Liga.
        /// </summary>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <returns>Die verschiedenen Saisons.</returns>
        public IEnumerable<string> GetSeasonsByLeagueId(int leagueId)
        {
            return ChampionshipViewModel.Matches.Where((match) => match.LeagueId == leagueId).Select((match) => match.Season).Distinct();
        }
        #endregion
    }
}
