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
    public class GreeceTest : BaseTestClass
    {
        private const string leagueName = League.GreeceD0LeagueName;
        private const Country country = Country.Greece;
        private const int numberTeams1 = 16;
        private const int numberStages1 = 30;
        private ChampionshipViewModel ChampionshipViewModel;
        private LeagueStandingService LeagueStandingService0809;
        private LeagueStandingService LeagueStandingService0910;
        private LeagueStandingService LeagueStandingService1314;
        private LeagueStandingService LeagueStandingService1617;
        private LeagueStandingService LeagueStandingService1718;


        [OneTimeSetUp]
        public void SetUp()
        {
            this.ChampionshipViewModel = new ChampionshipViewModel();
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2008/2009");
            LeagueStandingService0910 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2009/2010");
            LeagueStandingService1314 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2013/2014");
            LeagueStandingService1617 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2016/2017");
            LeagueStandingService1718 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2017/2018");
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

            string name = TestContext.CurrentContext.Test.Name.Substring(0, 9);
            int numberTeams = numberTeams1;
            int numberStages = numberStages1;
            if (name == nameof(G1314Test))
            {
                numberTeams = 18;
                numberStages = 34;
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

        #region G0910Test
        /// <summary>
        /// Testet mit der Liga von Griechenland.
        /// </summary>
        [Test]
        [TestCase(16, 15, true)]

        [TestCase(15, 15, true)]
        public void G0910Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0910, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region G1314Test
        /// <summary>
        /// Testet mit der Liga von Griechenland.
        /// </summary>
        [Test]
        [TestCase(19, 17, true)]

        [TestCase(18, 17, true)]
        public void G1314Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1314, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region G1718Test
        /// <summary>
        /// Testet mit der Liga von Griechenland.
        /// </summary>
        [Test]
        [TestCase(23, 04, true)]
        [TestCase(23, 05, true)]
        [TestCase(23, 06, true)]

        [TestCase(18, 15, true)]

        [TestCase(17, 15, true)]

        [TestCase(16, 15, true)]

        [TestCase(15, 15, true)]
        public void G1718Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1718, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
