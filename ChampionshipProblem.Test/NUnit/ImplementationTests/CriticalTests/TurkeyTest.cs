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
    public class TurkeyTest : BaseTestClass
    {
        private const string leagueName = League.TurkeyD0LeagueName;
        private const Country country = Country.Turkey;
        private const int numberTeams = 18;
        private const int numberStages = 34;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService1011;
        private LeagueStandingService LeagueStandingService1213;
        private LeagueStandingService LeagueStandingService1314;
        private LeagueStandingService LeagueStandingService1415;
        private LeagueStandingService LeagueStandingService1718;
        private LeagueStandingService LeagueStandingService1819;


        [OneTimeSetUp]
        public void SetUp()
        {
            this.ChampionshipViewModel = new ChampionshipViewModel();
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2008/2009");
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2010/2011");
            LeagueStandingService1213 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2012/2013");
            LeagueStandingService1314 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2013/2014");
            LeagueStandingService1415 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2014/2015");
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

        #region T0809Test
        /// <summary>
        /// Testet mit der Liga von Türkei.
        /// </summary>
        [Test]
        [TestCase(25, 15, true)]
        [TestCase(25, 16, true)]

        [TestCase(24, 16, true)]

        [TestCase(23, 17, false)]

        [TestCase(22, 17, true)]

        [TestCase(21, 17, true)]

        [TestCase(20, 17, true)]
        public void T0809Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0809, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region T1011Test
        /// <summary>
        /// Testet mit der Liga von Türkei.
        /// </summary>
        [Test]
        [TestCase(23, 14, true)]

        [TestCase(22, 17, true)]

        [TestCase(21, 17, true)]

        [TestCase(20, 17, true)]

        [TestCase(19, 17, true)]

        [TestCase(18, 17, true)]

        [TestCase(17, 17, true)]
        public void T1011Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1011, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region T1213Test
        /// <summary>
        /// Testet mit der Liga von Türkei.
        /// </summary>
        [Test]
        [TestCase(26, 16, true)]

        [TestCase(25, 16, true)]
        [TestCase(25, 17, true)]

        [TestCase(24, 17, true)]

        [TestCase(20, 17, true)]
        public void T1213Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1213, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region T1314Test
        /// <summary>
        /// Testet mit der Liga von Türkei.
        /// </summary>
        [Test]
        [TestCase(22, 17, true)]

        [TestCase(21, 16, true)]
        [TestCase(21, 17, true)]

        [TestCase(20, 16, true)]
        [TestCase(20, 17, true)]

        [TestCase(18, 17, true)]
        public void T1314Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1314, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region T1415Test
        /// <summary>
        /// Testet mit der Liga von Türkei.
        /// </summary>
        [Test]
        [TestCase(25, 10, true)]
        [TestCase(25, 11, true)]

        [TestCase(23, 15, true)]

        [TestCase(21, 17, true)]

        [TestCase(20, 17, true)]
        public void T1415Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1415, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region T1718Test
        /// <summary>
        /// Testet mit der Liga von Türkei.
        /// </summary>
        [Test]
        [TestCase(29, 04, true)]

        [TestCase(27, 08, true)]

        [TestCase(26, 11, true)]

        [TestCase(25, 12, true)]

        [TestCase(24, 15, false)]
        [TestCase(24, 16, false)]

        [TestCase(22, 17, true)] // backtracking

        [TestCase(21, 17, true)]

        [TestCase(20, 17, true)]

        [TestCase(19, 17, true)]

        [TestCase(18, 17, true)]

        [TestCase(17, 17, true)]
        public void T1718Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1718, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region T1819Test
        /// <summary>
        /// Testet mit der Liga von Türkei.
        /// </summary>
        [Test]
        [TestCase(32, 02, true)]

        [TestCase(31, 03, true)]

        [TestCase(17, 17, true)]
        public void T1819Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1819, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
