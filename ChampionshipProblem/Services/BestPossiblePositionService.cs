namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.ResultClasses;
    using ChampionshipProblem.Scheme;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Klasse repräsentiert den Service für die bestmögliche Position.
    /// </summary>
    public class BestPossiblePositionService
    {
        #region fields
        /// <summary>
        /// Die Datengrundlage des Services.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel;

        /// <summary>
        /// Die Liga.
        /// </summary>
        public Scheme.League League;

        /// <summary>
        /// Die Liganummer.
        /// </summary>
        public long LeagueId;

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
        /// Konstruktor zum Erstellen des Services für die beste Position.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage</param>
        /// <param name="league">Die Liga.</param>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="leagueStandingService">Der überliegende Service.</param>
        public BestPossiblePositionService(ChampionshipViewModel championshipViewModel, Scheme.League league, long leagueId, string season, LeagueStandingService leagueStandingService)
        {
            this.ChampionshipViewModel = championshipViewModel;
            this.League = league;
            this.LeagueId = leagueId;
            this.Season = season;
            this.LeagueStandingService = leagueStandingService;
        }
        #endregion

        #region CalculateBestPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der besten möglichen Position für ein Team zu einem bestimmten Spieltag in der LIga.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die bestmögliche Position.</returns>
        public PositionComputationalResult CalculateBestPossibleFinalPositionForTeam(int stage, long teamApiId, bool computeStanding)
        {
            // Service erzeugen und Anzahl der Spiele ermitteln
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);

            // Den aktuellen Stand der Tabelle berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.LeagueStandingService.CalculateStanding(stage);

            // Wenn erst die Hälfte der Spiele gespielt ist, kann noch jeder Platz erreicht werden
            if (stage <= numberOfMatches / 2)
            {
                return new PositionComputationalResult() {
                    Position = 1
                };
            }

            // Wenn es der letzte Spieltag ist, steht die Position fest
            if (stage == numberOfMatches)
            {
                return new PositionComputationalResult() {
                    Position = leagueStandingEntries.ToList().IndexOf(leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId)) + 1
                };
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, teamApiId, (int)numberOfMatches - stage, computeStanding);
        }
        #endregion

        #region CalculateBestPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der besten möglichen Position eines Teams.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die bestmögliche Position</returns>
        public static PositionComputationalResult CalculateBestPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages, bool computeStanding)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            var positionLock = new object();
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
            int bestPosition = leagueStandingEntries.ToList().IndexOf(specificEntry) + 1;
            List<LeagueStandingEntry> computationResult = new List<LeagueStandingEntry>();

            // Nun die Teams ermitteln, welche unerreichbar sind für das Team
            List<LeagueStandingEntry> unconsideredEntries = leagueStandingEntries
                .Where((entry) => (entry.Points + (numberOfMissingStages * 3) <= specificEntry.Points) || (entry.Points > specificEntry.Points + (numberOfMissingStages * 3)))
                .ToList();
            int numberOfUnconsideredEntries = unconsideredEntries.Count();
            do
            {
                numberOfUnconsideredEntries = unconsideredEntries.Count();

                // Vorbereitung der fehlenden Matches
                foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
                {
                    LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId);
                    LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId);

                    // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Sieg" setzen
                    if (remainingMatch.AwayTeamApiId == teamApiId)
                    {
                        remainingMatch.MatchResult = MatchResult.WinGuest;
                        specificEntry.Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                    else if (remainingMatch.HomeTeamApiId == teamApiId)
                    {
                        remainingMatch.MatchResult = MatchResult.WinHome;
                        specificEntry.Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                    else if (homeEntry != null)
                    {
                        remainingMatch.MatchResult = MatchResult.WinHome;
                        homeEntry.Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                    else if (guestEntry != null)
                    {
                        remainingMatch.MatchResult = MatchResult.WinGuest;
                        guestEntry.Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                }

                unconsideredEntries = leagueStandingEntries
                        .Where((entry) => (entry.Points + (numberOfMissingStages * 3) <= specificEntry.Points) || (entry.Points > specificEntry.Points + (numberOfMissingStages * 3)))
                        .ToList();
            }
            while (unconsideredEntries.Count() != numberOfUnconsideredEntries);
            
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
                int home = standingWithoutSpecificTeamAndBetterTeams.IndexOf(standingWithoutSpecificTeamAndBetterTeams.SingleOrDefault((entry) => entry.TeamApiId == remainingMatches[index].HomeTeamApiId));
                int away = standingWithoutSpecificTeamAndBetterTeams.IndexOf(standingWithoutSpecificTeamAndBetterTeams.SingleOrDefault((entry) => entry.TeamApiId == remainingMatches[index].AwayTeamApiId));
                tupleMatches[index] = new Tuple<int, int>(home, away);
            }

            // Die Entries neu sortieren
            Parallel.For(0, numberOfIterations, (index, loopState) =>
            {
                // Die Position ermitteln
                int position = PositionService.CalculatePointDifferencesByIndex((int[])pointDifferences.Clone(), (Tuple<int, int>[])tupleMatches.Clone(), index) + numberOfBetterTeams + 1;

                lock (positionLock)
                {
                    // Wenn die Position besser ist, diese verarbeiten und ggf. Aktionen durchführen
                    if (position < bestPosition)
                    {
                        bestPosition = position;

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

                        if (bestPosition == 1)
                        {
                            loopState.Stop();
                        }
                    }
                }
            });

            return new PositionComputationalResult()
            {
                Position = bestPosition,
                ComputationalStanding = computationResult
            };
        }
        #endregion

        #region CalculateNumberOfRemainingMatchesForBestPossiblePosition
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="teamApiId"></param>
        public int CalculateNumberOfRemainingMatchesForBestPossiblePosition(int stage, long teamApiId)
        {
            // Service erzeugen und Anzahl der Spiele ermitteln
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);
            long numberOfMissingStages = numberOfMatches - stage;

            // Den aktuellen Stand der Tabelle berechnen
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

            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);

            // Nun die Teams ermitteln, welche unerreichbar sind für das Team
            List<LeagueStandingEntry> unconsideredEntries = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                // Falls das Team nurnoch Punktgleich (oder weniger) oder Punktgleich oder mehr Punkte erreichen kann, dann das Team immer gewinnen lassen
                if ((entry.Points + (numberOfMissingStages * 3) <= specificEntry.Points) ||
                    (entry.Points > specificEntry.Points + (numberOfMissingStages * 3)))
                {
                    unconsideredEntries.Add(entry);
                }
            }

            // Vorbereitung der fehlenden Matches
            foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
            {
                LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId);
                LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId);

                // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Sieg" setzen
                if (remainingMatch.AwayTeamApiId == teamApiId)
                {
                    remainingMatches.Remove(remainingMatch);
                }
                else if (remainingMatch.HomeTeamApiId == teamApiId)
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

        #region CalculateBestPossibleFinalPositionForTeam (NotRunning)
        /*
        /// <summary>
        /// Methode zum Ermitteln der besten möglichen Position eines Teams.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Die bestmögliche Position</returns>
        public static PositionComputationalResult CalculateBestPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages, bool computeStanding)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            var positionLock = new object();
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
            int bestPosition = leagueStandingEntries.ToList().IndexOf(specificEntry) + 1;
            List<LeagueStandingEntry> computationResult = new List<LeagueStandingEntry>();

            // Nun die Teams ermitteln, welche unerreichbar sind für das Team
            List<LeagueStandingEntry> unconsideredEntries = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                // Falls das Team nurnoch Punktgleich (oder weniger) oder Punktgleich oder mehr Punkte erreichen kann, dann das Team immer gewinnen lassen
                if ((entry.Points + (numberOfMissingStages * 3) <= specificEntry.Points) ||
                    (entry.Points > specificEntry.Points + (numberOfMissingStages * 3)))
                {
                    unconsideredEntries.Add(entry);
                }
            }

            // Vorbereitung der fehlenden Matches
            foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
            {
                LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId);
                LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId);

                // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Sieg" setzen
                if (remainingMatch.AwayTeamApiId == teamApiId)
                {
                    remainingMatch.MatchResult = MatchResult.WinGuest;
                    specificEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (remainingMatch.HomeTeamApiId == teamApiId)
                {
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    specificEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (homeEntry != null)
                {
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    homeEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (guestEntry != null)
                {
                    remainingMatch.MatchResult = MatchResult.WinGuest;
                    guestEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
            }

            // Falls die Iterationen kleiner als 1 sind, dann wird nur eine Berechnung durchgeführt, da es sonst zu viele wären
            long numberOfIterations = (long)Math.Pow(3, remainingMatches.Count);
            if (numberOfIterations < 1)
            {
                numberOfIterations = 1;
            }

            // Die Entries neu sortieren
            Parallel.For(0, numberOfIterations, (index, loopState) =>
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

                    // Hier könnte jetzt noch die Toreanzahl gesetzt werden
                }

                // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
                List<LeagueStandingEntry> leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);

                // Überprüfen, ob es eine neue beste Position gibt
                LeagueStandingEntry teamEntry = leagueStanding.Single((entry) => entry.TeamApiId == teamApiId);
                int position = leagueStanding.IndexOf(teamEntry) + 1;

                // Noch die Positionen der Teams welche gleich viele Punkte haben, aber über diesem Team stehen abziehen
                int numberOfTeamsWithSamePointsAndShorterName = leagueStanding.Where((entry) => entry.Points == teamEntry.Points && entry.TeamShortName.CompareTo(teamEntry.TeamShortName) == -1).Count();
                position -= numberOfTeamsWithSamePointsAndShorterName;
                lock (positionLock)
                {
                    if (position < bestPosition)
                    {
                        bestPosition = position;

                        if (computeStanding)
                        {
                            computationResult = leagueStanding;
                        }

                        if (bestPosition == 1)
                        {
                            loopState.Stop();
                        }
                    }
                }
            });

            return new PositionComputationalResult()
            {
                Position = bestPosition,
                ComputationalStanding = computationResult
            };
        }*/
        #endregion

    }
}
