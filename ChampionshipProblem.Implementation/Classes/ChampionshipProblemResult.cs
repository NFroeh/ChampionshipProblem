namespace ChampionshipProblem.Implementation
{
    public class ChampionshipProblemResult
    {
        public ChampionshipProblemResult(int[] pointDifferences, Match[] matches, bool? canBeChampion)
        {
            this.PointDifferences = pointDifferences;
            this.Matches = matches;
            this.CanBeChampion = canBeChampion;
        }

        public int[] PointDifferences { get; private set; }

        public Match[] Matches { get; private set; }

        public bool? CanBeChampion { get; private set; }
    }
}
