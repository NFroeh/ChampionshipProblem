namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using System.Collections.Generic;

    public class BacktrackingHandler
    {
        public ChampionshipProblemResult Handle(ChampionshipProblemInput championshipProblemInput, LeagueStandingService leagueStandingService, int stage, int teamNumber, int iterationTimes)
        {
            ChampionshipProblemResult returnedResult = new SimulatedAnnealingHandler().Handle(championshipProblemInput, iterationTimes);
            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);

            if (!returnedResult.CanBeChampion.HasValue)
            {
                returnedResult = new ChampionshipProblemResult(
                    returnedResult.PointDifferences,
                    returnedResult.Matches,
                    leagueStandingService.CalculateIfTeamCanWinChampionship(stage, standing[teamNumber].TeamId, false).CanWinChampionship
                );
            }

            if (!returnedResult.CanBeChampion.HasValue)
            {
                returnedResult = new BruteForceHandler().Handle(championshipProblemInput);
            }

            return returnedResult;
        }
    }
}
