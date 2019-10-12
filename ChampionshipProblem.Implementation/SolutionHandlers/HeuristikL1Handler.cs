namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using System.Linq;

    public class HeuristikL1Handler
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

            int[] pointDifferences = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, championshipProblemInput.Matches);

            if (pointDifferences.Any((d) => d > 0))
            {
                return new ChampionshipProblemResult(pointDifferences, championshipProblemInput.Matches, false);
            }
            else
            {
                return new ChampionshipProblemResult(pointDifferences, championshipProblemInput.Matches, true);
            }
        }
    }
}
