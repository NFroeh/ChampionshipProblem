namespace ChampionshipProblem.Test
{
    using ChampionshipProblem.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class PositionServiceTest
    {
        #region BasicTest
        /// <summary>
        /// Testet die Methode zum Kalkulieren, ob eine Mannschaft noch meister werden kann.
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            int[] pointDifferences = new int[] { -3, -5, -6, -6, -6, -11, -11, -18, -21, -28, -28, -28, -17, -22, -23, -24, -23};
            Tuple<int, int>[] remainingMatches = new Tuple<int, int>[] {
                new Tuple<int, int>(4, 1),
                new Tuple<int, int>(5, 7),
                new Tuple<int, int>(9, 6),
                new Tuple<int, int>(10, 8),
                new Tuple<int, int>(3, 0),
                new Tuple<int, int>(8, 4),
                new Tuple<int, int>(11, 9),
                new Tuple<int, int>(2, 7),
                new Tuple<int, int>(5, 3),
                new Tuple<int, int>(0, 6),
                new Tuple<int, int>(9, 8),
                new Tuple<int, int>(10, 1),
                new Tuple<int, int>(4, 10),
                new Tuple<int, int>(1, 5),
                new Tuple<int, int>(11, 0),
                new Tuple<int, int>(2, 3),
                new Tuple<int, int>(0, 8),
                new Tuple<int, int>(9, 4)
            };

            // Rechne mit allem unentschieden
            Assert.AreEqual(1, PositionService.CalculateIfTeamCanReachPosition((int[])pointDifferences.Clone(), (Tuple<int, int>[]) remainingMatches.Clone(), 0));
            Assert.AreEqual(0, PositionService.CalculateIfTeamCanReachPosition((int[])pointDifferences.Clone(), (Tuple<int, int>[]) remainingMatches.Clone(), 81));

            int[] pointDifferences2 = new int[] { 0, -2, 0, 0, -3, -5, -5, -6, -15, -25, -25, -22, -29, -22, -20, -24, -20 };
            Tuple<int, int>[] remainingMatches2 = new Tuple<int, int>[] {
                new Tuple<int, int>(4, 1), // 1
                new Tuple<int, int>(9, 6), // 1
                new Tuple<int, int>(10, 8), // 2
                new Tuple<int, int>(12, 11), // 0
                new Tuple<int, int>(8, 4), // 1
                new Tuple<int, int>(1, 12), // 2
                new Tuple<int, int>(11, 9), // 1
                new Tuple<int, int>(7, 10), // 0
                new Tuple<int, int>(4, 12), // 2
                new Tuple<int, int>(9, 8), // 0
                new Tuple<int, int>(10, 1), // 1
                new Tuple<int, int>(4, 10), // 2
                new Tuple<int, int>(1, 5), // 2
                new Tuple<int, int>(12, 9), // 0
                new Tuple<int, int>(5, 7), // 0
                new Tuple<int, int>(9, 4), // 1
                new Tuple<int, int>(10, 12) // 0
            };

            Assert.AreEqual(2, PositionService.CalculateIfTeamCanReachPosition((int[])pointDifferences2.Clone(), (Tuple<int, int>[])remainingMatches2.Clone(), 0));

            // 010211220210011
            Assert.AreEqual(0, PositionService.CalculateIfTeamCanReachPosition((int[])pointDifferences2.Clone(), (Tuple<int, int>[])remainingMatches2.Clone(), 15839572));
        }
        #endregion
    }
}
