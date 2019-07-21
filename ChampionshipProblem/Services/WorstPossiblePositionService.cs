namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.ResultClasses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Klasse repräsentiert den Service für die schlechtmöglichste Position.
    /// </summary>
    public class WorstPossiblePositionService
    {
        #region fields
        /// <summary>
        /// Die Datengrundlage des Services.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel;

        /// <summary>
        /// Die Liga.
        /// </summary>
        public League League;

        /// <summary>
        /// Die Liganummer.
        /// </summary>
        public int LeagueId;

        /// <summary>
        /// Die Saison.
        /// </summary>
        public string Season;

        /// <summary>
        /// Der LeaguestandingService.
        /// </summary>
        public LeagueStandingService LeagueStandingService;
        #endregion

        #region ctors
        /// <summary>
        /// Konstruktor zum Erstellen des Services für die schlechtmöglichste Position.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage</param>
        /// <param name="league">Die Liga.</param>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="leagueStandingService">Der überliegende Service.</param>
        public WorstPossiblePositionService(ChampionshipViewModel championshipViewModel, League league, int leagueId, string season, LeagueStandingService leagueStandingService)
        {
            this.ChampionshipViewModel = championshipViewModel;
            this.League = league;
            this.LeagueId = leagueId;
            this.Season = season;
            this.LeagueStandingService = leagueStandingService;
        }
        #endregion

        #region CalculateWorstPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der schlechtmöglichsten Position für ein Team zu einem bestimmten Spieltag in der Liga.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die schlechtmöglichste Position.</returns>
        public PositionComputationalResult CalculateWorstPossibleFinalPositionForTeam(int stage, int teamId, bool computeStanding)
        {
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);

            // Den aktuellen Stand berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.LeagueStandingService.CalculateStanding(stage);

            // Wenn erst die Hälfte der Spiele gespielt ist, kann noch jeder Platz erreicht werden
            if (stage <= numberOfMatches / 2)
            {
                return new PositionComputationalResult()
                {
                    Position = leagueStandingEntries.Count()
                };
            }

            // Wenn es der letzte Spieltag ist, steht die Position fest
            if (stage == numberOfMatches)
            {
                return new PositionComputationalResult()
                {
                    Position = leagueStandingEntries.ToList().IndexOf(leagueStandingEntries.Single((entry) => entry.TeamId == teamId)) + 1
                };
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, teamId, (int)numberOfMatches - stage, computeStanding);
        }
        #endregion

        #region CalculateWorstPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der schlechtmöglichsten Position eines Teams.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die schlechtmöglichste Position</returns>
        public static PositionComputationalResult CalculateWorstPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages, bool computeStanding)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            var positionLock = new object();
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamId == teamApiId);
            int worstPosition = leagueStandingEntries.ToList().IndexOf(specificEntry) + 1;
            int numberOfTeams = leagueStandingEntries.Count();
            List<LeagueStandingEntry> computationResult = new List<LeagueStandingEntry>();

            // Nun die Teams ermitteln, welche unerreichbar sind für das Team
            List<LeagueStandingEntry> unconsideredEntries = leagueStandingEntries
                .Where((entry) => (entry.Points + (numberOfMissingStages * 3) < specificEntry.Points) ||
                                (entry.Points >= specificEntry.Points))
                .ToList();
            int numberOfUnconsideredEntries = unconsideredEntries.Count();

            do
            {
                // Die Anzahl aktualisieren
                numberOfUnconsideredEntries = unconsideredEntries.Count();

                // Vorbereitung der fehlenden Matches
                foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
                {
                    LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.HomeTeamId);
                    LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.AwayTeamId);

                    // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Lose" setzen
                    if (remainingMatch.AwayTeamId == teamApiId)
                    {
                        remainingMatch.MatchResult = MatchResult.WinHome;
                        leagueStandingEntries.Single((entry) => entry.TeamId == remainingMatch.HomeTeamId).Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                    else if (remainingMatch.HomeTeamId == teamApiId)
                    {
                        remainingMatch.MatchResult = MatchResult.WinGuest;
                        leagueStandingEntries.Single((entry) => entry.TeamId == remainingMatch.AwayTeamId).Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                    else if (homeEntry != null)
                    {
                        remainingMatch.MatchResult = MatchResult.WinGuest;
                        leagueStandingEntries.Single((entry) => entry.TeamId == remainingMatch.AwayTeamId).Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                    else if (guestEntry != null)
                    {
                        remainingMatch.MatchResult = MatchResult.WinHome;
                        leagueStandingEntries.Single((entry) => entry.TeamId == remainingMatch.HomeTeamId).Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                }

                unconsideredEntries = leagueStandingEntries
                        .Where((entry) => (entry.Points + (numberOfMissingStages * 3) < specificEntry.Points) || (entry.Points >= specificEntry.Points))
                        .ToList();
            }
            while (numberOfUnconsideredEntries != unconsideredEntries.Count());
            

            // Falls die Iterationen kleiner als 1 sind, dann wird nur eine Berechnung durchgeführt, da es sonst zu viele wären
            long numberOfIterations = (long)Math.Pow(3, remainingMatches.Count);
            if (numberOfIterations < 1)
            {
                numberOfIterations = 1;
            }

            // Den spezifizierten Eintrag rauswerfen
            List<LeagueStandingEntry> standingWithoutSpecificTeamAndBetterTeams = leagueStandingEntries.ToList();
            standingWithoutSpecificTeamAndBetterTeams.Remove(specificEntry);

            // Alle Teams mit mehr Punkten rauswerfen und die Anzahl abspeichern
            int numberOfBetterTeams = standingWithoutSpecificTeamAndBetterTeams.RemoveAll((betterTeams) => betterTeams.Points > specificEntry.Points);

            // Die Punkteunterschiede ermitteln
            int[] pointDifferences = standingWithoutSpecificTeamAndBetterTeams.Select((entry) => entry.Points - specificEntry.Points).ToArray();

            // Die fehlenden Spiele als Tupel-Array zusammenabuen
            Tuple<int, int>[] tupleMatches = new Tuple<int, int>[remainingMatches.Count];
            for (int index = 0; index < remainingMatches.Count; index++)
            {
                int home = standingWithoutSpecificTeamAndBetterTeams.IndexOf(standingWithoutSpecificTeamAndBetterTeams.SingleOrDefault((entry) => entry.TeamId == remainingMatches[index].HomeTeamId));
                int away = standingWithoutSpecificTeamAndBetterTeams.IndexOf(standingWithoutSpecificTeamAndBetterTeams.SingleOrDefault((entry) => entry.TeamId == remainingMatches[index].AwayTeamId));
                tupleMatches[index] = new Tuple<int, int>(home, away);
            }

            // Die Entries neu sortieren
            Parallel.For(0, numberOfIterations, (index, loopState) =>
            {
                // Berechnen der Position des aktuellen Teams
                int position = PositionService.CalculatePointDifferencesWithTieByIndex((int[])pointDifferences.Clone(), (Tuple<int, int>[])tupleMatches.Clone(), index) + numberOfBetterTeams + 1;

                lock (positionLock)
                {
                    if (position > (int)worstPosition)
                    {
                        worstPosition = position;

                        if (computeStanding)
                        {
                            // Hole die ternäre Repräsentation der Zahl
                            string ternary = index.ConvertToBase(3);

                            // Durchlaufe die Begegnungen, um die Ergebnisse zu setzen
                            for (int matchIndex = 0; matchIndex < remainingMatches.Count(); matchIndex++)
                            {
                                // Entweder Unentschieden setzen oder den Match Wert ermitteln, falls vorhanden
                                // Hier muss der Char vorher in einen String umgewandelt werden, da sonst die Konvertierung nach ASCI gemacht wird
                                byte matchResult = (matchIndex < ternary.Length) ? Convert.ToByte(ternary[matchIndex].ToString()) : (byte)0;

                                remainingMatches[matchIndex].MatchResult = (MatchResult)matchResult;
                            }

                            // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
                            List<LeagueStandingEntry> leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);

                            computationResult = leagueStanding;
                        }

                        if (worstPosition == numberOfTeams)
                        {
                            loopState.Stop();
                        }
                    }
                }
            });

            return new PositionComputationalResult()
            {
                Position = worstPosition,
                ComputationalStanding = computationResult
            };
        }
        #endregion

        #region CalculateNumberOfRemainingMatchesForWorstPossiblePosition
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="teamId">Die Teamnummer.</param>
        public int CalculateNumberOfRemainingMatchesForWorstPossiblePosition(int stage, long teamId)
        {
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);
            long numberOfMissingStages = numberOfMatches - stage;

            // Den aktuellen Stand berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.LeagueStandingService.CalculateStanding(stage);

            // Wenn erst die Hälfte der Spiele gespielt ist, kann noch jeder Platz erreicht werden
            if (stage <= numberOfMatches / 2)
            {
                return 1;
            }

            // Wenn es der letzte Spieltag ist, steht die Position fest
            if (stage == numberOfMatches)
            {
                return 1;
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamId == teamId);
            int numberOfTeams = leagueStandingEntries.Count();

            // Nun die Teams ermitteln, welche unerreichbar sind für das Team
            List<LeagueStandingEntry> unconsideredEntries = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                // Falls das Team nichtmehr erreich bar ist, oder das Team über dem Team steht, dann sind diese Teams irrelevant und diese dürfen alle Spiele gewinnen
                if ((entry.Points + (numberOfMissingStages * 3) < specificEntry.Points) ||
                    (entry.Points >= specificEntry.Points))
                {
                    unconsideredEntries.Add(entry);
                }
            }

            // Vorbereitung der fehlenden Matches
            foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
            {
                LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.HomeTeamId);
                LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.AwayTeamId);

                // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Lose" setzen
                if (remainingMatch.AwayTeamId == teamId)
                {
                    remainingMatches.Remove(remainingMatch);
                }
                else if (remainingMatch.HomeTeamId == teamId)
                {
                    remainingMatches.Remove(remainingMatch);
                }
                else if (homeEntry != null)
                {
                    remainingMatches.Remove(remainingMatch);
                }
                else if (guestEntry != null)
                {
                    remainingMatches.Remove(remainingMatch);
                }
            }

            return remainingMatches.Count;
        }
        #endregion
    }
}
