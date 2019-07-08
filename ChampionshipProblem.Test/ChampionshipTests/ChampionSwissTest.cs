namespace ChampionshipProblem.Test
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    /// <summary>
    /// Methode zum testen des Algorithmus, ob eine Mannschaft noch Meister werden kann.
    /// </summary>
    [TestClass]
    public class ChampionSwissTest
    {
        #region consts
        /// <summary>
        /// Der Liganame.
        /// </summary>
        private const string leagueName = "Switzerland Super League";
        #endregion

        #region SW0809Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW0809Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2008/2009";
            int stage = 36;

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

            stage = 35;
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

            stage = 34;
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

            stage = 33;
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

            stage = 32;
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

            stage = 31;
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

            stage = 29;
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

            stage = 27;
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
        }
        #endregion

        #region SW0910Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW0910Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2009/2010";
            int stage = 36;

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

            stage = 35;
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

            stage = 34;
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

            stage = 32;
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

            stage = 31;
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

            stage = 29;
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);
            
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
        }
        #endregion

        #region SW1011Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW1011Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2010/2011";
            int stage = 36;

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

            stage = 35;
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

            stage = 34;
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

            stage = 30;
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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            /*
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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

            stage = 27;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            /*Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            /*
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
            */
        }
        #endregion

        #region SW1112Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW1112Test()
        {
            // Test nicht möglich, da Daten fehlerhaft
        }
        #endregion

        #region SW1213Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW1213Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2012/2013";
            int stage = 36;

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

            stage = 35;
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

            stage = 34;
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

            stage = 32;
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

            stage = 31;
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

            stage = 30;
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

            stage = 29;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            /*Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            /*
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
            */
        }
        #endregion

        #region SW1314Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW1314Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2013/2014";
            int stage = 36;

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

            stage = 35;
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

            stage = 34;
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

            stage = 31;
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            /*Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);*/
        }
        #endregion

        #region SW1415Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW1415Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2014/2015";
            int stage = 36;

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

            stage = 35;
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

            stage = 34;
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

            stage = 33;
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

            stage = 30;
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

            stage = 29;
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

            stage = 28;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            /*Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

            stage = 27;
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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);*/
        }
        #endregion

        #region SW1516Test
        /// <summary>
        /// Testet mit der Liga von Schweiz.
        /// </summary>
        [TestMethod]
        public void SW1516Test()
        {
            // Datengrundlage erzeugen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueService leagueService = new LeagueService(championshipViewModel);
            MatchService matchService = new MatchService(championshipViewModel);

            string season = "2015/2016";
            int stage = 36;

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

            stage = 35;
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

            stage = 34;
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

            stage = 33;
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

            stage = 32;
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

            stage = 31;
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

            stage = 30;
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

            stage = 26;
            leagueStandingService = new LeagueStandingService(championshipViewModel, leagueName, season);
            standing = leagueStandingService.CalculateStanding(stage);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[0].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[1].TeamApiId.Value, false).CanWinChampionship);
            /*
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[2].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[3].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[4].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[5].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[6].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[7].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[8].TeamApiId.Value, false).CanWinChampionship);
            Assert.AreEqual(false, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);

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
            Assert.AreEqual(true, leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[9].TeamApiId.Value, false).CanWinChampionship);*/
        }
        #endregion
    }
}