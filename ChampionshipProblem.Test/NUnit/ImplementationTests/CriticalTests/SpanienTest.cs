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
    public class SpanienTest : BaseTestClass
    {
        private const string leagueName = League.SpainD0LeagueName;
        private const Country country = Country.Spain;
        private const int numberTeams = 20;
        private const int numberStages = 38;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService0910;
        private LeagueStandingService LeagueStandingService1011;
        private LeagueStandingService LeagueStandingService1112;
        private LeagueStandingService LeagueStandingService1213;
        private LeagueStandingService LeagueStandingService1314;
        private LeagueStandingService LeagueStandingService1415;
        private LeagueStandingService LeagueStandingService1516;
        private LeagueStandingService LeagueStandingService1819;


        [OneTimeSetUp]
        public void SetUp()
        {
            this.ChampionshipViewModel = new ChampionshipViewModel();
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2008/2009");
            LeagueStandingService0910 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2009/2010");
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2010/2011");
            LeagueStandingService1112 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2011/2012");
            LeagueStandingService1213 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2012/2013");
            LeagueStandingService1314 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2013/2014");
            LeagueStandingService1415 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2014/2015");
            LeagueStandingService1516 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2015/2016");
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

        #region S0910Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(28, 05, true)]
        [TestCase(28, 06, true)]

        [TestCase(27, 07, true)]
        [TestCase(27, 08, true)]

        [TestCase(26, 12, true)]

        [TestCase(25, 16, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(20, 19, true)]

        [TestCase(19, 19, true)]
        public void S0910Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0910, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1112Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(19, 19, true)]
        public void S1112Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1112, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1314Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(31, 03, true)]

        [TestCase(30, 04, true)]

        [TestCase(26, 11, true)]
        [TestCase(26, 12, true)]

        [TestCase(25, 13, true)]
        [TestCase(25, 14, true)]
        [TestCase(25, 15, true)]
        [TestCase(25, 16, true)]

        [TestCase(24, 17, true)]
        [TestCase(24, 18, true)]

        [TestCase(23, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(20, 19, true)]

        [TestCase(19, 19, true)]
        public void S1314Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1314, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1415Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(27, 08, true)]
        [TestCase(27, 09, true)]

        [TestCase(26, 13, true)]
        [TestCase(26, 14, true)]

        [TestCase(24, 19, true)]
        public void S1415Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1415, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region S1819Test
        /// <summary>
        /// Testet mit der Liga von Spanien.
        /// </summary>
        [Test]
        [TestCase(25, 19, true)]

        [TestCase(24, 19, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]

        [TestCase(20, 19, true)]

        [TestCase(19, 19, true)]
        public void S1819Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1819, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
