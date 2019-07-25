namespace ChampionshipProblem.Test
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Diagnostics;

    /// <summary>
    /// Klasse enthält die Tests für den Algorithmus der möglichst schlechten Position eines Teams.
    /// </summary>
    [TestClass]
    public class WorstPossiblePositionTest
    {
        #region Season1991Test
        /// <summary>
        /// Testet mit der Saison von 1991.
        /// </summary>
        [TestMethod]
        public void Season1991Test()
        {
            IEnumerable<LeagueStandingEntry> leagueStandingEntries = TestUtils.GenerateSeason1991Standing();
            List<RemainingMatch> remainingMatches = TestUtils.GenerateSeason1991RemaingMatches();

            LeagueStandingService.PrintLeagueStanding(leagueStandingEntries);

            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 1, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 2, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 3, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 4, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 5, 3, false));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 6, 3, false));
        }
        #endregion

        #region BelgiumTest
        /// <summary>
        /// Testet mit der Liga von Belgien.
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

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, Country.Belgium, League.BelgiumD0LeagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[4].TeamId, false);
        }
        #endregion

        #region GermanyBasicTest
        /// <summary>
        /// Testet mit der Liga von Deutschland.
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

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, Country.Germany, League.GermanyD0LeagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(1, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[0].TeamId, false).Position);
            Assert.AreEqual(3, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[1].TeamId, false).Position);
            Assert.AreEqual(3, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[2].TeamId, false).Position);
            Assert.AreEqual(5, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[3].TeamId, false).Position);
            Assert.AreEqual(5, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[4].TeamId, false).Position);
            Assert.AreEqual(8, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[5].TeamId, false).Position);

            // HSV ist 12, da Kaiserslautern gegen Bremen spielt und so HSV nur von einem der beiden überholt werden kann
            Assert.AreEqual(12, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[6].TeamId, false).Position);
            Assert.AreEqual(12, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[7].TeamId, false).Position);

            // Da Köln gegen Schalke spielt, kann nur einer dieser Vereine die folgenden Vereine noch überholen
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[8].TeamId, false).Position);
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[9].TeamId, false).Position);
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[10].TeamId, false).Position);
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[11].TeamId, false).Position);
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[12].TeamId, false).Position);
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[13].TeamId, false).Position);
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[14].TeamId, false).Position);
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[15].TeamId, false).Position);
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[16].TeamId, false).Position);
            Assert.AreEqual(18, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[17].TeamId, false).Position);
        }
        #endregion
    }
}
