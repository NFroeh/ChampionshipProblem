namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class BruteForceHandler
    {
        public ChampionshipProblemResult Handle(ChampionshipProblemInput championshipProblemInput)
        {
            ChampionshipProblemResult r4Result = new HeuristikR4Handler().Handle(championshipProblemInput);
            if (r4Result.CanBeChampion == false)
            {
                return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, false);
            }
            else if (r4Result.CanBeChampion == true)
            {
                return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, true);
            }

            long numberOfIterations = (long)Math.Pow(3, r4Result.Matches.Length);
            int[] result = r4Result.PointDifferences;
            Match[] matchResults = r4Result.Matches;
            bool canBeChampion = false;
            bool isComputed = true;

            // Zu viele Iterationen, der Test wird abgebrochen
            if (numberOfIterations < 1 )
            {
                isComputed = false;
                numberOfIterations = long.MaxValue;
            }

            for (int index = 0; index < numberOfIterations; index++)
            {
                string ternary = index.ConvertToBase(3);
                Match[] matches = new Match[r4Result.Matches.Length];
                for (int matchIndex = 0; matchIndex < r4Result.Matches.Length; matchIndex++)
                {
                    byte matchResult = (matchIndex < ternary.Length) ? Convert.ToByte(ternary[ternary.Length - 1 - matchIndex].ToString()) : (byte)0;
                    matches[matchIndex] = new Match(r4Result.Matches[matchIndex].Home, r4Result.Matches[matchIndex].Away, (MatchResult)matchResult);
                }

                int[] pointDifferences = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, matches);

                if (!pointDifferences.Any((d) => d > 0))
                {
                    result = pointDifferences;
                    matchResults = matches;
                    canBeChampion = true;
                    return new ChampionshipProblemResult(result, matchResults, canBeChampion);
                }
            }


            bool? res = canBeChampion;
            if (res == false && isComputed == false)
            {
                res = null;
            }

            return new ChampionshipProblemResult(result, matchResults, res);
        }

        public ChampionshipProblemResult HandleParallel(ChampionshipProblemInput championshipProblemInput)
        {
            ChampionshipProblemResult r4Result = new HeuristikR4Handler().Handle(championshipProblemInput);
            if (r4Result.CanBeChampion == false)
            {
                return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, false);
            }
            else if (r4Result.CanBeChampion == true)
            {
                return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, true);
            }

            long numberOfIterations = (long)Math.Pow(3, r4Result.Matches.Length);
            int[] result = r4Result.PointDifferences;
            Match[] matchResults = r4Result.Matches;
            bool canBeChampion = false;
            bool isComputed = true;

            // Zu viele Iterationen, der Test wird abgebrochen
            if (numberOfIterations < 1)
            {
                isComputed = false;
                numberOfIterations = long.MaxValue;
            }

            Parallel.For(0, numberOfIterations, (index, loopState) =>
            {
                string ternary = index.ConvertToBase(3);
                Match[] matches = new Match[r4Result.Matches.Length];
                for (int matchIndex = 0; matchIndex < r4Result.Matches.Length; matchIndex++)
                {
                    byte matchResult = (matchIndex < ternary.Length) ? Convert.ToByte(ternary[matchIndex].ToString()) : (byte)0;
                    matches[matchIndex] = new Match(r4Result.Matches[matchIndex].Home, r4Result.Matches[matchIndex].Away, (MatchResult)matchResult);
                }

                int[] pointDifferences = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, matches);

                if (!pointDifferences.Any((d) => d > 0))
                {
                    result = pointDifferences;
                    matchResults = matches;
                    canBeChampion = true;
                    loopState.Stop();
                }
            });

            bool? res = canBeChampion;
            if (res == false && isComputed == false)
            {
                res = null;
            }

            return new ChampionshipProblemResult(result, matchResults, res);
        }

    }
}
