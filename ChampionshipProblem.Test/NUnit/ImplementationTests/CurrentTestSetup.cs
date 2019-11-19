namespace ChampionshipProblem.Test.NUnit.ImplementationTests
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Implementation;
    using ChampionshipProblem.Services;
    using System.Collections.Generic;

    public class CurrentTestSetup
    {
        public const int TestTimeout = 30000;

        public const int NumberOfSimulatedAnnealingIterations = 5000000;

        public const int NumberOf1And1EAIterations = 2750000;

        public const int NumberOfSimulatedAnnealingIterationsByBacktracking = 2500000;

        public static TestAlgorithm CurrentTestType
        {
            get { return TestAlgorithm.Backtracking; }
        }

        public static bool? GetCurrentTestResult(LeagueStandingService leagueStandingService, int stage, int teamNumber)
        {
            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            bool? returnedResult = false;
            ChampionshipProblemInput input = new ChampionshipProblemInput(leagueStandingService, standing[teamNumber].TeamId, stage);
            switch (CurrentTestSetup.CurrentTestType)
            {
                case TestAlgorithm.Heuristic:
                    returnedResult = new HeuristikLHandler().Handle(input).CanBeChampion;
                    break;
                case TestAlgorithm.Brute:
                    returnedResult = new BruteForceHandler().Handle(input).CanBeChampion;
                    break;
                case TestAlgorithm.EA:
                    returnedResult = new EA1And1Handler().Handle(input, NumberOf1And1EAIterations).CanBeChampion;
                    break;
                case TestAlgorithm.SA:
                    returnedResult = new SimulatedAnnealingHandler().Handle(input, NumberOfSimulatedAnnealingIterations).CanBeChampion;
                    break;
                case TestAlgorithm.Backtracking:
                    returnedResult = new BacktrackingHandler().Handle(input, leagueStandingService, stage, teamNumber, NumberOfSimulatedAnnealingIterationsByBacktracking).CanBeChampion;
                    break;
                case TestAlgorithm.HeuristicR:
                    returnedResult = new HeuristikR4Handler().Handle(input).CanBeChampion;
                    break;
                default:
                    throw new System.Exception($"Unkown test type {CurrentTestSetup.CurrentTestType}.");
            }

            return returnedResult;
        }
    }
}
