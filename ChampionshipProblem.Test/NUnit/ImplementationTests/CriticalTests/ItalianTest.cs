namespace ChampionshipProblem.Test.NUnit.ImplementationTests.Critical
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using global::NUnit.Framework;
    using global::NUnit.Framework.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    using Utility;

    [TestFixture, Timeout(CurrentTestSetup.TestTimeout)]
    public class ItalianTest : BaseTestClass
    {
        private const string leagueName = League.ItalyD0LeagueName;
        private const Country country = Country.Italy;
        private const int numberTeams = 20;
        private const int numberStages = 38;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService0910;
        private LeagueStandingService LeagueStandingService1011;
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
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2008/2009");
            LeagueStandingService0910 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2009/2010");
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2010/2011");
            LeagueStandingService1213 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2012/2013");
            LeagueStandingService1314 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2013/2014");
            LeagueStandingService1415 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2014/2015");
            LeagueStandingService1516 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2015/2016");
            LeagueStandingService1617 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2016/2017");
            LeagueStandingService1718 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2017/2018");
            LeagueStandingService1819 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2018/2019");
        }

        [TearDown]
        public void TearDown()
        {
            long time = this.stopWatch.ElapsedMilliseconds;
            bool success = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            bool expected = (bool)TestContext.CurrentContext.Test.Arguments[2];
            bool? returned = null;
            IEnumerable<AssertionResult> assertions = TestContext.CurrentContext.Result.Assertions;
            if (success)
            {
                returned = expected;
            }
            else
            {
                if (assertions.Count() > 1)
                {
                    returned = !expected;
                }
            }

            CSVWriter.WriteTestResult(
                CurrentTestSetup.CurrentTestType,
                country.ToString(),
                leagueName,
                TestContext.CurrentContext.Test.Name.Substring(1, 4),
                (int)TestContext.CurrentContext.Test.Arguments[0],
                (int)TestContext.CurrentContext.Test.Arguments[1],
                expected,
                returned,
                success,
                time,
                numberTeams,
                numberStages
            );
        }

        #region I0809Test
        /// <summary>
        /// Testet mit der Liga von Italien.
        /// </summary>
        [Test]
        [TestCase(24, 19, true)]

        [TestCase(23, 19, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]
        public void I0809Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0809, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region I0910Test
        /// <summary>
        /// Testet mit der Liga von Italien.
        /// </summary>
        [Test]
        [TestCase(25, 19, true)]

        [TestCase(24, 19, true)]

        [TestCase(23, 19, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(20, 19, true)]
        public void I0910Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0910, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region I1011Test
        /// <summary>
        /// Testet mit der Liga von Italien.
        /// </summary>
        [Test]
        [TestCase(25, 19, true)]

        [TestCase(24, 19, true)]

        [TestCase(23, 19, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(20, 19, true)]
        public void I1011Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1011, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region I1213Test
        /// <summary>
        /// Testet mit der Liga von Italien.
        /// </summary>
        [Test]
        [TestCase(25, 19, true)]

        [TestCase(24, 19, true)]
        public void I1213Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1213, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region I1415Test
        /// <summary>
        /// Testet mit der Liga von Italien.
        /// </summary>
        [Test]
        [TestCase(23, 19, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(20, 19, true)]

        [TestCase(19, 19, true)]
        public void I1415Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1415, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region I1516Test
        /// <summary>
        /// Testet mit der Liga von Italien.
        /// </summary>
        [Test]
        [TestCase(24, 19, true)]

        [TestCase(23, 19, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(20, 19, true)]

        [TestCase(19, 19, true)]
        public void I1516Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1516, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
