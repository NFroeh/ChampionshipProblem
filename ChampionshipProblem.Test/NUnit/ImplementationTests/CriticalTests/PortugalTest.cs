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
    public class PortugalTest : BaseTestClass
    {
        private const string leagueName = League.PortugalD0LeagueName;
        private const Country country = Country.Portugal;
        private const int numberTeams1 = 16;
        private const int numberStages1 = 30;
        private const int numberTeams2 = 18;
        private const int numberStages2 = 34;
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
            LeagueStandingService0809 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2008/2009");
            LeagueStandingService0910 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2009/2010");
            LeagueStandingService1011 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2010/2011");
            LeagueStandingService1112 = new LeagueStandingService(this.ChampionshipViewModel, country, leagueName, "2011/2012");
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

            string name = TestContext.CurrentContext.Test.Name.Substring(0, 9);
            int numberTeams = numberTeams2;
            int numberStages = numberStages2;
            if (name == nameof(P0809Test) || name == nameof(P0910Test) || name == nameof(P1011Test) || 
                name == nameof(P1112Test) || name == nameof(P1213Test))
            {
                numberTeams = numberTeams1;
                numberStages = numberStages1;
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
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(21, 11, true)]
        [TestCase(21, 12, true)]
        [TestCase(21, 13, true)]
        public void P0809Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0809, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P0910Test
        /// <summary>
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(21, 09, true)]
        public void P0910Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService0910, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1011Test
        /// <summary>
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(17, 15, true)]
        public void P1011Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1011, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1112Test
        /// <summary>
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(20, 09, true)]

        [TestCase(15, 15, true)]
        public void P1112Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1112, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1213Test
        /// <summary>
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(20, 07, true)]
        [TestCase(20, 08, true)]
        [TestCase(20, 09, true)]

        [TestCase(19, 12, true)]
        [TestCase(19, 13, true)]

        [TestCase(16, 15, true)]

        [TestCase(15, 15, true)]
        public void P1213Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1213, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1516Test
        /// <summary>
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(24, 08, true)]

        [TestCase(19, 17, true)]

        [TestCase(18, 17, true)]

        [TestCase(17, 17, true)]
        public void P1516Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1516, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1617Test
        /// <summary>
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(25, 05, true)]

        [TestCase(22, 15, true)]
        public void P1617Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1617, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion

        #region P1819Test
        /// <summary>
        /// Testet mit der Liga von Portugal.
        /// </summary>
        [Test]
        [TestCase(22, 16, true)]

        [TestCase(21, 17, true)]

        [TestCase(20, 17, true)]
        public void P1819Test(int stage, int teamNumber, bool result)
        {
            bool? returnedResult = CurrentTestSetup.GetCurrentTestResult(LeagueStandingService1819, stage, teamNumber);
            Assert.IsNotNull(returnedResult);
            Assert.AreEqual(result, returnedResult);
        }
        #endregion
    }
}
