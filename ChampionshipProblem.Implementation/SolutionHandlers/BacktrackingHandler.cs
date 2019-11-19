namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using System.Collections.Generic;
    using System.Linq;

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
            /*
            IEnumerable<int> betterTeams = result.PointDifferences
                .Select((d, index) => new { D = d, I = index })
                .Where((t) => t.D > 0)
                .OrderByDescending(t => t.D)
                .Select((t) => t.I);

            if (betterTeams.Count() == 1)
            {
                int bTeam = betterTeams.First();
                List<Implementation.Match> remainingMatchesOfBt = championshipProblemInput.Matches
                   .Where((match) =>
                      bTeam == match.Home && (match.Result == MatchResult.Tie || match.Result == MatchResult.WinHome) ||
                      bTeam == match.Away && (match.Result == MatchResult.Tie || match.Result == MatchResult.WinGuest))
                    .ToList();
                bool backtracked = BacktrackingHandler.BacktrackSurplus(bTeam, championshipProblemInput.PointDifferences, result.Matches, null);

                if (backtracked)
                {
                    int[] p = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, result.Matches);
                    return new ChampionshipProblemResult(p, result.Matches, !championshipProblemInput.PointDifferences.Any(d => d > 0));
                } 
            }

            return new ChampionshipProblemResult(championshipProblemInput.PointDifferences, championshipProblemInput.Matches, null);*/
        }

        private static bool BacktrackSurplus(int bTeam, int[] pointDifferences, Implementation.Match[] matches, List<Implementation.Match> alreadyCheckedMatches)
        {
            alreadyCheckedMatches = alreadyCheckedMatches ?? new List<Implementation.Match>();
            List<Implementation.Match> currentCheckedMatches = new List<Implementation.Match>();
            int[] currentDifferences = ComputePointDifferencesHandler.Handle(pointDifferences, matches);
            IEnumerable<Implementation.Match> remainingMatchesOfBetterTeam = matches
                .Where((match) =>
                    match.Home == bTeam && (match.Result == MatchResult.Tie || match.Result == MatchResult.WinHome) ||
                    match.Away == bTeam && (match.Result == MatchResult.Tie || match.Result == MatchResult.WinGuest));

            foreach (Implementation.Match match in remainingMatchesOfBetterTeam)
            {
                if (alreadyCheckedMatches.Contains(match)) continue;

                if (bTeam == match.Home)
                {
                    if (match.Result == MatchResult.WinHome)
                    {
                        match.Result = MatchResult.WinGuest;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (currentDifferences[match.Away] + 3 > 0)
                        {
                            bool didSwitch = BacktrackingHandler.BacktrackSurplus(match.Away, pointDifferences, matches, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.Result = MatchResult.Tie;
                                didSwitch = BacktrackingHandler.BacktrackSurplus(match.Away, pointDifferences, matches, alreadyCheckedMatches);

                                if (!didSwitch)
                                {
                                    match.Result = MatchResult.WinHome;
                                    alreadyCheckedMatches.Remove(match);
                                    currentCheckedMatches.Remove(match);
                                }
                            }
                        }
                    }
                    else if (match.Result == MatchResult.Tie)
                    {
                        match.Result = MatchResult.WinGuest;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (currentDifferences[match.Away] + 2 > 0)
                        {
                            bool didSwitch = BacktrackingHandler.BacktrackSurplus(match.Away, pointDifferences, matches, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.Result = MatchResult.Tie;
                                alreadyCheckedMatches.Remove(match);
                                currentCheckedMatches.Remove(match);
                            }
                        }
                    }
                }
                else if (bTeam == match.Away)
                {
                    if (match.Result == MatchResult.WinGuest)
                    {
                        match.Result = MatchResult.WinHome;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (currentDifferences[match.Home] + 3 > 0)
                        {
                            bool didSwitch = BacktrackingHandler.BacktrackSurplus(match.Home, pointDifferences, matches, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.Result = MatchResult.Tie;
                                didSwitch = BacktrackingHandler.BacktrackSurplus(match.Home, pointDifferences, matches, alreadyCheckedMatches);

                                if (!didSwitch)
                                {
                                    match.Result = MatchResult.WinGuest;
                                    alreadyCheckedMatches.Remove(match);
                                    currentCheckedMatches.Remove(match);
                                }
                            }
                        }
                    }
                    else if (match.Result == MatchResult.Tie)
                    {
                        match.Result = MatchResult.WinHome;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (currentDifferences[match.Home] + 2 > 0)
                        {
                            bool didSwitch = BacktrackingHandler.BacktrackSurplus(pointDifferences[match.Home], pointDifferences, matches, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.Result = MatchResult.Tie;
                                alreadyCheckedMatches.Remove(match);
                                currentCheckedMatches.Remove(match);
                            }
                        }
                    }
                }

                currentDifferences = ComputePointDifferencesHandler.Handle(pointDifferences, matches);
                if (!currentDifferences.Any((entry) => entry > 0))
                {
                    return true;
                }
            }

            // Spiele zurücksetzen, da dieser Weg nicht geht
            currentCheckedMatches.ForEach((match) =>
            {
                match.Result = MatchResult.Tie;
                alreadyCheckedMatches.Remove(match);
            });
            currentDifferences = ComputePointDifferencesHandler.Handle(pointDifferences, matches);
            return false;
        }
    }
}
