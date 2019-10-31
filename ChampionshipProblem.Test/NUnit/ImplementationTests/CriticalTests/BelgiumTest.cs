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
    public class BelgiumTest : BaseTestClass
    {
        private const string leagueName = League.BelgiumD0LeagueName;
        private const Country country = Country.Belgium;
        private const int numberTeams1 = 18;
        private const int numberStages1 = 34;
        private const int numberTeams2 = 16;
        private const int numberStages2 = 30;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService1011;
        private LeagueStandingService LeagueStandingService1112;
        private LeagueStandingService LeagueStandingService1213;
        private LeagueStandingService LeagueStandingService1415;
        private LeagueStandingService LeagueStandingService1516;
        private LeagueStandingService LeagueStandingService1718;
        private LeagueStandingService LeagueStandingService1819;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ChampionshipViewModel = new ChampionshipViewModel();
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2008/2009");
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2010/2011");
            LeagueStandingService1112 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2011/2012");
            LeagueStandingService1213 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2012/2013");
            LeagueStandingService1415 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2014/2015");
            LeagueStandingService1516 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2015/2016");
            LeagueStandingService1718 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2017/2018");
            LeagueStandingService1819 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2018/2019");
        }

        [TearDown]
        public void TearDown()
        {
            long time = this.stopWatch.ElapsedMilliseconds;
            bool success = TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed;
            bool expected = (bool) TestContext.CurrentContext.Test.Arguments[2];
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

            string name = TestContext.CurrentContext.Test.Name.Substring(0, 9);
            int numberTeams = numberTeams2;
            int numberStages = numberStages2;
            if (name == nameof(B0809Test))
            {
                numberTeams = numberTeams1;
                numberStages = numberStages1;
            }
            CSVWriter.WriteTestResult(
                CurrentTestSetup.CurrentTestType,
                country.ToString(),
                leagueName,
                TestContext.CurrentContext.Test.Name.Substring(1, 4),
                (int) TestContext.CurrentContext.Test.Arguments[0],
                (int) TestContext.CurrentContext.Test.Arguments[1],
                expected,
                returned,
                success,
                time,
                numberTeams,
                numberStages
            );
        }

        #region B0809Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [Test]
        [TestCase(18, 17, true)]
        [TestCase(17, 17, true)]
        public void B0809Test(int stage, int teamNumber, bool result, int numberTeams = 18, int numberStages = 34)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0809, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region B1011Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [Test]
        [TestCase(27, 02, true)]

        [TestCase(20, 13, true)]

        [TestCase(19, 13, true)]
        [TestCase(19, 14, true)]

        [TestCase(18, 15, true)]

        [TestCase(17, 15, true)]
        public void B1011Test(int stage, int teamNumber, bool result, int numberTeams = 16, int numberStages = 30)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1011, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region B1112Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [Test]
        [TestCase(20, 14, true)]
        [TestCase(20, 15, true)]
        public void B1112Test(int stage, int teamNumber, bool result, int numberTeams = 16, int numberStages = 30)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1112, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region B1213Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [Test]
        [TestCase(19, 15, true)] // backtracking
        public void B1213Test(int stage, int teamNumber, bool result, int numberTeams = 16, int numberStages = 30)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1213, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region B1415Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [Test]
        [TestCase(20, 15, true)]
        public void B1415Test(int stage, int teamNumber, bool result, int numberTeams = 16, int numberStages = 30)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1415, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region B1516Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [Test]
        [TestCase(20, 15, true)]

        [TestCase(19, 15, true)]

        [TestCase(18, 15, true)]
        public void B1516Test(int stage, int teamNumber, bool result, int numberTeams = 16, int numberStages = 30)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1516, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region B1718Test
        /// <summary>
        /// Testet mit der Liga von Belgien.
        /// </summary>
        [Test]
        [TestCase(18, 15, true)]
        [TestCase(17, 15, true)]
        public void B1718Test(int stage, int teamNumber, bool result, int numberTeams = 16, int numberStages = 30)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1718, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
