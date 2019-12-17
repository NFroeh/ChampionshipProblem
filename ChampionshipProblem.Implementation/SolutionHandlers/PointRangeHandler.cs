namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using System.Collections.Generic;

    public class PointRangeHandler
    {
        public ChampionshipProblemResult Handle(LeagueStandingService leagueStandingService, List<LeagueStandingEntry> standing, int teamNumber)
        {
            long numberOfMatches = leagueStandingService.ChampionshipViewModel.MatchService.GetNumberOfStages(leagueStandingService.LeagueId, leagueStandingService.Season);

            if (standing[teamNumber].Points + (numberOfMatches * 3) < standing[0].Points)
            {
                return new ChampionshipProblemResult(null, null, false);
            }
            else
            {
                return new ChampionshipProblemResult(null, null, true);
            }
        }
    }
}
