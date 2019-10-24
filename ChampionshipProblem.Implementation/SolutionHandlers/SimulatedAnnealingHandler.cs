namespace ChampionshipProblem.Implementation
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
            int iterationTimes = 1000000;

            if (result.CanBeChampion.HasValue && result.CanBeChampion == true)
            {
                return result;
            }
            
            if (result.CanBeChampion == false && result.Matches.Length == 0)
            {
                return result;
            }

            int[] pointDifference = result.PointDifferences;
            int previousD = result.PointDifferences.Sum();
            int acceptanceRate = 100;
            double acceptanceDecrease = 0.85;
            for (int i = 0; i < iterationTimes; i++)
            {
                int changeIndex = random.Next(0, result.Matches.Length - 1);
                int change = random.Next(1, 2);
                int acceptedProbability = random.Next(0, 100);

                MatchResult changedResult = result.Matches[changeIndex].Result;

                result.Matches[changeIndex].Result = (MatchResult) (((byte) changedResult + change) % 3);
                pointDifference = ComputePointDifferencesHandler.Handle(pointDifference, result.Matches);

                if (!pointDifference.Any((d) => d > 0))
                {
                    return new ChampionshipProblemResult(pointDifference, result.Matches, true);
                }

                int completeD = pointDifference.Sum();
                if (previousD > completeD || acceptedProbability < acceptanceRate)
                {
                    previousD = completeD;
                }
                else
                {
                    // Rückgängig machen
                    result.Matches[changeIndex].Result = changedResult;
                }

                // Alle tausend Iterationen Rate senken
                if (i % 10000 == 0)
                {
                    acceptanceRate = (int) (acceptanceRate * acceptanceDecrease);
                }
            }

            return new ChampionshipProblemResult(pointDifference, result.Matches, false);
        }
    }
}
