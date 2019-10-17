namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using System;
    using System.Linq;

    public class EA1And1Handler
    {
        public ChampionshipProblemResult Handle(ChampionshipProblemInput championshipProblemInput)
        {
            ChampionshipProblemResult result = new HeuristikL1Handler().Handle(championshipProblemInput);
            Random random = new Random();
            int iterationTimes = 100000;

            if (result.CanBeChampion.HasValue && result.CanBeChampion == true)
            {
                return result;
            }

            int lastIndividuumD = championshipProblemInput.PointDifferences.Sum();
            int[] pointDifferences = championshipProblemInput.PointDifferences;
            Match[] lastIndividuum = championshipProblemInput.Matches;
            for (int i = 0; i < iterationTimes; i++)
            {
                Match[] matches = (Match[]) lastIndividuum.Clone();
                foreach (Implementation.Match m in matches)
                {
                    int changes = random.Next(0, result.Matches.Length + 1);

                    if (changes == 0)
                    {
                        m.Result = (MatchResult) ((byte) (m.Result + 1) % 3);
                    }
                }

                pointDifferences = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, matches);

                int sumD = pointDifferences.Sum();
                if (sumD <= lastIndividuumD)
                {
                    lastIndividuum = matches;
                    lastIndividuumD = sumD;
                }

                if (!pointDifferences.Any((d) => d > 0))
                {
                    return new ChampionshipProblemResult(pointDifferences, result.Matches, true);
                }
            }

            return new ChampionshipProblemResult(pointDifferences, result.Matches, false);
        }
    }
}
