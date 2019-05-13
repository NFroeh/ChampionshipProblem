using ChampionshipProblem.Classes;
using ChampionshipProblem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChampionshipProblem.Test
{
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

            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 1, 5));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 2, 5));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 3, 5));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 4, 5));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 5, 5));
            Debug.WriteLine(LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, 6, 5));
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
            string leagueName = "Belgium Jupiler League";
            string season = "2008/2009";
            int stage = 32;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[4].TeamApiId.Value);
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
            string leagueName = "Germany 1. Bundesliga";
            string season = "2010/2011";
            int stage = 33;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(1, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[0].TeamApiId.Value));
            Assert.AreEqual(3, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[1].TeamApiId.Value));
            Assert.AreEqual(3, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[2].TeamApiId.Value));
            Assert.AreEqual(5, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[3].TeamApiId.Value));
            Assert.AreEqual(5, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[4].TeamApiId.Value));
            Assert.AreEqual(8, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[5].TeamApiId.Value));

            // HSV ist 12, da Kaiserslautern gegen Bremen spielt und so HSV nur von einem der beiden überholt werden kann
            Assert.AreEqual(12, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[6].TeamApiId.Value));
            Assert.AreEqual(12, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[7].TeamApiId.Value));

            // Da Köln gegen Schalke spielt, kann nur einer dieser Vereine die folgenden Vereine noch überholen
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[8].TeamApiId.Value));
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[9].TeamApiId.Value));
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[10].TeamApiId.Value));
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[11].TeamApiId.Value));
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[12].TeamApiId.Value));
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[13].TeamApiId.Value));
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[14].TeamApiId.Value));
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[15].TeamApiId.Value));
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[16].TeamApiId.Value));
            Assert.AreEqual(18, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing[17].TeamApiId.Value));
        }
        #endregion
    }
}
