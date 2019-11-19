namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using System;
    using System.Linq;

    public class EA1And1Handler
    {
        public ChampionshipProblemResult Handle(ChampionshipProblemInput championshipProblemInput, int iterationTimes)
        {
            ChampionshipProblemResult result = new HeuristikL1Handler().Handle(championshipProblemInput);
            Random random = new Random();

            if (result.CanBeChampion.HasValue && result.CanBeChampion == true)
            {
                return result;
            }

            if (result.CanBeChampion.HasValue && result.CanBeChampion == false)
            {
                return result;
            }

            int lastIndividuumDb = result.PointDifferences
                .Where((d) => d > 0)
                .Sum();
            int[] pointDifferences = result.PointDifferences;
            Match[] lastIndividuum = result.Matches;
            for (int i = 0; i < iterationTimes; i++)
            {
                Match[] matches = (Match[])lastIndividuum.Clone();
                foreach (Match m in matches)
                {
                    int changes = random.Next(0, result.Matches.Length);

                    if (changes == 0)
                    {
                        int change = random.Next(1, 2);
                        m.Result = (MatchResult) (((byte) m.Result + change) % 3);
                    }
                }

                pointDifferences = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, matches);

                if (!pointDifferences.Any((d) => d > 0))
                {
                    return new ChampionshipProblemResult(pointDifferences, matches, true);
                }

                int currentDb = pointDifferences
                    .Where((d) => d > 0)
                    .Sum(); 
                if (currentDb <= lastIndividuumDb)
                {
                    lastIndividuum = matches;
                    lastIndividuumDb = currentDb;
                }
            }

            return new ChampionshipProblemResult(pointDifferences, result.Matches, null);
        }
    }
}
