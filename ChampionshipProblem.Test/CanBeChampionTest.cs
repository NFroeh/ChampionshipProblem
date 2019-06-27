using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChampionshipProblem.Test
{
    /// <summary>
    /// Methode zum testen des Algorithmus, ob eine Mannschaft noch Meister werden kann.
    /// </summary>
    [TestClass]
    public class CanBeChampionTest
    {
        #region Season1991Test
        /// <summary>
        /// Testet mit der Saison von 1991.
        /// </summary>
        [TestMethod]
        public void Season1991Test()
        {
            List<LeagueStandingEntry> leagueStandingEntries = TestUtils.GenerateSeason1991Standing();
            List<RemainingMatch> remainingMatches = TestUtils.GenerateSeason1991RemaingMatches();

            LeagueStandingService.PrintLeagueStanding(leagueStandingEntries);

            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 1, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 2, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 3, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 4, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 5, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 6, 3, false));
        }
        #endregion

        #region BelgiumTest
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void BelgiumTest()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);
            string leagueName = "Belgium Jupiler League";
            string season = "2008/2009";
            int stage = 32;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false);
        }
        #endregion
    }
}
