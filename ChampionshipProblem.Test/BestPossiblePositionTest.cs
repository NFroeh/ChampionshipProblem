using ChampionshipProblem.Classes;
using ChampionshipProblem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChampionshipProblem.Test
{
    /// <summary>
    /// Klasse zum Testen der BestPossiblePositions-Algorithmus.
    /// </summary>
    [TestClass]
    public class BestPossiblePositionTest
    {
        #region Season1991Test
        /// <summary>
        /// Testen mit der Saison von 1991.
        /// </summary>
        [TestMethod]
        public void Season1991Test()
        {
            IEnumerable<LeagueStandingEntry> leagueStandingEntries = TestUtils.GenerateSeason1991Standing();
            List<RemainingMatch> remainingMatches = TestUtils.GenerateSeason1991RemaingMatches();

            LeagueStandingService.PrintLeagueStanding(leagueStandingEntries);

            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 1, 5));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 2, 5));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 3, 5));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 4, 5));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 5, 5));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 6, 5));
        }
        #endregion

        #region BelgiumTest
        /// <summary>
        /// Testen mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void BelgiumTest()
        {
            // Datengrundlage erstellen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);
            string leagueName = "Belgium Jupiler League";
            string season = "2008/2009";
            int stage = 32;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[4].TeamApiId.Value);
        }
        #endregion

        #region GermanyBasicTest
        /// <summary>
        /// Testen mit der Liga von Deutschland.
        /// </summary>
        [TestMethod]
        public void GermanyBasicTest()
        {
            // Datengrundlage erstellen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);
            string leagueName = "Germany 1. Bundesliga";
            string season = "2010/2011";
            int stage = 33;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(1, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[0].TeamApiId.Value));
            Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[1].TeamApiId.Value));
            Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[2].TeamApiId.Value));
            Assert.AreEqual(4, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[3].TeamApiId.Value));
            Assert.AreEqual(4, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[4].TeamApiId.Value));
            Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[5].TeamApiId.Value));
            Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[6].TeamApiId.Value));
            Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[7].TeamApiId.Value));
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[8].TeamApiId.Value));
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[9].TeamApiId.Value));
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[10].TeamApiId.Value));
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[11].TeamApiId.Value));
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[12].TeamApiId.Value));

            // Hier 10ter, da Bremen oder Kaiserslautern Punkte bekommen müssen
            Assert.AreEqual(10, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[13].TeamApiId.Value));
            Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[14].TeamApiId.Value));
            Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[15].TeamApiId.Value));
            Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[16].TeamApiId.Value));
            Assert.AreEqual(18, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[17].TeamApiId.Value));
        }
        #endregion

        #region FranceBasicTest
        /// <summary>
        /// Testen mit der Liga von Frankreich.
        /// </summary>
        [TestMethod]
        public void FranceBasicTest()
        {
            // Datengrundlage erstellen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);
            string leagueName = "France Ligue 1";
            string season = "2008/2009";
            int stage = 33;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(1, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[5].TeamApiId.Value));
            //Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[6].TeamApiId.Value));
            //Assert.AreEqual(3, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[7].TeamApiId.Value));
        }
        #endregion
    }
}
