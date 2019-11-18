﻿namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using System;
    using System.Linq;

    public class SimulatedAnnealingHandler
    {
        public ChampionshipProblemResult Handle(ChampionshipProblemInput championshipProblemInput)
        {
            ChampionshipProblemResult result = new HeuristikL1Handler().Handle(championshipProblemInput);
            Random random = new Random();
            int iterationTimes = 2750000;

            // opti: 20 mit 37 und 5MIL oder 10 MIL
            if (result.CanBeChampion.HasValue && result.CanBeChampion == true)
            {
                return result;
            }
            
            if (result.CanBeChampion.HasValue && result.CanBeChampion == false)
            {
                return result;
            }

            int[] pointDifferences = result.PointDifferences;
            int previousDb = result.PointDifferences
                .Where((d) => d > 0)
                .Sum();
            int acceptanceRate = 100;
            double acceptanceDecrease = 0.85;
            for (int i = 0; i < iterationTimes; i++)
            {
                int changeIndex = random.Next(0, result.Matches.Length - 1);
                int change = random.Next(1, 2);
                int acceptedProbability = random.Next(1, 100);

                MatchResult changedResult = result.Matches[changeIndex].Result;

                result.Matches[changeIndex].Result = (MatchResult) (((byte) changedResult + change) % 3);
                pointDifferences = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, result.Matches);

                if (!pointDifferences.Any((d) => d > 0))
                {
                    return new ChampionshipProblemResult(pointDifferences, result.Matches, true);
                }

                int currentDb = pointDifferences
                    .Where((d) => d > 0)
                    .Sum();
                if (previousDb > currentDb || acceptedProbability < acceptanceRate)
                {
                    previousDb = currentDb;
                }
                else
                {
                    // Rückgängig machen
                    result.Matches[changeIndex].Result = changedResult;
                }

                // Alle tausend Iterationen Rate senken
                if (i % (iterationTimes / 500000) == 0)
                {
                    acceptanceRate = (int) (acceptanceRate * acceptanceDecrease);
                }
            }

            return new ChampionshipProblemResult(pointDifferences, result.Matches, null);
        }
    }
}
