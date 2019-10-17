namespace ChampionshipProblem.Implementation
{
    public class ComputePointDifferencesHandler
    {
        public static int[] Handle(int[] pointDifferences, Match[] matches)
        {
            int[] p = (int[]) pointDifferences.Clone();
            foreach(Match match in matches)
            {
                switch (match.Result)
                {
                    case Classes.MatchResult.WinHome:
                        p[match.Home] += 3;
                        break;
                    case Classes.MatchResult.WinGuest:
                        p[match.Away] += 3;
                        break;
                    case Classes.MatchResult.Tie:
                        p[match.Home] += 1;
                        p[match.Away] += 1;
                        break;
                    default:
                        throw new System.Exception($"Ungültiges MatchResult {match.Result}");
                }
            }

            return p;
        }
    }
}
