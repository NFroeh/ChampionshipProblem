﻿using ChampionshipProblem.Classes;
using ChampionshipProblem.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ChampionshipProblem.Test
{
    /// <summary>
    /// Methode zum testen des Algorithmus, ob eine Mannschaft noch Meister werden kann.
    /// </summary>
    [TestClass]
    public class ChampionBelgiumTest
    {
        #region consts
        /// <summary>
        /// Der Liganame.
        /// </summary>
        private const string leagueName = "Belgium Jupiler League";
        #endregion

        #region B0809Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B0809Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

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

            stage = 32;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 31;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 30;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 29;
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

            stage = 28;
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

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            /*Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
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
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
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
            */
        }
        #endregion

        #region B0910Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B0910Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2009/2010";
            int stage = 30;

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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
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

            stage = 28;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
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

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
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

            stage = 26;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);

            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 25;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 24;
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

            stage = 23;
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

            stage = 22;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            /*
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);

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
            */
        }
        #endregion

        #region B1011Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B1011Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2010/2011";
            int stage = 30;

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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 28;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 26;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 25;
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

            stage = 23;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            /*
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            */
        }
        #endregion

        #region B1112Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B1112Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2011/2012";
            int stage = 30;

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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
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

            stage = 28;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
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

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 26;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 25;
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            /*
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

            /*
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            */
        }
        #endregion

        #region B1213Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B1213Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2012/2013";
            int stage = 30;

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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
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

            stage = 28;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 26;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 25;
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

            stage = 24;
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

            stage = 23;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            /*
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

            /*
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            */
        }
        #endregion

        #region B1314Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B1314Test()
        {
            // Die Daten sind fehlerhaft, daher kann nicht getestet werden
        }
        #endregion

        #region B1415Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B1415Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2014/2015";
            int stage = 30;

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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 28;
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            /*Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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

            /*
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
            */
        }
        #endregion

        #region B1516Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [TestMethod]
        public void B1516Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2015/2016";
            int stage = 30;

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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 28;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
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

            stage = 26;
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

            stage = 25;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            /*Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[10].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[11].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[12].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[13].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[14].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[15].TeamApiId.Value, false).CanWinChampionship);

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

            stage = 17;
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

            stage = 16;
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
            */
        }
        #endregion
    }
}
