﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChampionshipProblem.Test
{
    [TestClass]
    public class CanBeChampionTest
    {
        [TestMethod]
        public void Season1991Test()
        {
            IEnumerable<LeagueStandingEntry> leagueStandingEntries = TestUtils.GenerateSeason1991Standing();
            List<RemainingMatch> remainingMatches = TestUtils.GenerateSeason1991RemaingMatches();

            LeagueStandingService.PrintLeagueStanding(leagueStandingEntries);

            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 1, 5));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 2, 5));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 3, 5));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 4, 5));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 5, 5));
            Debug.WriteLine(LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, 6, 5));
        }

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
            leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[4].TeamApiId.Value);
        }

        [TestMethod]
        public void GermanyBasicTest()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);
            string leagueName = "Germany 1. Bundesliga";
            string season = "2008/2009";
            int stage = 29;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[0].TeamApiId.Value));
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[1].TeamApiId.Value));
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[2].TeamApiId.Value));
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[3].TeamApiId.Value));
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[4].TeamApiId.Value));
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[5].TeamApiId.Value));
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[6].TeamApiId.Value));
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[7].TeamApiId.Value));

            // Von der Punktezahl zwar noch möglich, kann Leverkusen aber kein Meister werden, da Wolfsburg alles verlieren müsste.
            // Da Wolfsburg noch gegen Stuttgart spielt, muss danach Stuttgart alles verlieren. Da aber Stuttgart noch gegen München spielt, 
            // hat min. 1 dieser Mannschaften mehr Punkte als Leverkusen
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[8].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[9].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[10].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[11].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[12].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[13].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[14].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[15].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[16].TeamApiId.Value));
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing, standing[17].TeamApiId.Value));
        }
    }
}
