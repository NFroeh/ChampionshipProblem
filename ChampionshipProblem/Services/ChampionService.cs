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
        /// Konstruktor zum Erstellen des Services für die Meisterfrage.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage</param>
        /// <param name="league">Die Liga.</param>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="leagueStandingService">Der überliegende Service.</param>
        public ChampionService(ChampionshipViewModel championshipViewModel, League league, long leagueId, string season, LeagueStandingService leagueStandingService)
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
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public ChampionComputationalResult CalculateIfTeamCanWinChampionship(int stage, long teamApiId, bool computeStanding)
        {
            // Anzahl der Spiele ermitteln
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);

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
                return new ChampionComputationalResult() {
                    CanWinChampionship = leagueStandingEntries.First().TeamApiId == teamApiId,
                    ComputationalStanding = leagueStandingEntries
                };
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return ChampionService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, teamApiId, (int)numberOfMatches - stage, computeStanding);
        }
        #endregion

        #region CalculateIfTeamCanWinChampionship
        /// <summary>
        /// Methode zum Ermitteln, ob ein bestimmtes Team noch meister werden kann.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public static ChampionComputationalResult CalculateIfTeamCanWinChampionship(List<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages, bool computeStanding)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
            LeagueStandingEntry first = leagueStandingEntries.First();
            List<LeagueStandingEntry> computationResult = new List<LeagueStandingEntry>();
            bool canWin = false;

            // Zuerst überprüfen, ob der aktuell erste überhaupt mit Punkten noch eingeholt werden kann
            if (specificEntry.Points + numberOfMissingStages * 3 < first.Points)
            {
                return new ChampionComputationalResult()
                {
                    CanWinChampionship = false,
                    ComputationalStanding = computationResult
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
                        if (remainingMatch.AwayTeamApiId == equalPointEntry.TeamApiId)
                        {
                            remainingMatch.MatchResult = MatchResult.WinHome;
                            leagueStandingEntries.SingleOrDefault((leagueStandingEntry) => remainingMatch.HomeTeamApiId == leagueStandingEntry.TeamApiId).Points += 3;
                            remainingMatches.Remove(remainingMatch);

                        }
                        else if (remainingMatch.HomeTeamApiId == equalPointEntry.TeamApiId)
                        {
                            remainingMatch.MatchResult = MatchResult.WinGuest;
                            leagueStandingEntries.SingleOrDefault((leagueStandingEntry) => remainingMatch.AwayTeamApiId == leagueStandingEntry.TeamApiId).Points += 3;
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
                return new ChampionComputationalResult()
                {
                    CanWinChampionship = false,
                    ComputationalStanding = computationResult
                };
            }

            // Falls die Iterationen kleiner als 1 sind, dann wird nur eine Berechnung durchgeführt, da es sonst zu viele wären
            long numberOfIterations = (long)Math.Pow(3, remainingMatches.Count);
            if (numberOfIterations < 1)
            {
                numberOfIterations = 1;
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
                int home = standingWithoutSpecificTeam.IndexOf(standingWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamApiId == remainingMatches[index].HomeTeamApiId));
                int away = standingWithoutSpecificTeam.IndexOf(standingWithoutSpecificTeam.SingleOrDefault((entry) => entry.TeamApiId == remainingMatches[index].AwayTeamApiId));
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
                            byte matchResult = (matchIndex < ternary.Length) ? Convert.ToByte(ternary[matchIndex].ToString()) : (byte)0;

                            remainingMatches[matchIndex].MatchResult = (MatchResult)matchResult;
                        }

                        // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
                        List<LeagueStandingEntry> leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);

                        computationResult = leagueStanding;
                    }

                    loopState.Stop();
                }
            });

            return new ChampionComputationalResult()
            {
                CanWinChampionship = canWin,
                ComputationalStanding = computationResult
            };
        }
        #endregion

        #region CalculateNumberOfRemainingMatchesForChampion
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="teamApiId"></param>
        public int CalculateNumberOfRemainingMatchesForChampion(int stage, long teamApiId)
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
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
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

            return remainingMatches.Count;
        }
        #endregion

        #region CalculateIfTeamCanWinChampionship (Not Running)
        /*
        /// <summary>
        /// Methode zum Ermitteln, ob ein bestimmtes Team noch meister werden kann.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <param name="numberOfMissingStages">Die Anzahl der fehlenden Spiele.</param>
        /// <param name="computeStanding">Ob die Tabelle ausgerechnet werden soll.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public static ChampionComputationalResult CalculateIfTeamCanWinChampionship(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages, bool computeStanding)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
            LeagueStandingEntry first = leagueStandingEntries.First();
            bool canWin = false;
            List<LeagueStandingEntry> computationResult = new List<LeagueStandingEntry>();

            // Zuerst überprüfen, ob der aktuell erste überhaupt mit Punkten noch eingeholt werden kann
            if (specificEntry.Points + numberOfMissingStages * 3 < first.Points)
            {
                return new ChampionComputationalResult()
                {
                    CanWinChampionship = false,
                    ComputationalStanding = computationResult
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

            // Da nun die eigenen Spiele auf Sieg gesetzt werden konnten und alle unerheblichen Spiele gewonnen werden, muss, falls Teams Punktegleich sind, diese noch alle verlieren
            foreach(LeagueStandingEntry equalPointEntry in leagueStandingEntries.Where((leagueStandingEntry) => leagueStandingEntry.Points == specificEntry.Points))
            {
                foreach (RemainingMatch remainingMatch in remainingMatches.ToList())
                {
                    if (remainingMatch.AwayTeamApiId == equalPointEntry.TeamApiId)
                    {
                        remainingMatch.MatchResult = MatchResult.WinHome;
                        leagueStandingEntries.SingleOrDefault((leagueStandingEntry) => remainingMatch.HomeTeamApiId == leagueStandingEntry.TeamApiId).Points += 3;
                        remainingMatches.Remove(remainingMatch);

                    }
                    else if (remainingMatch.HomeTeamApiId == equalPointEntry.TeamApiId)
                    {
                        remainingMatch.MatchResult = MatchResult.WinGuest;
                        leagueStandingEntries.SingleOrDefault((leagueStandingEntry) => remainingMatch.AwayTeamApiId == leagueStandingEntry.TeamApiId).Points += 3;
                        remainingMatches.Remove(remainingMatch);
                    }
                }
            }

            // Falls jetzt jemand vor dem Team ist, dann kann dieses nichtmehr Meister werden
            if (leagueStandingEntries.Where((leagueStandingEntry) => leagueStandingEntry.Points > specificEntry.Points).Count() > 0)
            {
                return new ChampionComputationalResult()
                {
                    CanWinChampionship = false,
                    ComputationalStanding = computationResult
                };
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
                }

                // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
                List<LeagueStandingEntry> leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);

                // Überprüfen, ob es eine neue beste Position gibt
                LeagueStandingEntry teamEntry = leagueStanding.Single((entry) => entry.TeamApiId == teamApiId);
                int position = leagueStanding.IndexOf(teamEntry);

                // Noch die Positionen der Teams welche gleich viele Punkte haben, aber über diesem Team stehen abziehen
                int numberOfTeamsWithSamePointsAndShorterName = leagueStanding.Where((entry) => entry.Points == teamEntry.Points && entry.TeamShortName.CompareTo(teamEntry.TeamShortName) == -1).Count();
                position -= numberOfTeamsWithSamePointsAndShorterName;

                if (position == 0)
                {
                    canWin = true;
                    
                    if (computeStanding)
                    {
                        computationResult = leagueStanding;
                    }

                    loopState.Stop();
                }
            });

            return new ChampionComputationalResult(){
                CanWinChampionship = canWin,
                ComputationalStanding = computationResult
            };
        }*/
        #endregion
    }
}
