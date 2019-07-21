namespace ChampionshipProblem.Test
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Diagnostics;

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

            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 1, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 2, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 3, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 4, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 5, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 6, 3, false));
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
            string season = "2008/2009";
            int stage = 32;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, Country.Belgium, League.BelgiumLeagueName, season);
            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[4].TeamId, false);
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
            string season = "2010/2011";
            int stage = 33;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, Country.Germany, League.GermanyLeagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(1, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[0].TeamId, false).Position);
            Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[1].TeamId, false).Position);
            Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[2].TeamId, false).Position);
            Assert.AreEqual(4, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[3].TeamId, false).Position);
            Assert.AreEqual(4, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[4].TeamId, false).Position);
            Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[5].TeamId, false).Position);
            Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[6].TeamId, false).Position);
            Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[7].TeamId, false).Position);
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[8].TeamId, false).Position);
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[9].TeamId, false).Position);
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[10].TeamId, false).Position);
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[11].TeamId, false).Position);
            Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[12].TeamId, false).Position);

            // Hier 10ter, da Bremen oder Kaiserslautern Punkte bekommen müssen
            Assert.AreEqual(10, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[13].TeamId, false).Position);
            Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[14].TeamId, false).Position);
            Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[15].TeamId, false).Position);
            Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[16].TeamId, false).Position);
            Assert.AreEqual(18, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[17].TeamId, false).Position);
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
            string season = "2008/2009";
            int stage = 33;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, Country.France, League.FranceLeagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(1, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing[5].TeamId, false).Position);
            //Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[6].TeamId));
            //Assert.AreEqual(3, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[7].TeamId));
        }
        #endregion
    }
}
