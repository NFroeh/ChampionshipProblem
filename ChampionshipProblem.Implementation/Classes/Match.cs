namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;

    public class Match
    {
        public Match(int home, int away)
        {
            this.Home = home;
            this.Away = away;
            this.Result = MatchResult.Tie;
        }

        public Match(int home, int away, MatchResult result)
        {
            this.Home = home;
            this.Away = away;
            this.Result = result;
        }

        public int Home { get; private set; }

        public int Away { get; private set; }

        public MatchResult Result { get; set; }
    }
}
