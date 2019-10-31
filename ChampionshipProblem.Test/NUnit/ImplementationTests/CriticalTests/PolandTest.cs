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
    public class PolandTest : BaseTestClass
    {
        private const string leagueName = League.PolandD0LeagueName;
        private const Country country = Country.Poland;
        private const int numberTeams = 16;
        private const int numberStages = 30;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService0910;
        private LeagueStandingService LeagueStandingService1011;
        private LeagueStandingService LeagueStandingService1112;
        private LeagueStandingService LeagueStandingService1213;
        private LeagueStandingService LeagueStandingService1415;
        private LeagueStandingService LeagueStandingService1516;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ChampionshipViewModel = new ChampionshipViewModel();
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2008/2009");
            LeagueStandingService0910 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2009/2010");
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2010/2011");
            LeagueStandingService1112 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2011/2012");
            LeagueStandingService1213 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2012/2013");
            LeagueStandingService1415 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2014/2015");
            LeagueStandingService1516 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2015/2016");
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

        #region P0809Test
        /// <summary>
        /// Testet mit der Liga von Polen.
        /// </summary>
        [Test]
        [TestCase(23, 06, true)]
        [TestCase(23, 07, true)]

        [TestCase(22, 13, true)]

        [TestCase(21, 15, true)]

        [TestCase(16, 15, true)]
        public void P0809Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0809, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P0910Test
        /// <summary>
        /// Testet mit der Liga von Polen.
        /// </summary>
        [Test]
        [TestCase(22, 10, true)]
        [TestCase(22, 11, true)]

        [TestCase(16, 15, true)]

        [TestCase(15, 15, true)]
        public void P0910Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0910, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1011Test
        /// <summary>
        /// Testet mit der Liga von Polen.
        /// </summary>
        [Test]
        [TestCase(24, 13, true)]

        [TestCase(23, 13, true)]
        [TestCase(23, 14, true)]

        [TestCase(20, 15, true)]

        [TestCase(18, 15, true)]

        [TestCase(17, 15, true)]

        [TestCase(16, 15, true)]

        [TestCase(15, 15, true)]
        public void P1011Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1011, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1213Test
        /// <summary>
        /// Testet mit der Liga von Polen.
        /// </summary>
        [Test]
        [TestCase(20, 14, true)]

        [TestCase(19, 14, true)]
        [TestCase(19, 15, true)]

        [TestCase(18, 14, true)]
        [TestCase(18, 15, true)]

        [TestCase(17, 14, true)]
        [TestCase(17, 15, true)]

        [TestCase(16, 14, true)]
        [TestCase(16, 15, true)]

        [TestCase(15, 14, true)]
        [TestCase(15, 15, true)]
        public void P1213Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1213, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1415Test
        /// <summary>
        /// Testet mit der Liga von Polen.
        /// </summary>
        [Test]
        [TestCase(20, 15, false)]

        [TestCase(19, 15, true)]

        [TestCase(18, 15, true)]

        [TestCase(17, 15, true)]

        [TestCase(16, 15, true)]

        [TestCase(15, 15, true)]
        public void P1415Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1415, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
