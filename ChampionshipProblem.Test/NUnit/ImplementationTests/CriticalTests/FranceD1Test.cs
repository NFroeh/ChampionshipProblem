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
    public class FranceD1Test : BaseTestClass
    {
        private const string leagueName = League.FranceD1LeagueName;
        private const Country country = Country.France;
        private const int numberTeams = 20;
        private const int numberStages = 38;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService1011;
        private LeagueStandingService LeagueStandingService1516;
        private LeagueStandingService LeagueStandingService1819;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ChampionshipViewModel = new ChampionshipViewModel();
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2010/2011");
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

        #region F1011Test
        /// <summary>
        /// Testet mit der Liga von Frankreich.
        /// </summary>
        [Test]
        [TestCase(31, 16, true)]
        [TestCase(31, 17, true)]
        [TestCase(31, 18, true)]

        [TestCase(30, 19, true)]

        [TestCase(29, 18, true)]
        [TestCase(29, 19, true)]

        [TestCase(28, 19, true)]

        [TestCase(27, 19, true)]

        [TestCase(26, 19, true)]

        [TestCase(25, 19, true)]

        [TestCase(24, 19, true)]

        [TestCase(23, 19, true)]

        [TestCase(20, 19, true)]

        [TestCase(19, 19, true)]
        public void F1011Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1011, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region F1516Test
        /// <summary>
        /// Testet mit der Liga von Frankreich.
        /// </summary>
        [Test]
        [TestCase(26, 19, true)]

        [TestCase(25, 19, true)]

        [TestCase(24, 19, true)]

        [TestCase(23, 19, true)]

        [TestCase(22, 19, true)]

        [TestCase(21, 19, true)]
        public void F1516Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1516, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region F1819Test
        /// <summary>
        /// Testet mit der Liga von Frankreich.
        /// </summary>
        [Test]
        [TestCase(26, 18, true)]
        [TestCase(26, 19, true)]

        [TestCase(25, 19, true)]

        [TestCase(24, 18, true)]
        [TestCase(24, 19, true)]
        public void F1819Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1819, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
