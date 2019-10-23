namespace ChampionshipProblem.Test.NUnit.ImplementationTests
{
    using global::NUnit.Framework;
    using System.Diagnostics;

    [TestFixture]
    public abstract class BaseTestClass
    {
        protected Stopwatch stopWatch { get; set; }

        [SetUp]
        public void Init()
        {
            stopWatch = Stopwatch.StartNew();
        }

        [TearDown]
        public void Cleanup()
        {
            stopWatch.Stop();
        }
    }
}
