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
    public class BestPossiblePositionTest
    {
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

        [TestMethod]
        public void BelgiumTest()
        {
            using (EuropeanSoccerEntities soccerDb = new EuropeanSoccerEntities())
            {
                LeagueService leagueService = new LeagueService(soccerDb);
                MatchService matchService = new MatchService(soccerDb);
                string leagueName = "Belgium Jupiler League";
                string season = "2008/2009";
                int stage = 32;

                LeagueStandingService leagueStandingService = new LeagueStandingService(soccerDb, leagueName, season);

                List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
                leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[4].TeamApiId.Value);
            }
        }

        [TestMethod]
        public void GermanyBasicTest()
        {
            using (EuropeanSoccerEntities soccerDb = new EuropeanSoccerEntities())
            {
                LeagueService leagueService = new LeagueService(soccerDb);
                MatchService matchService = new MatchService(soccerDb);
                string leagueName = "Germany 1. Bundesliga";
                string season = "2010/2011";
                int stage = 33;

                LeagueStandingService leagueStandingService = new LeagueStandingService(soccerDb, leagueName, season);

                List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
                Assert.AreEqual(1, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[0].TeamApiId.Value));
                Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[1].TeamApiId.Value));
                Assert.AreEqual(2, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[2].TeamApiId.Value));
                Assert.AreEqual(4, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[3].TeamApiId.Value));
                Assert.AreEqual(4, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[4].TeamApiId.Value));
                Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[5].TeamApiId.Value));
                Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[6].TeamApiId.Value));
                Assert.AreEqual(6, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[7].TeamApiId.Value));
                Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[8].TeamApiId.Value));
                Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[9].TeamApiId.Value));
                Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[10].TeamApiId.Value));
                Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[11].TeamApiId.Value));
                Assert.AreEqual(7, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[12].TeamApiId.Value));

                // Hier 10ter, da Bremen oder Kaiserslautern Punkte bekommen müssen
                Assert.AreEqual(10, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[13].TeamApiId.Value));
                Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[14].TeamApiId.Value));
                Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[15].TeamApiId.Value));
                Assert.AreEqual(15, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[16].TeamApiId.Value));
                Assert.AreEqual(18, leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standing, standing[17].TeamApiId.Value));
            }
        }
    }
}
