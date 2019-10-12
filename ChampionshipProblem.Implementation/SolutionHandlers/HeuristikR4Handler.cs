namespace ChampionshipProblem.Implementation
{
    using System.Linq;

    public class HeuristikR4Handler
    {
        public ChampionshipProblemResult Handle(ChampionshipProblemInput championshipProblemInput)
        {
            if (championshipProblemInput.PointDifferences.Any((d) => d > 0))
            {
                return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, false);
            }

            if (championshipProblemInput.Matches.Length == 0)
            {
                return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, true);
            }

            return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, null);
        }
    }
}
