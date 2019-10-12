namespace ChampionshipProblem.Implementation
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Services;
    using System.Collections.Generic;
    using System.Linq;

    public class ChampionshipProblemInput
    {
        public int[] PointDifferences { get; set; }

        public Implementation.Match[] Matches { get; set; }

        private int LeagueId { get; set; }

        private string Season { get; set; }

        private int NumberOfMissingStages { get; set; }

        private LeagueStandingService LeagueStandingService { get; set; }

        private List<LeagueStandingEntry> BaseLeagueStanding { get; set; }

        private List<RemainingMatch> CompleteRemainingMatches { get; set; }

        public ChampionshipProblemInput(LeagueStandingService leagueStandingService, int teamId, int stage)
        {
            this.LeagueId = leagueStandingService.LeagueId;
            this.Season = leagueStandingService.Season;
            this.LeagueStandingService = leagueStandingService;

            this.NumberOfMissingStages = leagueStandingService.ChampionshipViewModel.MatchService.GetNumberOfStages(this.LeagueId, this.Season) - stage;
            this.BaseLeagueStanding = LeagueStandingService.CalculateStanding(stage);
            this.CompleteRemainingMatches = LeagueStandingService.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            List<LeagueStandingEntry> unconsideredEntries = new List<LeagueStandingEntry>();
            List<LeagueStandingEntry> leagueStanding = new List<LeagueStandingEntry>();

            foreach (LeagueStandingEntry team in this.BaseLeagueStanding)
            {
                LeagueStandingEntry entry = new LeagueStandingEntry(team.TeamId, team.Name)
                {
                    Points = team.Points,
                    Games = team.Games,
                    Goals = team.Goals,
                    GoalsConceded = team.GoalsConceded
                };
                leagueStanding.Add(entry);
            }

            int specificPoints = leagueStanding.Single((l) => l.TeamId == teamId).Points;
            List<RemainingMatch> remainingMatches = CompleteRemainingMatches.ToList();
            List<RemainingMatch> removedRemainingMatches = new List<RemainingMatch>();

            // Heuristik R1: Alle Spiele für das spezifische Team gewinnen lassen
            foreach (RemainingMatch match in CompleteRemainingMatches)
            {
                if (match.HomeTeamId == teamId)
                {
                    match.MatchResult = MatchResult.WinHome;
                    specificPoints += 3;
                    remainingMatches.Remove(match);
                    removedRemainingMatches.Add(match);
                }
                else if (match.AwayTeamId == teamId)
                {

                    match.MatchResult = MatchResult.WinGuest;
                    specificPoints += 3;
                    remainingMatches.Remove(match);
                    removedRemainingMatches.Add(match);
                }
            }

            // Heuristik R2: schlechtere Teams
            bool hasChanged = false;
            do
            {
                hasChanged = false;
                foreach (LeagueStandingEntry entry in leagueStanding)
                {
                    List<RemainingMatch> matches = remainingMatches
                        .Where((match) => match.HomeTeamId == entry.TeamId || match.AwayTeamId == entry.TeamId)
                        .ToList();
                    if (entry.Points + (matches.Count() * 3) < specificPoints)
                    {
                        foreach (RemainingMatch match in matches)
                        {
                            hasChanged = true;
                            if (match.HomeTeamId == entry.TeamId)
                            {
                                match.MatchResult = MatchResult.WinHome;
                                remainingMatches.Remove(match);
                                removedRemainingMatches.Add(match);
                            }
                            else if (match.AwayTeamId == entry.TeamId)
                            {
                                match.MatchResult = MatchResult.WinGuest;
                                remainingMatches.Remove(match);
                                removedRemainingMatches.Add(match);
                            }

                        }
                    }
                }
            }
            while (hasChanged);

            // Heuristik R3: bessere Teams
            do
            {
                hasChanged = false;
                IEnumerable<LeagueStandingEntry> equalPointsEntries = leagueStanding.Where((leagueStandingEntry) => leagueStandingEntry.Points == specificPoints);
                foreach (LeagueStandingEntry equalPointEntry in equalPointsEntries)
                {
                    foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
                    {
                        if (remainingMatch.HomeTeamId == equalPointEntry.TeamId)
                        {
                            hasChanged = true;
                            remainingMatch.MatchResult = MatchResult.WinGuest;
                            leagueStanding.Single((l) => l.TeamId == remainingMatch.AwayTeamId).Points += 3;
                            remainingMatches.Remove(remainingMatch);
                            removedRemainingMatches.Add(remainingMatch);
                        }
                        else if (remainingMatch.AwayTeamId == equalPointEntry.TeamId)
                        {
                            hasChanged = true;
                            remainingMatch.MatchResult = MatchResult.WinHome;
                            leagueStanding.Single((l) => l.TeamId == remainingMatch.HomeTeamId).Points += 3;
                            remainingMatches.Remove(remainingMatch);
                            removedRemainingMatches.Add(remainingMatch);
                        }
                    }
                }
            }
            while (hasChanged);

            // Die Tabelle aus den Spielen und den schon gesetzten Spielen berechnen
            leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(BaseLeagueStanding, removedRemainingMatches);

            this.PointDifferences = new int[leagueStanding.Count - 1];
            this.Matches = new Implementation.Match[remainingMatches.Count];

            List<LeagueStandingEntry> standingsWithoutSpecificTeam = leagueStanding
                .Where((l) => l.TeamId != teamId)
                .ToList();

            this.PointDifferences = standingsWithoutSpecificTeam
                .Select((entry) => entry.Points - specificPoints)
                .ToArray();
            
            for (int index = 0; index < remainingMatches.Count; index++)
            {
                int home = standingsWithoutSpecificTeam.IndexOf(standingsWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamId == remainingMatches[index].HomeTeamId));
                int away = standingsWithoutSpecificTeam.IndexOf(standingsWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamId == remainingMatches[index].AwayTeamId));
                this.Matches[index] = new Implementation.Match(home, away);
            }
        }

        public bool? CheckBaseSolutionHR4()
        {
            if (PointDifferences.Any((p) => p > 0))
            {
                return false;
            }
            
            if (Matches.Length == 0)
            {
                return true;
            }

            return null;
        }
    }
}
