namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HeuristikLHandler
    {
        public ChampionshipProblemResult Handle(ChampionshipProblemInput championshipProblemInput)
        {
            ChampionshipProblemResult result = new HeuristikL1Handler().Handle(championshipProblemInput);

            if (result.CanBeChampion.HasValue && result.CanBeChampion == true)
            {
                return result;
            }
            
            if (result.CanBeChampion.HasValue && result.CanBeChampion == false)
            {
                return result;
            }

            // Heuristik L2: Betrachte die Spiele der besseren Mannschaften, welche keine andere Mannschaft über sich bringt
            int[] pointDifferences = result.PointDifferences;
            List<int> betterTeams = pointDifferences
                .Select((d, index) => new { D = d, I = index })
                .Where((t) => t.D  > 0)
                .OrderByDescending(t => t.D)
                .Select((t) => t.I)
                .ToList();

            foreach (int betterTeam in betterTeams)
            {
                foreach (Match remainingMatch in result.Matches)
                {
                    // Alle Spiele für das Team überprüfen, was mit keinem Team zu tun hat, welches über dem Team liegt
                    if (remainingMatch.Home == betterTeam && pointDifferences[remainingMatch.Away] + 2 <= 0)
                    {
                        remainingMatch.Result = MatchResult.WinGuest;
                    }
                    else if (remainingMatch.Away == betterTeam && pointDifferences[remainingMatch.Home] + 2 <= 0)
                    {
                        remainingMatch.Result = MatchResult.WinHome;
                    }
                }
            }

            // Berechnen des aktuellen Standes und der neuen besseren Teams
            pointDifferences = ComputePointDifferencesHandler.Handle(pointDifferences, result.Matches);
            betterTeams = pointDifferences
                .Select((d, index) => new { D = d, I = index })
                .Where((t) => t.D > 0)
                .OrderByDescending(t => t.D)
                .Select((t) => t.I)
                .ToList();
            if (betterTeams.Count() == 0)
            {
                return new ChampionshipProblemResult(pointDifferences, championshipProblemInput.Matches, true);
            }

            List<int> teamsAlreadyChecked = new List<int>();
            do
            {
                // Hinzufügen der Teams, welche gecheckt werden
                teamsAlreadyChecked.AddRange(betterTeams);

                // Die besseren Teams durchlaufen und deren Spiele ändern
                foreach (int betterTeam in betterTeams)
                {
                    foreach (Match remainingMatch in result.Matches)
                    {
                        // Alle Spiele für das Team überprüfen, was mit keinem Team zu tun hat, welches über dem Team liegt
                        if (remainingMatch.Home == betterTeam &&
                            teamsAlreadyChecked.None((tId) => tId == remainingMatch.Away))
                        {
                            remainingMatch.Result = MatchResult.WinGuest;
                        }
                        else if (remainingMatch.Away == betterTeam &&
                            teamsAlreadyChecked.None((tId) => tId == remainingMatch.Home))
                        {
                            remainingMatch.Result = MatchResult.WinHome;
                        }
                    }
                }

                // Berechnen des aktuellen Standes und der neuen besseren Teams
                pointDifferences = ComputePointDifferencesHandler.Handle(pointDifferences, result.Matches);
                betterTeams = pointDifferences
                    .Select((d, index) => new { D = d, I = index })
                    .Where((t) => t.D > 0)
                    .OrderByDescending(t => t.D)
                    .Select((t) => t.I)
                    .ToList();

                // LeagueStanding neu berechnen
                if (betterTeams.Count() == 0)
                {
                    return new ChampionshipProblemResult(pointDifferences, championshipProblemInput.Matches, true);
                }
            }
            while (betterTeams.Any((bTeam) => teamsAlreadyChecked.None(tId => bTeam == tId)));

            // Heuristik L3
            // Da die Begegnungen, welche nicht durch Teams aus den betterTeams bestehen, keinen Unterschied machen, müssen nun hier die Spiele betrachtet werden, welche 
            // zwischen den Mannschaften sind
            foreach (int betterTeam in betterTeams)
            {
                IEnumerable<Match> remainingMatchesOfBetterTeam = result.Matches
                   .Where((match) =>
                      betterTeam == match.Home && (match.Result == MatchResult.Tie || match.Result == MatchResult.WinHome) ||
                      betterTeam == match.Away && (match.Result == MatchResult.Tie || match.Result == MatchResult.WinGuest));
                int missingPoints = pointDifferences[betterTeam];

                foreach (Match match in remainingMatchesOfBetterTeam)
                {
                    bool homeIsBetterEntry = betterTeam == match.Home;

                    switch (match.Result)
                    {
                        case MatchResult.Tie:
                            if (homeIsBetterEntry && pointDifferences[match.Away] + 2 <= 0)
                            {
                                match.Result = MatchResult.WinGuest;
                                pointDifferences[match.Away] += 2;
                                pointDifferences[match.Home]--;
                                missingPoints -= 2;
                            }
                            else if (!homeIsBetterEntry && pointDifferences[match.Home] + 2 <= 0)
                            {
                                match.Result = MatchResult.WinHome;
                                pointDifferences[match.Home] += 2;
                                pointDifferences[match.Away]--;
                                missingPoints -= 2;
                            }

                            break;
                        case MatchResult.WinHome:
                            if (homeIsBetterEntry && pointDifferences[match.Away] + 3 <= 0 && missingPoints >= 3)
                            {
                                match.Result = MatchResult.WinGuest;
                                pointDifferences[match.Away] += 3;
                                pointDifferences[match.Home]--;
                                missingPoints--;
                            }
                            else if (homeIsBetterEntry && pointDifferences[match.Away] + 1 <= 0)
                            {
                                match.Result = MatchResult.Tie;
                                pointDifferences[match.Away]++;
                                pointDifferences[match.Home] -= 2;
                                missingPoints -= 2;
                            }

                            break;
                        case MatchResult.WinGuest:
                            if (!homeIsBetterEntry && pointDifferences[match.Home] + 3 <= 0 && missingPoints >= 3)
                            {
                                match.Result = MatchResult.WinHome;
                                pointDifferences[match.Home] += 3;
                                pointDifferences[match.Away]--;
                                missingPoints -= 2;
                            }
                            else if (!homeIsBetterEntry && pointDifferences[match.Home] + 1 <= 0)
                            {
                                match.Result = MatchResult.Tie;
                                pointDifferences[match.Home]++;
                                pointDifferences[match.Away] -= 2;
                                missingPoints--;
                            }

                            break;
                    }

                    if ((homeIsBetterEntry && pointDifferences[match.Home] <= 0) ||
                         !homeIsBetterEntry && pointDifferences[match.Away] <= 0)
                    {
                        break;
                    }
                }
            }

            pointDifferences = ComputePointDifferencesHandler.Handle(championshipProblemInput.PointDifferences, result.Matches);

            if (!pointDifferences.Any((d) => d > 0))
            {
                return new ChampionshipProblemResult(pointDifferences, result.Matches, true);
            }

            return new ChampionshipProblemResult(pointDifferences, result.Matches, null);
        }
    }
}
