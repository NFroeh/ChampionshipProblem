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
    public class SpanienD1Test : BaseTestClass
    {
        private const string leagueName = League.SpainD1LeagueName;
        private const Country country = Country.Spain;
        private const int numberTeams = 22;
        private const int numberStages = 42;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService0910;
        private LeagueStandingService LeagueStandingService1011;
        private LeagueStandingService LeagueStandingService1213;
        private LeagueStandingService LeagueStandingService1314;
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

        #region S0809Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(31, 19, true)]
        [TestCase(31, 20, true)]

        [TestCase(30, 20, true)]

        [TestCase(29, 20, true)]

        [TestCase(28, 20, true)]
        [TestCase(28, 21, false)]

        [TestCase(27, 20, true)]
        [TestCase(27, 21, false)]

        [TestCase(26, 20, true)]
        [TestCase(26, 21, true)] // backtracking?

        [TestCase(25, 20, true)]
        [TestCase(25, 21, true)]

        [TestCase(24, 20, true)]
        [TestCase(24, 21, true)]

        [TestCase(23, 21, true)]

        [TestCase(22, 21, true)]

        [TestCase(21, 21, true)]
        public void S0809Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0809, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S0910Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(32, 20, true)]

        [TestCase(31, 20, true)]

        [TestCase(30, 20, true)]
        [TestCase(30, 21, true)]

        [TestCase(29, 21, true)]

        [TestCase(28, 21, true)]

        [TestCase(27, 21, true)]

        [TestCase(26, 21, true)]

        [TestCase(25, 21, true)]
        public void S0910Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0910, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1011Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(30, 20, true)]
        [TestCase(30, 21, true)]

        [TestCase(28, 21, true)]

        [TestCase(27, 21, true)]

        [TestCase(26, 21, true)]

        [TestCase(25, 21, true)]

        [TestCase(24, 21, true)]
        public void S1011Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1011, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1213Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(28, 21, true)]
        public void S1213Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1213, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1314Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(34, 20, true)]

        [TestCase(33, 20, true)]
        [TestCase(33, 21, true)]

        [TestCase(32, 21, true)]

        [TestCase(31, 21, true)]

        [TestCase(30, 21, true)]
        public void S1314Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1314, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1819Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(29, 20, true)]
        [TestCase(29, 21, true)]
        public void S1819Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1819, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
