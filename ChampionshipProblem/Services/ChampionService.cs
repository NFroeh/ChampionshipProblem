﻿namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Classes.ResultClasses;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Klasse repräsentiert den Service für die Meisterfrage.
    /// </summary>
    public class ChampionService
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
        /// Konstruktor zum Erstellen des Services für die Meisterfrage.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage</param>
        /// <param name="league">Die Liga.</param>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="leagueStandingService">Der überliegende Service.</param>
        public ChampionService(ChampionshipViewModel championshipViewModel, League league, int leagueId, string season, LeagueStandingService leagueStandingService)
        {
            this.ChampionshipViewModel = championshipViewModel;
            this.League = league;
            this.LeagueId = leagueId;
            this.Season = season;
            this.LeagueStandingService = leagueStandingService;
        }
        #endregion

        #region CalculateIfTeamCanWinChampionship
        /// <summary>
        /// Methode zum Ermitteln, ob eine bestimmte Mannschaft noch Meister werden kann.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public ChampionComputationalResult CalculateIfTeamCanWinChampionship(int stage, int teamId, bool computeStanding)
        {
            // Anzahl der Spiele ermitteln
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfStages(this.LeagueId, this.Season);

            // Den aktuellen Stand der Tabelle berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.LeagueStandingService.CalculateStanding(stage);

            // Wenn erst die Hälfte der Spiele gespielt ist, kann noch jeder Platz erreicht werden
            if (stage <= numberOfMatches / 2)
            {
                return new ChampionComputationalResult() {
                    CanWinChampionship = true
                };
            }

            // Wenn es der letzte Spieltag ist, steht die Position fest
            if (stage == numberOfMatches)
            {
                int neededPoints = leagueStandingEntries.First().Points;
                return new ChampionComputationalResult(leagueStandingEntries) {
                    CanWinChampionship = leagueStandingEntries.Single((entry) => entry.TeamId == teamId).Points == neededPoints
                };
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return ChampionService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, teamId, (int)numberOfMatches - stage, computeStanding);
        }
        #endregion

        #region CalculateIfTeamCanWinChampionship
        /// <summary>
        /// Methode zum Ermitteln, ob ein bestimmtes Team noch meister werden kann.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public static ChampionComputationalResult CalculateIfTeamCanWinChampionship(List<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, int teamId, int numberOfMissingStages, bool computeStanding)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamId == teamId);
            LeagueStandingEntry first = leagueStandingEntries.First();
            List<LeagueStandingEntry> computationResult = new List<LeagueStandingEntry>();
            List<RemainingMatch> completeRemainingMatches = remainingMatches.ToList();
            bool canWin = false;

            // Zuerst überprüfen, ob der aktuell erste überhaupt mit Punkten noch eingeholt werden kann
            if (specificEntry.Points + numberOfMissingStages * 3 < first.Points)
            {
                return new ChampionComputationalResult(computationResult)
                {
                    CanWinChampionship = false
                };
            }

            // Nun die Teams ermitteln, welche unerreichbar sind zum betrachteten Team
            List<LeagueStandingEntry> unconsideredEntries = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                // Teams ermitteln, welche definitiv unter diesem Team landen
                if ((entry.Points + (numberOfMissingStages * 3)) <= specificEntry.Points)
                {
                    unconsideredEntries.Add(entry);
                }
            }

            // Vorbereitung der fehlenden Matches
            foreach (RemainingMatch remainingMatch in completeRemainingMatches)
            {
                LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.HomeTeamId);
                LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.AwayTeamId);

                // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Sieg" setzen
                if (remainingMatch.AwayTeamId == teamId)
                {
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.HomeTeamId).Games++;
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.AwayTeamId).Games++;
                    remainingMatch.MatchResult = MatchResult.WinGuest;
                    specificEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (remainingMatch.HomeTeamId == teamId)
                {
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.HomeTeamId).Games++;
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.AwayTeamId).Games++;
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    specificEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (homeEntry != null)
                {
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.HomeTeamId).Games++;
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.AwayTeamId).Games++;
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    homeEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (guestEntry != null)
                {
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.HomeTeamId).Games++;
                    leagueStandingEntries.Single((team) => team.TeamId == remainingMatch.AwayTeamId).Games++;
                    remainingMatch.MatchResult = MatchResult.WinGuest;
                    guestEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
            }

            // Da nun die eigenen Spiele auf Sieg gesetzt werden konnten und alle unerheblichen Spiele gewonnen werden, muss, falls Teams Punktegleich sind, diese noch alle verlieren
            IEnumerable<LeagueStandingEntry> equalPointsEntries = leagueStandingEntries.Where((leagueStandingEntry) => leagueStandingEntry.Points == specificEntry.Points);
            int currentNumberOfEqualPointEntries = equalPointsEntries.Count();
            do
            {
                // Die Anzahl aktualisieren
                currentNumberOfEqualPointEntries = equalPointsEntries.Count();

                foreach (LeagueStandingEntry equalPointEntry in equalPointsEntries)
                {
                    foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
                    {
                        LeagueStandingEntry home = leagueStandingEntries.SingleOrDefault((leagueStandingEntry) => remainingMatch.HomeTeamId == leagueStandingEntry.TeamId);
                        LeagueStandingEntry away = leagueStandingEntries.SingleOrDefault((leagueStandingEntry) => remainingMatch.AwayTeamId == leagueStandingEntry.TeamId);

                        if (remainingMatch.AwayTeamId == equalPointEntry.TeamId)
                        {
                            remainingMatch.MatchResult = MatchResult.WinHome;
                            home.Points += 3;
                            home.Games++;
                            away.Games++;
                            remainingMatches.Remove(remainingMatch);

                        }
                        else if (remainingMatch.HomeTeamId == equalPointEntry.TeamId)
                        {
                            remainingMatch.MatchResult = MatchResult.WinGuest;
                            away.Points += 3;
                            home.Games++;
                            away.Games++;
                            remainingMatches.Remove(remainingMatch);
                        }
                    }
                }

                // Die Einträge aktualisieren, für die redundante Berechung
                equalPointsEntries = leagueStandingEntries.Where((leagueStandingEntry) => leagueStandingEntry.Points == specificEntry.Points);
            }
            while (equalPointsEntries.Count() != currentNumberOfEqualPointEntries);


            // Falls jetzt jemand vor dem Team ist, dann kann dieses nichtmehr Meister werden
            if (leagueStandingEntries.Where((leagueStandingEntry) => leagueStandingEntry.Points > specificEntry.Points).Count() > 0)
            {
                return new ChampionComputationalResult(computationResult, completeRemainingMatches)
                {
                    CanWinChampionship = false,
                };
            }

            // Falls die Iterationen kleiner als 1 sind, dann wird nur Backtracking durchgeführt, da es sonst zu viele Iterationen wären
            long numberOfIterations = (long)Math.Pow(3, remainingMatches.Count);
            if (numberOfIterations < 1 || numberOfIterations > 10000000000)
            {
                ChampionComputationalResult result = ChampionService.PerformBacktracking(leagueStandingEntries, remainingMatches, teamId);
                result.MissingRemainingMatches = completeRemainingMatches;
                result.ComputeWinPercentages();
                return result;
            }

            // Dann den spezifizierten Eintrag rauswerfen
            List<LeagueStandingEntry> standingWithoutSpecificTeam = leagueStandingEntries.ToList();
            standingWithoutSpecificTeam.Remove(specificEntry);

            // Die Punkteunterschiede ermitteln
            int[] pointDifferences = standingWithoutSpecificTeam.Select((entry) => entry.Points - specificEntry.Points).ToArray();

            // Die fehlenden Spiele ermitteln
            Tuple<int, int>[] tupleMatches = new Tuple<int, int>[remainingMatches.Count];
            for (int index = 0; index < remainingMatches.Count; index++)
            {
                int home = standingWithoutSpecificTeam.IndexOf(standingWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamId == remainingMatches[index].HomeTeamId));
                int away = standingWithoutSpecificTeam.IndexOf(standingWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamId == remainingMatches[index].AwayTeamId));
                tupleMatches[index] = new Tuple<int, int>(home, away);
            }

            // Die Entries neu sortieren
            Parallel.For(0, numberOfIterations, (index, loopState) =>
            {
                // Position berechnen
                int position = PositionService.CalculatePointDifferencesByIndex((int[])pointDifferences.Clone(), (Tuple<int, int>[])tupleMatches.Clone(), index);

                // Wenn das Team erster wurde, aufhören und ggf. Aktionen durchführen
                if (position == 0)
                {
                    canWin = true;

                    if (computeStanding)
                    {
                        // Hole die ternäre Repräsentation der Zahl
                        string ternary = index.ConvertToBase(3);

                        // Durchlaufe die Begegnungen, um die Ergebnisse zu setzen
                        for (int matchIndex = 0; matchIndex < remainingMatches.Count(); matchIndex++)
                        {
                            // Entweder Unentschieden setzen oder den Match Wert ermitteln, falls vorhanden
                            // Hier muss der Char vorher in einen String umgewandelt werden, da sonst die Konvertierung nach ASCI gemacht wird
                            byte matchResult = (matchIndex < ternary.Length) ? Convert.ToByte(ternary[ternary.Length - 1 - matchIndex].ToString()) : (byte)0;

                            remainingMatches[matchIndex].MatchResult = (MatchResult)matchResult;
                        }

                        // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
                        List<LeagueStandingEntry> leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);

                        computationResult = leagueStanding;
                    }

                    loopState.Stop();
                }
            });

            return new ChampionComputationalResult(computationResult, completeRemainingMatches)
            {
                CanWinChampionship = canWin
            };
        }
        #endregion

        #region CalculateNumberOfRemainingMatchesForChampion
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="teamId">Die TeamId.</param>
        public int CalculateNumberOfRemainingMatchesForChampion(int stage, long teamId)
        {
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfStages(this.LeagueId, this.Season);
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
            LeagueStandingEntry first = leagueStandingEntries.First();

            // Zuerst überprüfen, ob der aktuell erste überhaupt mit Punkten noch eingeholt werden kann
            if (specificEntry.Points + numberOfMissingStages * 3 < first.Points)
            {
                return 1;
            }

            // Nun die Teams ermitteln, welche unerreichbar sind zum betrachteten Team
            List<LeagueStandingEntry> unconsideredEntries = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                // Teams ermitteln, welche definitiv unter diesem Team landen
                if ((entry.Points + (numberOfMissingStages * 3)) <= specificEntry.Points)
                {
                    unconsideredEntries.Add(entry);
                }
            }

            // Vorbereitung der fehlenden Matches
            foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
            {
                LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.HomeTeamId);
                LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamId == remainingMatch.AwayTeamId);

                // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Sieg" setzen
                if (remainingMatch.AwayTeamId == teamId)
                {
                    remainingMatch.MatchResult = MatchResult.WinGuest;
                    specificEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (remainingMatch.HomeTeamId == teamId)
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

            return remainingMatches.Count;
        }
        #endregion

        #region PerformBacktracking
        /// <summary>
        /// Methode zum Durchführen des Backtrackings.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamId">Die TeamId.</param>
        /// <returns>Das Ergebnis.</returns>
        public static ChampionComputationalResult PerformBacktracking(IEnumerable<LeagueStandingEntry> leagueStandingEntries, IEnumerable<RemainingMatch> remainingMatches, int teamId)
        {
            // Allen Ergebnissen unentschieden setzen
            foreach (RemainingMatch match in remainingMatches)
            {
                match.MatchResult = MatchResult.Tie;
            }

            // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
            List<LeagueStandingEntry> currentStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);
            List<LeagueStandingEntry> computationResult = new List<LeagueStandingEntry>();

            // Betrachtendes Team ermitteln
            LeagueStandingEntry specificTeam = leagueStandingEntries
                .Single((entry) => entry.TeamId == teamId);

            // Ermittle die Teams, die über dem betrachteten Team stehen
            List<LeagueStandingEntry> betterTeams = currentStanding
                .Where((entry) => entry.Points > specificTeam.Points)
                .ToList();

            List<int> teamsAlreadyChecked = new List<int>();
            do
            {
                // Hinzufügen der Teams, welche gecheckt werden
                teamsAlreadyChecked.AddRange(betterTeams.Select((t) => t.TeamId));

                // Die besseren Teams durchlaufen und deren Spiele ändern
                foreach (LeagueStandingEntry betterTeam in betterTeams)
                {
                    foreach (RemainingMatch remainingMatch in remainingMatches)
                    {
                        // Alle Spiele für das Team überprüfen, was mit keinem Team zu tun hat, welches über dem Team liegt
                        if (remainingMatch.HomeTeamId == betterTeam.TeamId && 
                            teamsAlreadyChecked.None((tId) => tId == remainingMatch.AwayTeamId))
                        {
                            remainingMatch.MatchResult = MatchResult.WinGuest;
                        }
                        else if (remainingMatch.AwayTeamId == betterTeam.TeamId && 
                            teamsAlreadyChecked.None((tId) => tId == remainingMatch.HomeTeamId))
                        {
                            remainingMatch.MatchResult = MatchResult.WinHome;
                        }
                    }
                }

                // Berechnen des aktuellen Standes und der neuen besseren Teams
                currentStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);
                betterTeams = currentStanding
                    .Where((entry) => entry.Points > specificTeam.Points)
                    .ToList();

                // LeagueStanding neu berechnen
                if (betterTeams.Count() == 0)
                {
                    return new ChampionComputationalResult(currentStanding)
                    {
                        CanWinChampionship = true
                    };
                }
            }
            while (betterTeams.Any((bTeam) => teamsAlreadyChecked.None(tId => bTeam.TeamId == tId)));

            // Da die Begegnungen, welche nicht durch Teams aus den betterTeams bestehen, keinen Unterschied machen, müssen nun hier die Spiele betrachtet werden, welche 
            // zwischen den Mannschaften sind
            betterTeams = betterTeams.OrderBy((bt) => bt.Points).ToList();
            foreach (LeagueStandingEntry betterTeam in betterTeams)
            {
                IEnumerable<RemainingMatch> remainingMatchesOfBetterTeam = remainingMatches
                   .Where((match) =>
                      betterTeam.TeamId == match.HomeTeamId && (match.MatchResult == MatchResult.Tie || match.MatchResult == MatchResult.WinHome) ||
                      betterTeam.TeamId == match.AwayTeamId && (match.MatchResult == MatchResult.Tie || match.MatchResult == MatchResult.WinGuest));
                int missingPoints = betterTeam.Points - specificTeam.Points;
                foreach (RemainingMatch match in remainingMatchesOfBetterTeam)
                {
                    LeagueStandingEntry homeTeam = currentStanding.SingleOrDefault((team) => team.TeamId == match.HomeTeamId);
                    LeagueStandingEntry awayTeam = currentStanding.SingleOrDefault((team) => team.TeamId == match.AwayTeamId);
                    bool homeIsBetterEntry = betterTeam.TeamId == homeTeam.TeamId;

                    switch (match.MatchResult)
                    {
                        case MatchResult.Tie:
                            if (homeIsBetterEntry && awayTeam.Points + 2 <= specificTeam.Points)
                            {
                                match.MatchResult = MatchResult.WinGuest;
                                awayTeam.Points += 2;
                                homeTeam.Points--;
                                missingPoints -= 2;
                            }
                            else if (!homeIsBetterEntry && homeTeam.Points + 2 <= specificTeam.Points)
                            {
                                match.MatchResult = MatchResult.WinHome;
                                homeTeam.Points += 2;
                                awayTeam.Points--;
                                missingPoints -= 2;
                            }

                            break;
                        case MatchResult.WinHome:
                            if (homeIsBetterEntry && awayTeam.Points + 3 <= specificTeam.Points && missingPoints >=3)
                            {
                                match.MatchResult = MatchResult.WinGuest;
                                awayTeam.Points += 3;
                                homeTeam.Points--;
                                missingPoints--;
                            }
                            else if (homeIsBetterEntry && awayTeam.Points + 1 <= specificTeam.Points)
                            {
                                match.MatchResult = MatchResult.Tie;
                                awayTeam.Points++;
                                homeTeam.Points -= 2;
                                missingPoints -= 2;
                            }

                            break;
                        case MatchResult.WinGuest:
                            if (!homeIsBetterEntry && homeTeam.Points + 3 <= specificTeam.Points && missingPoints >= 3)
                            { 
                                match.MatchResult = MatchResult.WinHome;
                                homeTeam.Points += 3;
                                awayTeam.Points--;
                                missingPoints--;
                            }
                            else if (!homeIsBetterEntry && homeTeam.Points + 1 <= specificTeam.Points)
                            {
                                match.MatchResult = MatchResult.Tie;
                                homeTeam.Points++;
                                awayTeam.Points -= 2;
                                missingPoints -= 2;
                            }

                            break;
                    }

                    if ((homeIsBetterEntry && homeTeam.Points <= specificTeam.Points) || 
                         !homeIsBetterEntry && awayTeam.Points <= specificTeam.Points)
                    {
                        break;
                    }
                }
            }

            // Die Tabelle neu berechnen und ein letztes mal prüfen
            currentStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);
            betterTeams = currentStanding
                .Where((entry) => entry.Points > specificTeam.Points)
                .ToList();

            if (betterTeams.Count == 1)
            {
                List<RemainingMatch> remainingMatchesOfBt = remainingMatches
                   .Where((match) =>
                      betterTeams.First().TeamId == match.HomeTeamId && (match.MatchResult == MatchResult.Tie || match.MatchResult == MatchResult.WinHome) ||
                      betterTeams.First().TeamId == match.AwayTeamId && (match.MatchResult == MatchResult.Tie || match.MatchResult == MatchResult.WinGuest))
                    .ToList();
                LeagueStandingEntry betterTeam = betterTeams.First();
                ChampionService.ComputeIfTeamIsSwitchable(betterTeam, leagueStandingEntries, remainingMatches, specificTeam);
            }

            // Die Tabelle neu berechnen und ein letztes mal prüfen
            currentStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);
            betterTeams = currentStanding
                .Where((entry) => entry.Points > specificTeam.Points)
                .ToList();

            // LeagueStanding neu berechnen
            if (betterTeams.Count() == 0)
            {
                return new ChampionComputationalResult(currentStanding, remainingMatches.ToList())
                {
                    CanWinChampionship = true
                };
            }

            #region TryAll
            /*
            // Wenn nicht die restlichen Spiele der besseren Teams testen
            List<RemainingMatch> remainingMatchesOfRemainingTeam = remainingMatches
                .Where((match) => betterTeams.Any((bt) => bt.TeamId == match.HomeTeamId || bt.TeamId == match.AwayTeamId))
                .ToList();
            List<RemainingMatch> missingMatches = remainingMatchesOfRemainingTeam.ToList();

            // Die Spiele auf unentschieden setzen und entfernen
            foreach (RemainingMatch match in remainingMatchesOfRemainingTeam)
            {
                if (betterTeams.Any((bt) => bt.TeamId == match.AwayTeamId))
                {
                    if (match.MatchResult != MatchResult.WinHome)
                    {
                        if (match.MatchResult == MatchResult.WinGuest)
                        {
                            currentStanding.Single((team) => team.TeamId == match.HomeTeamId).Points += 1;
                            currentStanding.Single((team) => team.TeamId == match.AwayTeamId).Points -= 2;
                        }

                        match.MatchResult = MatchResult.Tie;
                    }
                    else
                    {
                        missingMatches.Remove(match);
                    }
                }
                else if (betterTeams.Any((bt) => bt.TeamId == match.HomeTeamId))
                {
                    if (match.MatchResult != MatchResult.WinGuest)
                    {
                        if (match.MatchResult == MatchResult.WinHome)
                        {
                            currentStanding.Single((team) => team.TeamId == match.HomeTeamId).Points += 1;
                            currentStanding.Single((team) => team.TeamId == match.AwayTeamId).Points -= 2;
                        }

                        match.MatchResult = MatchResult.Tie;
                    }
                    else
                    {
                        missingMatches.Remove(match);
                    }
                }
            }

            long numberOfIterations = (long) Math.Pow(3, remainingMatchesOfRemainingTeam.Count());

            // Dann den spezifizierten Eintrag rauswerfen
            List<LeagueStandingEntry> standingWithoutSpecificTeam = currentStanding.ToList();
            standingWithoutSpecificTeam.Remove(specificTeam);

            // Die Punkteunterschiede ermitteln
            int[] pointDifferences = standingWithoutSpecificTeam.Select((entry) => entry.Points - specificTeam.Points).ToArray();

            // Die fehlenden Spiele ermitteln
            Tuple<int, int>[] tupleMatches = new Tuple<int, int>[missingMatches.Count];
            for (int index = 0; index < missingMatches.Count; index++)
            {
                int home = standingWithoutSpecificTeam.IndexOf(standingWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamId == missingMatches[index].HomeTeamId));
                int away = standingWithoutSpecificTeam.IndexOf(standingWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamId == missingMatches[index].AwayTeamId));
                tupleMatches[index] = new Tuple<int, int>(home, away);
            }

            bool canWin = false;
            Parallel.For(0, numberOfIterations, (index, loopstate) =>
            {
                int position = PositionService.CalculatePointDifferencesByIndex((int[])pointDifferences.Clone(), (Tuple<int, int>[])tupleMatches.Clone(), index);

                if (position == 0)
                {
                    canWin = true;

                    // Hole die ternäre Repräsentation der Zahl
                    string ternary = index.ConvertToBase(3);

                    // Durchlaufe die Begegnungen, um die Ergebnisse zu setzen
                    for (int matchIndex = 0; matchIndex < remainingMatches.Count(); matchIndex++)
                    {
                        // Entweder Unentschieden setzen oder den Match Wert ermitteln, falls vorhanden
                        // Hier muss der Char vorher in einen String umgewandelt werden, da sonst die Konvertierung nach ASCI gemacht wird
                        byte matchResult = (matchIndex < ternary.Length) ? Convert.ToByte(ternary[matchIndex].ToString()) : (byte)0;

                        remainingMatchesOfRemainingTeam[matchIndex].MatchResult = (MatchResult)matchResult;
                    }

                    // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
                    List<LeagueStandingEntry> leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);

                    computationResult = leagueStanding;

                    loopstate.Stop();
                }
            });*/
            #endregion

            // Es wurde nun ein Team ermittelt, was nicht durch durchswitchen vom ersten Platz verdrängt werden kann, hier könnten nun die Schranke benutzt werden
            return new ChampionComputationalResult()
            {
                CanWinChampionship = null
            };
        }
        #endregion

        #region ComputeIfTeamIsSwitchable
        /// <summary>
        /// Berechnet, ob ein Team hinter das spezifizierte Team kommen kann.
        /// </summary>
        /// <param name="betterTeam">Das bessere Team.</param>
        /// <param name="currentStanding">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Matches.</param>
        /// <param name="specificTeam">Das spezifizierte Team.</param>
        /// <param name="alreadyCheckedMatches">Die schon gecheckten Spiele.</param>
        public static bool ComputeIfTeamIsSwitchable(LeagueStandingEntry betterTeam, IEnumerable<LeagueStandingEntry> leagueStandingEntries, IEnumerable<RemainingMatch> remainingMatches, LeagueStandingEntry specificTeam, List<RemainingMatch> alreadyCheckedMatches = null)
        {
            alreadyCheckedMatches = alreadyCheckedMatches ?? new List<RemainingMatch>();
            List<RemainingMatch> currentCheckedMatches = new List<RemainingMatch>();
            List<LeagueStandingEntry> currentStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);
            IEnumerable<RemainingMatch> remainingMatchesOfBetterTeam = remainingMatches
                .Where((match) =>
                    match.HomeTeamId == betterTeam.TeamId && (match.MatchResult == MatchResult.Tie || match.MatchResult == MatchResult.WinHome) ||
                    match.AwayTeamId == betterTeam.TeamId && (match.MatchResult == MatchResult.Tie || match.MatchResult == MatchResult.WinGuest));
            foreach (RemainingMatch match in remainingMatchesOfBetterTeam)
            {
                if (alreadyCheckedMatches.Contains(match)) continue;

                LeagueStandingEntry home = currentStanding
                    .SingleOrDefault((team) => team.TeamId == match.HomeTeamId && team.TeamId != betterTeam.TeamId);
                LeagueStandingEntry away = currentStanding
                    .SingleOrDefault((team) => team.TeamId == match.AwayTeamId && team.TeamId != betterTeam.TeamId);

                if (away != null)
                {
                    if (match.MatchResult == MatchResult.WinHome)
                    {
                        match.MatchResult = MatchResult.WinGuest;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (away.Points + 3 > specificTeam.Points)
                        {
                            bool didSwitch = ChampionService.ComputeIfTeamIsSwitchable(away, leagueStandingEntries, remainingMatches, specificTeam, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.MatchResult = MatchResult.Tie;
                                didSwitch = ChampionService.ComputeIfTeamIsSwitchable(away, leagueStandingEntries, remainingMatches, specificTeam, alreadyCheckedMatches);

                                if (!didSwitch)
                                {
                                    match.MatchResult = MatchResult.WinHome;
                                    alreadyCheckedMatches.Remove(match);
                                    currentCheckedMatches.Remove(match);
                                }
                            }
                        }
                    }
                    else if (match.MatchResult == MatchResult.Tie)
                    {
                        match.MatchResult = MatchResult.WinGuest;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (away.Points + 2 > specificTeam.Points)
                        {
                            bool didSwitch = ChampionService.ComputeIfTeamIsSwitchable(away, leagueStandingEntries, remainingMatches, specificTeam, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.MatchResult = MatchResult.Tie;
                                alreadyCheckedMatches.Remove(match);
                                currentCheckedMatches.Remove(match);
                            }
                        }
                    }
                }
                else if (home != null)
                {
                    if (match.MatchResult == MatchResult.WinGuest)
                    {
                        match.MatchResult = MatchResult.WinHome;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (home.Points + 3 > specificTeam.Points)
                        {
                            bool didSwitch = ChampionService.ComputeIfTeamIsSwitchable(home, leagueStandingEntries, remainingMatches, specificTeam, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.MatchResult = MatchResult.Tie;
                                didSwitch = ChampionService.ComputeIfTeamIsSwitchable(home, leagueStandingEntries, remainingMatches, specificTeam, alreadyCheckedMatches);

                                if (!didSwitch)
                                {
                                    match.MatchResult = MatchResult.WinGuest;
                                    alreadyCheckedMatches.Remove(match);
                                    currentCheckedMatches.Remove(match);
                                }
                            }
                        }
                    }
                    else if (match.MatchResult == MatchResult.Tie)
                    {
                        match.MatchResult = MatchResult.WinHome;
                        alreadyCheckedMatches.Add(match);
                        currentCheckedMatches.Add(match);

                        if (home.Points + 2 > specificTeam.Points)
                        {
                            bool didSwitch = ChampionService.ComputeIfTeamIsSwitchable(home, leagueStandingEntries, remainingMatches, specificTeam, alreadyCheckedMatches);
                            if (!didSwitch)
                            {
                                match.MatchResult = MatchResult.Tie;
                                alreadyCheckedMatches.Remove(match);
                                currentCheckedMatches.Remove(match);
                            }
                        }
                    }
                }

                currentStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);
                if (currentStanding.None((entry) => entry.Points > specificTeam.Points))
                {
                    return true; 
                }
            }

            // Spiele zurücksetzen, da dieser Weg nicht geht
            currentCheckedMatches.ForEach((match) =>
            {
                match.MatchResult = MatchResult.Tie;
                alreadyCheckedMatches.Remove(match);
            });
            currentStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);
            return false;
        }
        #endregion
    }
}
