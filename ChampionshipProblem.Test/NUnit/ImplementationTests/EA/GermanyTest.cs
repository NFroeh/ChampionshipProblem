﻿
namespace ChampionshipProblem.Test.NUnit.ImplementationTests.EA
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Implementation;
    using ChampionshipProblem.Services;
    using global::NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class GermanyTest
    {
        private const string leagueName = League.GermanyD0LeagueName;

        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService0910;
        private LeagueStandingService LeagueStandingService1011;
        private LeagueStandingService LeagueStandingService1112;
        private LeagueStandingService LeagueStandingService1213;
        private LeagueStandingService LeagueStandingService1314;
        private LeagueStandingService LeagueStandingService1415;
        private LeagueStandingService LeagueStandingService1516;
        private LeagueStandingService LeagueStandingService1617;
        private LeagueStandingService LeagueStandingService1718;
        private LeagueStandingService LeagueStandingService1819;


        [OneTimeSetUp]
        public void SetUp()
        {
            this.ChampionshipViewModel = new ChampionshipViewModel();
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2008/2009");
            LeagueStandingService0910 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2009/2010");
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2010/2011");
            LeagueStandingService1112 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2011/2012");
            LeagueStandingService1213 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2012/2013");
            LeagueStandingService1314 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2013/2014");
            LeagueStandingService1415 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2014/2015");
            LeagueStandingService1516 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2015/2016");
            LeagueStandingService1617 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2016/2017");
            LeagueStandingService1718 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2017/2018");
            LeagueStandingService1819 = new LeagueStandingService(this.ChampionshipViewModel, Classes.Country.Germany, leagueName, "2018/2019");
        }

        #region G0809Test
        /// <summary>
        /// Testet mit der Liga von Deutschland.
        /// </summary>
        [Test]
        [TestCase(34, 0, true)]
        [TestCase(34, 1, false)]
        [TestCase(34, 2, false)]
        [TestCase(34, 3, false)]
        [TestCase(34, 4, false)]
        [TestCase(34, 5, false)]
        [TestCase(34, 6, false)]
        [TestCase(34, 7, false)]
        [TestCase(34, 8, false)]
        [TestCase(34, 9, false)]
        [TestCase(34, 10, false)]
        [TestCase(34, 11, false)]
        [TestCase(34, 12, false)]
        [TestCase(34, 13, false)]
        [TestCase(34, 14, false)]
        [TestCase(34, 15, false)]
        [TestCase(34, 16, false)]
        [TestCase(34, 17, false)]

        [TestCase(33, 00, true)]
        [TestCase(33, 01, true)]
        [TestCase(33, 02, true)]
        [TestCase(33, 03, true)]
        [TestCase(33, 04, false)]
        [TestCase(33, 05, false)]
        [TestCase(33, 06, false)]
        [TestCase(33, 07, false)]
        [TestCase(33, 08, false)]
        [TestCase(33, 09, false)]
        [TestCase(33, 10, false)]
        [TestCase(33, 11, false)]
        [TestCase(33, 12, false)]
        [TestCase(33, 13, false)]
        [TestCase(33, 14, false)]
        [TestCase(33, 15, false)]
        [TestCase(33, 16, false)]
        [TestCase(33, 17, false)]

        [TestCase(32, 00, true)]
        [TestCase(32, 01, true)]
        [TestCase(32, 02, true)]
        [TestCase(32, 03, true)]
        [TestCase(32, 04, true)]
        [TestCase(32, 05, false)]
        [TestCase(32, 06, false)]
        [TestCase(32, 07, false)]
        [TestCase(32, 08, false)]
        [TestCase(32, 09, false)]
        [TestCase(32, 10, false)]
        [TestCase(32, 11, false)]
        [TestCase(32, 12, false)]
        [TestCase(32, 13, false)]
        [TestCase(32, 14, false)]
        [TestCase(32, 15, false)]
        [TestCase(32, 16, false)]
        [TestCase(32, 17, false)]

        [TestCase(31, 00, true)]
        [TestCase(31, 01, true)]
        [TestCase(31, 02, true)]
        [TestCase(31, 03, true)]
        [TestCase(31, 04, true)]
        [TestCase(31, 05, true)]
        [TestCase(31, 06, false)]
        [TestCase(31, 07, false)]
        [TestCase(31, 08, false)]
        [TestCase(31, 09, false)]
        [TestCase(31, 10, false)]
        [TestCase(31, 11, false)]
        [TestCase(31, 12, false)]
        [TestCase(31, 13, false)]
        [TestCase(31, 14, false)]
        [TestCase(31, 15, false)]
        [TestCase(31, 16, false)]
        [TestCase(31, 17, false)]

        [TestCase(30, 00, true)]
        [TestCase(30, 01, true)]
        [TestCase(30, 02, true)]
        [TestCase(30, 03, true)]
        [TestCase(30, 04, true)]
        [TestCase(30, 05, true)]
        [TestCase(30, 06, true)]
        [TestCase(30, 07, false)]
        [TestCase(30, 08, false)]
        [TestCase(30, 09, false)]
        [TestCase(30, 10, false)]
        [TestCase(30, 11, false)]
        [TestCase(30, 12, false)]
        [TestCase(30, 13, false)]
        [TestCase(30, 14, false)]
        [TestCase(30, 15, false)]
        [TestCase(30, 16, false)]
        [TestCase(30, 17, false)]

        [TestCase(29, 00, true)]
        [TestCase(29, 01, true)]
        [TestCase(29, 02, true)]
        [TestCase(29, 03, true)]
        [TestCase(29, 04, true)]
        [TestCase(29, 05, true)]
        [TestCase(29, 06, true)]
        [TestCase(29, 07, true)]
        [TestCase(29, 08, true)]
        [TestCase(29, 09, false)]
        [TestCase(29, 10, false)]
        [TestCase(29, 11, false)]
        [TestCase(29, 12, false)]
        [TestCase(29, 13, false)]
        [TestCase(29, 14, false)]
        [TestCase(29, 15, false)]
        [TestCase(29, 16, false)]
        [TestCase(29, 17, false)]

        [TestCase(28, 00, true)]
        [TestCase(28, 01, true)]
        [TestCase(28, 02, true)]
        [TestCase(28, 03, true)]
        [TestCase(28, 04, true)]
        [TestCase(28, 05, true)]
        [TestCase(28, 06, true)]
        [TestCase(28, 07, true)]
        [TestCase(28, 08, true)]
        [TestCase(28, 09, false)]
        [TestCase(28, 10, false)]
        [TestCase(28, 11, false)]
        [TestCase(28, 12, false)]
        [TestCase(28, 13, false)]
        [TestCase(28, 14, false)]
        [TestCase(28, 15, false)]
        [TestCase(28, 16, false)]
        [TestCase(28, 17, false)]

        [TestCase(27, 00, true)]
        [TestCase(27, 01, true)]
        [TestCase(27, 02, true)]
        [TestCase(27, 03, true)]
        [TestCase(27, 04, true)]
        [TestCase(27, 05, true)]
        [TestCase(27, 06, true)]
        [TestCase(27, 07, true)]
        [TestCase(27, 08, true)]
        [TestCase(27, 09, true)]
        [TestCase(27, 10, false)]
        [TestCase(27, 11, false)]
        [TestCase(27, 12, false)]
        [TestCase(27, 13, false)]
        [TestCase(27, 14, false)]
        [TestCase(27, 15, false)]
        [TestCase(27, 16, false)]
        [TestCase(27, 17, false)]

        [TestCase(26, 00, true)]
        [TestCase(26, 01, true)]
        [TestCase(26, 02, true)]
        [TestCase(26, 03, true)]
        [TestCase(26, 04, true)]
        [TestCase(26, 05, true)]
        [TestCase(26, 06, true)]
        [TestCase(26, 07, true)]
        [TestCase(26, 08, true)]
        [TestCase(26, 09, true)]
        [TestCase(26, 10, true)]
        [TestCase(26, 11, true)]
        [TestCase(26, 12, false)]
        [TestCase(26, 13, false)]
        [TestCase(26, 14, false)]
        [TestCase(26, 15, false)]
        [TestCase(26, 16, false)]
        [TestCase(26, 17, false)]

        [TestCase(25, 00, true)]
        [TestCase(25, 01, true)]
        [TestCase(25, 02, true)]
        [TestCase(25, 03, true)]
        [TestCase(25, 04, true)]
        [TestCase(25, 05, true)]
        [TestCase(25, 06, true)]
        [TestCase(25, 07, true)]
        [TestCase(25, 08, true)]
        [TestCase(25, 09, true)]
        [TestCase(25, 10, true)]
        [TestCase(25, 11, true)]
        [TestCase(25, 12, true)]
        [TestCase(25, 13, true)]
        [TestCase(25, 14, true)]
        [TestCase(25, 15, false)]
        [TestCase(25, 16, false)]
        [TestCase(25, 17, false)]

        [TestCase(24, 00, true)]
        [TestCase(24, 01, true)]
        [TestCase(24, 02, true)]
        [TestCase(24, 03, true)]
        [TestCase(24, 04, true)]
        [TestCase(24, 05, true)]
        [TestCase(24, 06, true)]
        [TestCase(24, 07, true)]
        [TestCase(24, 08, true)]
        [TestCase(24, 09, true)]
        [TestCase(24, 10, true)]
        [TestCase(24, 11, true)]
        [TestCase(24, 12, true)]
        [TestCase(24, 13, true)]
        [TestCase(24, 14, true)]
        [TestCase(24, 15, true)]
        [TestCase(24, 16, true)]
        [TestCase(24, 17, false)]

        [TestCase(23, 00, true)]
        [TestCase(23, 01, true)]
        [TestCase(23, 02, true)]
        [TestCase(23, 03, true)]
        [TestCase(23, 04, true)]
        [TestCase(23, 05, true)]
        [TestCase(23, 06, true)]
        [TestCase(23, 07, true)]
        [TestCase(23, 08, true)]
        [TestCase(23, 09, true)]
        [TestCase(23, 10, true)]
        [TestCase(23, 11, true)]
        [TestCase(23, 12, true)]
        [TestCase(23, 13, true)]
        [TestCase(23, 14, true)]
        [TestCase(23, 15, true)]
        [TestCase(23, 16, true)]
        [TestCase(23, 17, true)]

        [TestCase(22, 00, true)]
        [TestCase(22, 01, true)]
        [TestCase(22, 02, true)]
        [TestCase(22, 03, true)]
        [TestCase(22, 04, true)]
        [TestCase(22, 05, true)]
        [TestCase(22, 06, true)]
        [TestCase(22, 07, true)]
        [TestCase(22, 08, true)]
        [TestCase(22, 09, true)]
        [TestCase(22, 10, true)]
        [TestCase(22, 11, true)]
        [TestCase(22, 12, true)]
        [TestCase(22, 13, true)]
        [TestCase(22, 14, true)]
        [TestCase(22, 15, true)]
        [TestCase(22, 16, true)]
        [TestCase(22, 17, true)]

        [TestCase(21, 00, true)]
        [TestCase(21, 01, true)]
        [TestCase(21, 02, true)]
        [TestCase(21, 03, true)]
        [TestCase(21, 04, true)]
        [TestCase(21, 05, true)]
        [TestCase(21, 06, true)]
        [TestCase(21, 07, true)]
        [TestCase(21, 08, true)]
        [TestCase(21, 09, true)]
        [TestCase(21, 10, true)]
        [TestCase(21, 11, true)]
        [TestCase(21, 12, true)]
        [TestCase(21, 13, true)]
        [TestCase(21, 14, true)]
        [TestCase(21, 15, true)]
        [TestCase(21, 16, true)]
        [TestCase(21, 17, true)]

        [TestCase(20, 00, true)]
        [TestCase(20, 01, true)]
        [TestCase(20, 02, true)]
        [TestCase(20, 03, true)]
        [TestCase(20, 04, true)]
        [TestCase(20, 05, true)]
        [TestCase(20, 06, true)]
        [TestCase(20, 07, true)]
        [TestCase(20, 08, true)]
        [TestCase(20, 09, true)]
        [TestCase(20, 10, true)]
        [TestCase(20, 11, true)]
        [TestCase(20, 12, true)]
        [TestCase(20, 13, true)]
        [TestCase(20, 14, true)]
        [TestCase(20, 15, true)]
        [TestCase(20, 16, true)]
        [TestCase(20, 17, true)]

        [TestCase(19, 00, true)]
        [TestCase(19, 01, true)]
        [TestCase(19, 02, true)]
        [TestCase(19, 03, true)]
        [TestCase(19, 04, true)]
        [TestCase(19, 05, true)]
        [TestCase(19, 06, true)]
        [TestCase(19, 07, true)]
        [TestCase(19, 08, true)]
        [TestCase(19, 09, true)]
        [TestCase(19, 10, true)]
        [TestCase(19, 11, true)]
        [TestCase(19, 12, true)]
        [TestCase(19, 13, true)]
        [TestCase(19, 14, true)]
        [TestCase(19, 15, true)]
        [TestCase(19, 16, true)]
        [TestCase(19, 17, true)]

        [TestCase(18, 00, true)]
        [TestCase(18, 01, true)]
        [TestCase(18, 02, true)]
        [TestCase(18, 03, true)]
        [TestCase(18, 04, true)]
        [TestCase(18, 05, true)]
        [TestCase(18, 06, true)]
        [TestCase(18, 07, true)]
        [TestCase(18, 08, true)]
        [TestCase(18, 09, true)]
        [TestCase(18, 10, true)]
        [TestCase(18, 11, true)]
        [TestCase(18, 12, true)]
        [TestCase(18, 13, true)]
        [TestCase(18, 14, true)]
        [TestCase(18, 15, true)]
        [TestCase(18, 16, true)]
        [TestCase(18, 17, true)]
        public void G0809Test(int stage, int teamNumber, bool result)
        {
            List<LeagueStandingEntry> standing = LeagueStandingService0809.CalculateStanding(stage);
            Assert.AreEqual(result, new EA1And1Handler().Handle(new ChampionshipProblemInput(LeagueStandingService0809, standing[teamNumber].TeamId, stage)).CanBeChampion);
        }
        #endregion

        #region G0910Test
        /// <summary>
        /// Testet mit der Liga von Deutschland.
        /// </summary>
        [Test]
        [TestCase(34, 0, true)]
        [TestCase(34, 1, false)]
        [TestCase(34, 2, false)]
        [TestCase(34, 3, false)]
        [TestCase(34, 4, false)]
        [TestCase(34, 5, false)]
        [TestCase(34, 6, false)]
        [TestCase(34, 7, false)]
        [TestCase(34, 8, false)]
        [TestCase(34, 9, false)]
        [TestCase(34, 10, false)]
        [TestCase(34, 11, false)]
        [TestCase(34, 12, false)]
        [TestCase(34, 13, false)]
        [TestCase(34, 14, false)]
        [TestCase(34, 15, false)]
        [TestCase(34, 16, false)]
        [TestCase(34, 17, false)]

        [TestCase(33, 00, true)]
        [TestCase(33, 01, true)]
        [TestCase(33, 02, false)]
        [TestCase(33, 03, false)]
        [TestCase(33, 04, false)]
        [TestCase(33, 05, false)]
        [TestCase(33, 06, false)]
        [TestCase(33, 07, false)]
        [TestCase(33, 08, false)]
        [TestCase(33, 09, false)]
        [TestCase(33, 10, false)]
        [TestCase(33, 11, false)]
        [TestCase(33, 12, false)]
        [TestCase(33, 13, false)]
        [TestCase(33, 14, false)]
        [TestCase(33, 15, false)]
        [TestCase(33, 16, false)]
        [TestCase(33, 17, false)]

        [TestCase(32, 00, true)]
        [TestCase(32, 01, true)]
        [TestCase(32, 02, false)]
        [TestCase(32, 03, false)]
        [TestCase(32, 04, false)]
        [TestCase(32, 05, false)]
        [TestCase(32, 06, false)]
        [TestCase(32, 07, false)]
        [TestCase(32, 08, false)]
        [TestCase(32, 09, false)]
        [TestCase(32, 10, false)]
        [TestCase(32, 11, false)]
        [TestCase(32, 12, false)]
        [TestCase(32, 13, false)]
        [TestCase(32, 14, false)]
        [TestCase(32, 15, false)]
        [TestCase(32, 16, false)]
        [TestCase(32, 17, false)]

        [TestCase(31, 00, true)]
        [TestCase(31, 01, true)]
        [TestCase(31, 02, true)]
        [TestCase(31, 03, true)]
        [TestCase(31, 04, false)]
        [TestCase(31, 05, false)]
        [TestCase(31, 06, false)]
        [TestCase(31, 07, false)]
        [TestCase(31, 08, false)]
        [TestCase(31, 09, false)]
        [TestCase(31, 10, false)]
        [TestCase(31, 11, false)]
        [TestCase(31, 12, false)]
        [TestCase(31, 13, false)]
        [TestCase(31, 14, false)]
        [TestCase(31, 15, false)]
        [TestCase(31, 16, false)]
        [TestCase(31, 17, false)]

        [TestCase(30, 00, true)]
        [TestCase(30, 01, true)]
        [TestCase(30, 02, true)]
        [TestCase(30, 03, true)]
        [TestCase(30, 04, true)]
        [TestCase(30, 05, true)]
        [TestCase(30, 06, false)]
        [TestCase(30, 07, false)]
        [TestCase(30, 08, false)]
        [TestCase(30, 09, false)]
        [TestCase(30, 10, false)]
        [TestCase(30, 11, false)]
        [TestCase(30, 12, false)]
        [TestCase(30, 13, false)]
        [TestCase(30, 14, false)]
        [TestCase(30, 15, false)]
        [TestCase(30, 16, false)]
        [TestCase(30, 17, false)]

        [TestCase(29, 00, true)]
        [TestCase(29, 01, true)]
        [TestCase(29, 02, true)]
        [TestCase(29, 03, true)]
        [TestCase(29, 04, true)]
        [TestCase(29, 05, true)]
        [TestCase(29, 06, true)]
        [TestCase(29, 07, true)]
        [TestCase(29, 08, false)]
        [TestCase(29, 09, false)]
        [TestCase(29, 10, false)]
        [TestCase(29, 11, false)]
        [TestCase(29, 12, false)]
        [TestCase(29, 13, false)]
        [TestCase(29, 14, false)]
        [TestCase(29, 15, false)]
        [TestCase(29, 16, false)]
        [TestCase(29, 17, false)]

        [TestCase(28, 00, true)]
        [TestCase(28, 01, true)]
        [TestCase(28, 02, true)]
        [TestCase(28, 03, true)]
        [TestCase(28, 04, true)]
        [TestCase(28, 05, true)]
        [TestCase(28, 06, true)]
        [TestCase(28, 07, true)]
        [TestCase(28, 08, false)]
        [TestCase(28, 09, false)]
        [TestCase(28, 10, false)]
        [TestCase(28, 11, false)]
        [TestCase(28, 12, false)]
        [TestCase(28, 13, false)]
        [TestCase(28, 14, false)]
        [TestCase(28, 15, false)]
        [TestCase(28, 16, false)]
        [TestCase(28, 17, false)]

        [TestCase(27, 00, true)]
        [TestCase(27, 01, true)]
        [TestCase(27, 02, true)]
        [TestCase(27, 03, true)]
        [TestCase(27, 04, true)]
        [TestCase(27, 05, true)]
        [TestCase(27, 06, true)]
        [TestCase(27, 07, true)]
        [TestCase(27, 08, true)]
        [TestCase(27, 09, true)]
        [TestCase(27, 10, false)]
        [TestCase(27, 11, false)]
        [TestCase(27, 12, false)]
        [TestCase(27, 13, false)]
        [TestCase(27, 14, false)]
        [TestCase(27, 15, false)]
        [TestCase(27, 16, false)]
        [TestCase(27, 17, false)]

        [TestCase(26, 00, true)]
        [TestCase(26, 01, true)]
        [TestCase(26, 02, true)]
        [TestCase(26, 03, true)]
        [TestCase(26, 04, true)]
        [TestCase(26, 05, true)]
        [TestCase(26, 06, true)]
        [TestCase(26, 07, true)]
        [TestCase(26, 08, true)]
        [TestCase(26, 09, true)]
        [TestCase(26, 10, false)]
        [TestCase(26, 11, false)]
        [TestCase(26, 12, false)]
        [TestCase(26, 13, false)]
        [TestCase(26, 14, false)]
        [TestCase(26, 15, false)]
        [TestCase(26, 16, false)]
        [TestCase(26, 17, false)]

        [TestCase(25, 00, true)]
        [TestCase(25, 01, true)]
        [TestCase(25, 02, true)]
        [TestCase(25, 03, true)]
        [TestCase(25, 04, true)]
        [TestCase(25, 05, true)]
        [TestCase(25, 06, true)]
        [TestCase(25, 07, true)]
        [TestCase(25, 08, true)]
        [TestCase(25, 09, true)]
        [TestCase(25, 10, true)]
        [TestCase(25, 11, true)]
        [TestCase(25, 12, true)]
        [TestCase(25, 13, true)]
        [TestCase(25, 14, false)]
        [TestCase(25, 15, false)]
        [TestCase(25, 16, false)]
        [TestCase(25, 17, false)]

        [TestCase(24, 00, true)]
        [TestCase(24, 01, true)]
        [TestCase(24, 02, true)]
        [TestCase(24, 03, true)]
        [TestCase(24, 04, true)]
        [TestCase(24, 05, true)]
        [TestCase(24, 06, true)]
        [TestCase(24, 07, true)]
        [TestCase(24, 08, true)]
        [TestCase(24, 09, true)]
        [TestCase(24, 10, true)]
        [TestCase(24, 11, true)]
        [TestCase(24, 12, true)]
        [TestCase(24, 13, true)]
        [TestCase(24, 14, false)]
        [TestCase(24, 15, false)]
        [TestCase(24, 16, false)]
        [TestCase(24, 17, false)]

        [TestCase(23, 00, true)]
        [TestCase(23, 01, true)]
        [TestCase(23, 02, true)]
        [TestCase(23, 03, true)]
        [TestCase(23, 04, true)]
        [TestCase(23, 05, true)]
        [TestCase(23, 06, true)]
        [TestCase(23, 07, true)]
        [TestCase(23, 08, true)]
        [TestCase(23, 09, true)]
        [TestCase(23, 10, true)]
        [TestCase(23, 11, true)]
        [TestCase(23, 12, true)]
        [TestCase(23, 13, true)]
        [TestCase(23, 14, true)]
        [TestCase(23, 15, false)]
        [TestCase(23, 16, false)]
        [TestCase(23, 17, false)]

        [TestCase(22, 00, true)]
        [TestCase(22, 01, true)]
        [TestCase(22, 02, true)]
        [TestCase(22, 03, true)]
        [TestCase(22, 04, true)]
        [TestCase(22, 05, true)]
        [TestCase(22, 06, true)]
        [TestCase(22, 07, true)]
        [TestCase(22, 08, true)]
        [TestCase(22, 09, true)]
        [TestCase(22, 10, true)]
        [TestCase(22, 11, true)]
        [TestCase(22, 12, true)]
        [TestCase(22, 13, true)]
        [TestCase(22, 14, true)]
        [TestCase(22, 15, true)]
        [TestCase(22, 16, true)]
        [TestCase(22, 17, false)]

        [TestCase(21, 00, true)]
        [TestCase(21, 01, true)]
        [TestCase(21, 02, true)]
        [TestCase(21, 03, true)]
        [TestCase(21, 04, true)]
        [TestCase(21, 05, true)]
        [TestCase(21, 06, true)]
        [TestCase(21, 07, true)]
        [TestCase(21, 08, true)]
        [TestCase(21, 09, true)]
        [TestCase(21, 10, true)]
        [TestCase(21, 11, true)]
        [TestCase(21, 12, true)]
        [TestCase(21, 13, true)]
        [TestCase(21, 14, true)]
        [TestCase(21, 15, true)]
        [TestCase(21, 16, true)]
        [TestCase(21, 17, true)]

        [TestCase(20, 00, true)]
        [TestCase(20, 01, true)]
        [TestCase(20, 02, true)]
        [TestCase(20, 03, true)]
        [TestCase(20, 04, true)]
        [TestCase(20, 05, true)]
        [TestCase(20, 06, true)]
        [TestCase(20, 07, true)]
        [TestCase(20, 08, true)]
        [TestCase(20, 09, true)]
        [TestCase(20, 10, true)]
        [TestCase(20, 11, true)]
        [TestCase(20, 12, true)]
        [TestCase(20, 13, true)]
        [TestCase(20, 14, true)]
        [TestCase(20, 15, true)]
        [TestCase(20, 16, true)]
        [TestCase(20, 17, true)]

        [TestCase(19, 00, true)]
        [TestCase(19, 01, true)]
        [TestCase(19, 02, true)]
        [TestCase(19, 03, true)]
        [TestCase(19, 04, true)]
        [TestCase(19, 05, true)]
        [TestCase(19, 06, true)]
        [TestCase(19, 07, true)]
        [TestCase(19, 08, true)]
        [TestCase(19, 09, true)]
        [TestCase(19, 10, true)]
        [TestCase(19, 11, true)]
        [TestCase(19, 12, true)]
        [TestCase(19, 13, true)]
        [TestCase(19, 14, true)]
        [TestCase(19, 15, true)]
        [TestCase(19, 16, true)]
        [TestCase(19, 17, true)]

        [TestCase(18, 00, true)]
        [TestCase(18, 01, true)]
        [TestCase(18, 02, true)]
        [TestCase(18, 03, true)]
        [TestCase(18, 04, true)]
        [TestCase(18, 05, true)]
        [TestCase(18, 06, true)]
        [TestCase(18, 07, true)]
        [TestCase(18, 08, true)]
        [TestCase(18, 09, true)]
        [TestCase(18, 10, true)]
        [TestCase(18, 11, true)]
        [TestCase(18, 12, true)]
        [TestCase(18, 13, true)]
        [TestCase(18, 14, true)]
        [TestCase(18, 15, true)]
        [TestCase(18, 16, true)]
        [TestCase(18, 17, true)]
        public void G0910Test(int stage, int teamNumber, bool result)
        {
            List<LeagueStandingEntry> standing = LeagueStandingService0910.CalculateStanding(stage);
            Assert.AreEqual(result, new EA1And1Handler().Handle(new ChampionshipProblemInput(LeagueStandingService0910, standing[teamNumber].TeamId, stage)).CanBeChampion);
        }
        #endregion

    }
}
