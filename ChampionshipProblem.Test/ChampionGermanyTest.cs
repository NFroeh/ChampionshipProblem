﻿using System;
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
    public class ChampionGermanyTest
    {
        #region G0809Test
        /// <summary>
        /// Testet mit der Liga von Deutschland.
        /// </summary>
        [TestMethod]
        public void G0809Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string leagueName = "Germany 1. Bundesliga";
            string season = "2008/2009";
            int stage = 34;

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 33;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 32;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 31;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 30;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 28;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 26;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 25;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 24;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 23;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 22;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 21;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 20;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 19;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);

            stage = 18;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[16].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[17].TeamApiId.Value, false).CanWinChampionship);
        }
        #endregion

    }
}
