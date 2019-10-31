﻿namespace ChampionshipProblem.Test.NUnit.ImplementationTests
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Implementation;
    using ChampionshipProblem.Services;
    using System.Collections.Generic;

    public class CurrentTestSetup
    {
        public const int TestTimeout = 30000;

        public static TestAlgorithm CurrentTestType
        {
            get { return TestAlgorithm.HeuristicR; }
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
                    returnedResult = new EA1And1Handler().Handle(input).CanBeChampion;
                    break;
                case TestAlgorithm.SA:
                    returnedResult = new SimulatedAnnealingHandler().Handle(input).CanBeChampion;
                    break;
                case TestAlgorithm.Backtracking:
                    returnedResult = new SimulatedAnnealingHandler().Handle(input).CanBeChampion;

                    if (!returnedResult.HasValue)
                    {
                        returnedResult = leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[teamNumber].TeamId, false).CanWinChampionship;
                    }

                    if (!returnedResult.HasValue)
                    {
                        returnedResult = new BruteForceHandler().Handle(input).CanBeChampion;
                    }
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
