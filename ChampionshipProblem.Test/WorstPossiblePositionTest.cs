using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChampionshipProblem.Test
{
    [TestClass]
    public class WorstPossiblePositionTest
    {
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
            leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[4].TeamApiId.Value);
        }

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
            Assert.AreEqual(1, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[0].TeamApiId.Value));
            Assert.AreEqual(3, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[1].TeamApiId.Value));
            Assert.AreEqual(3, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[2].TeamApiId.Value));
            Assert.AreEqual(5, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[3].TeamApiId.Value));
            Assert.AreEqual(5, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[4].TeamApiId.Value));
            Assert.AreEqual(8, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[5].TeamApiId.Value));

            // HSV ist 12, da Kaiserslautern gegen Bremen spielt und so HSV nur von einem der beiden überholt werden kann
            Assert.AreEqual(12, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[6].TeamApiId.Value));
            Assert.AreEqual(12, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[7].TeamApiId.Value));

            // Da Köln gegen Schalke spielt, kann nur einer dieser Vereine die folgenden Vereine noch überholen
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[8].TeamApiId.Value));
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[9].TeamApiId.Value));
            Assert.AreEqual(13, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[10].TeamApiId.Value));
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[11].TeamApiId.Value));
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[12].TeamApiId.Value));
            Assert.AreEqual(14, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[13].TeamApiId.Value));
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[14].TeamApiId.Value));
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[15].TeamApiId.Value));
            Assert.AreEqual(17, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[16].TeamApiId.Value));
            Assert.AreEqual(18, leagueStandingService.CalculateWorstPossibleFinalPositionForTeam(stage, standing, standing[17].TeamApiId.Value));
        }
    }
}
