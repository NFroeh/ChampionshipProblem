using ChampionshipProblem.Classes;
using ChampionshipProblem.Extensions;
using ChampionshipProblem.Scheme;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChampionshipProblem.Services
{
    /// <summary>
    /// Klasse repräsentiert Methoden zum Verwalten von <see cref="LeagueStandingEntry"/>.
    /// </summary>
    public class LeagueStandingService
    {
        #region fields
        /// <summary>
        /// Die Daten.
        /// </summary>
        public ChampionshipViewModel ChampionshipViewModel { get; set; }

        /// <summary>
        /// Die Liganummer.
        /// </summary>
        public long LeagueId { get; set; }

        /// <summary>
        /// Die Saison der Liga.
        /// </summary>
        public string Season { get; set; }

        /// <summary>
        /// Die Liga als Entität.
        /// </summary>
        public League League { get; set; }

        /// <summary>
        /// Die Mannschaften
        /// </summary>
        public IEnumerable<Team> Teams { get; set; }
        #endregion

        #region LeagueStandingService
        /// <summary>
        /// Konstruktor zum Erstellen der Klasse.
        /// </summary>
        /// <param name="soccerDb">Die Datenbankverbindung.</param>
        /// <param name="leagueName">Der Name der Liga.</param>
        /// <param name="season">Die Saison.</param>
        public LeagueStandingService(ChampionshipViewModel championshipViewModel, string leagueName, string season)
        {
            // Parameter merken und ermitteln
            this.ChampionshipViewModel = championshipViewModel;
            this.League = this.ChampionshipViewModel.LeagueService.GetLeagueByName(leagueName);
            this.LeagueId = this.League.id;
            this.Season = season;
            this.Teams = this.ChampionshipViewModel.TeamService.GetTeamsByLeagueAndSeason(this.League.id, season);
        }
        #endregion

        #region CalculateBestPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der besten möglichen Position für ein Team zu einem bestimmten Spieltag in der LIga.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <returns>Die bestmögliche Position.</returns>
        public int CalculateBestPossibleFinalPositionForTeam(int stage, long teamApiId)
        {
            // Service erzeugen und Anzahl der Spiele ermitteln
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);

            // Den aktuellen Stand der Tabelle berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.CalculateStanding(stage);

            // Wenn erst die Hälfte der Spiele gespielt ist, kann noch jeder Platz erreicht werden
            if (stage <= numberOfMatches / 2)
            {
                return 1;
            }

            // Wenn es der letzte Spieltag ist, steht die Position fest
            if (stage == numberOfMatches)
            {
                return leagueStandingEntries.ToList().IndexOf(leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId)) + 1;
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, teamApiId, (int) numberOfMatches - stage);
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
        /// <returns>Die bestmögliche Position</returns>
        public static int CalculateBestPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            var positionLock = new object();
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
            int bestPosition = leagueStandingEntries.ToList().IndexOf(specificEntry) + 1;

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
                else if(homeEntry != null)
                {
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    homeEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if(guestEntry != null)
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

                        if (bestPosition == 1)
                        {
                            loopState.Stop();
                        }
                    }
                }
            });

            return bestPosition;
        }
        #endregion

        #region CalculateWorstPossibleFinalPositionForTeam
        /// <summary>
        /// Methode zum Ermitteln der schlechtmöglichsten Position für ein Team zu einem bestimmten Spieltag in der Liga.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <returns>Die schlechtmöglichste Position.</returns>
        public int CalculateWorstPossibleFinalPositionForTeam(int stage, long teamApiId)
        {
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);

            // Den aktuellen Stand berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.CalculateStanding(stage);

            // Wenn erst die Hälfte der Spiele gespielt ist, kann noch jeder Platz erreicht werden
            if (stage <= numberOfMatches / 2)
            {
                return leagueStandingEntries.Count();
            }

            // Wenn es der letzte Spieltag ist, steht die Position fest
            if (stage == numberOfMatches)
            {
                return leagueStandingEntries.ToList().IndexOf(leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId)) + 1;
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandingEntries, remainingMatches, teamApiId, (int)numberOfMatches - stage);
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
        /// <returns>Die schlechtmöglichste Position</returns>
        public static int CalculateWorstPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            var positionLock = new object();
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
            int worstPosition = leagueStandingEntries.ToList().IndexOf(specificEntry) + 1;
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
                LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId);
                LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId);

                // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Lose" setzen
                if (remainingMatch.AwayTeamApiId == teamApiId)
                {
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    leagueStandingEntries.Single((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId).Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (remainingMatch.HomeTeamApiId == teamApiId)
                {
                    remainingMatch.MatchResult = MatchResult.WinGuest;
                    leagueStandingEntries.Single((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId).Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (homeEntry != null)
                {
                    remainingMatch.MatchResult = MatchResult.WinGuest;
                    leagueStandingEntries.Single((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId).Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (guestEntry != null)
                {
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    leagueStandingEntries.Single((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId).Points += 3;
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

                    // Ergebnis setzen
                    remainingMatches[matchIndex].MatchResult = (MatchResult)matchResult;
                }

                // Berechne die Tabelle für die RemainingMatches und dem aktuellen Tabellenstand
                List<LeagueStandingEntry> leagueStanding = LeagueStandingService.CalculateLeagueStandingForRemainingMatches(leagueStandingEntries, remainingMatches);

                // Überprüfen, ob es eine neue beste Position gibt
                LeagueStandingEntry teamEntry = leagueStanding.Single((entry) => entry.TeamApiId == teamApiId);
                int position = leagueStanding.IndexOf(teamEntry) + 1;

                // Noch die Positionen der Teams welche gleich viele Punkte haben, aber über diesem Team stehen abziehen
                int numberOfTeamsWithSamePointsAndBiggerName = leagueStanding.Where((entry) => entry.Points == teamEntry.Points && entry.TeamShortName.CompareTo(teamEntry.TeamShortName) == 1).Count();
                position += numberOfTeamsWithSamePointsAndBiggerName;
                lock (positionLock)
                {
                    if (position > (int)worstPosition)
                    {
                        worstPosition = position;

                        if (worstPosition == numberOfTeams)
                        {
                            loopState.Stop();
                        }
                    }
                }
            });
            
            return worstPosition;
        }
        #endregion

        #region CalculateIfTeamCanWinChampionship
        /// <summary>
        /// Methode zum Ermitteln, ob eine bestimmte Mannschaft noch Meister werden kann.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public bool CalculateIfTeamCanWinChampionship(int stage, long teamApiId)
        {
            // Anzahl der Spiele ermitteln
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);

            // Den aktuellen Stand der Tabelle berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.CalculateStanding(stage);

            // Wenn erst die Hälfte der Spiele gespielt ist, kann noch jeder Platz erreicht werden
            if (stage <= numberOfMatches / 2)
            {
                return true;
            }

            // Wenn es der letzte Spieltag ist, steht die Position fest
            if (stage == numberOfMatches)
            {
                return leagueStandingEntries.First().TeamApiId == teamApiId;
            }

            // Die fehlenden Spiele ermitteln
            List<RemainingMatch> remainingMatches = this.ChampionshipViewModel.MatchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandingEntries, remainingMatches, teamApiId, (int)numberOfMatches - stage);
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
        /// <returns>Ob die Mannschaft noch Meister werden kann.</returns>
        public static bool CalculateIfTeamCanWinChampionship(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            LeagueStandingEntry specificEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);
            LeagueStandingEntry first = leagueStandingEntries.First();
            bool canWin = false;

            // Zuerst überprüfen, ob der aktuell erste überhaupt mit Punkten noch eingeholt werden kann
            if (specificEntry.Points + numberOfMissingStages * 3 < first.Points)
            {
                return false;
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
                    loopState.Stop();
                }
            });

            return canWin;
        }
        #endregion

        #region CalculateStanding
        /// <summary>
        /// Methode zum Ermitteln der Tabelle für eine Liga anhand des Spieltags.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die Liste der Tabelle.</returns>
        public List<LeagueStandingEntry> CalculateStanding(int stage)
        {
            // Entitäten und Services erzeugen
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();

            // Die Liga ermitteln
            League currentLeague = this.ChampionshipViewModel.LeagueService.GetLeague(this.LeagueId);

            // Für jedes Team einen Eintrag anlegen
            foreach (Team team in this.Teams)
            {
                LeagueStandingEntry entry = new LeagueStandingEntry(team.team_api_id, team.team_short_name, team.team_long_name);
                leagueStandings.Add(entry);
            }

            // Die Spiele ermitteln
            IEnumerable<Match> matchesTilStage = this.ChampionshipViewModel.MatchService.GetMatchesUntilStage(this.LeagueId, this.Season, stage);

            // Die Spiele durchlaufen und werten
            foreach (Match match in matchesTilStage)
            {
                LeagueStandingEntry home = leagueStandings.Single((entry) => entry.TeamApiId == match.home_team_api_id);
                LeagueStandingEntry away = leagueStandings.Single((entry) => entry.TeamApiId == match.away_team_api_id);

                if (match.home_team_goal > match.away_team_goal)
                {
                    home.Points += 3;
                }
                else if (match.home_team_goal < match.away_team_goal)
                {
                    away.Points += 3;
                }
                else
                {
                    home.Points += 1;
                    away.Points += 1;
                }

                home.Goals += (int)match.home_team_goal.Value;
                home.GoalsConceded += (int)match.away_team_goal.Value;
                away.Goals += (int)match.away_team_goal.Value;
                away.GoalsConceded += (int)match.home_team_goal.Value;
            }

            leagueStandings = leagueStandings
                .OrderByDescending((entry) => entry.Points)
                .ThenByDescending((entry) => entry.Goals - entry.GoalsConceded)
                .ThenByDescending((entry) => entry.Goals)
                .ToList();

            return leagueStandings;
        }
        #endregion

        #region CalculateCompleteStanding
        /// <summary>
        /// Methode zum Ermitteln der kompletten Tabelle für eine Liga anhand des Spieltags.
        /// </summary>
        /// <param name="stage">Der Spieltag.</param>
        /// <returns>Die Liste der Tabelle.</returns>
        public List<CompleteLeagueStandingEntry> CalculateCompleteStanding(int stage)
        {
            // Entitäten und Services erzeugen
            List<CompleteLeagueStandingEntry> leagueStandings = new List<CompleteLeagueStandingEntry>();

            // Die Liga ermitteln
            League currentLeague = this.ChampionshipViewModel.LeagueService.GetLeague(this.LeagueId);

            // Für jedes Team einen Eintrag anlegen
            foreach (Team team in this.Teams)
            {
                CompleteLeagueStandingEntry entry = new CompleteLeagueStandingEntry((int)team.id, team.team_api_id, team.team_short_name, team.team_long_name);
                leagueStandings.Add(entry);
            }

            // Die Spiele ermitteln
            IEnumerable<Match> matchesTilStage = this.ChampionshipViewModel.MatchService.GetMatchesUntilStage(this.LeagueId, this.Season, stage);

            // Die Spiele durchlaufen und werten
            foreach (Match match in matchesTilStage)
            {
                CompleteLeagueStandingEntry home = leagueStandings.Single((entry) => entry.TeamApiId == match.home_team_api_id);
                CompleteLeagueStandingEntry away = leagueStandings.Single((entry) => entry.TeamApiId == match.away_team_api_id);

                if (match.home_team_goal > match.away_team_goal)
                {
                    home.Points += 3;
                    home.Wins++;
                    away.Losses++;
                }
                else if (match.home_team_goal < match.away_team_goal)
                {
                    home.Losses++;
                    away.Points += 3;
                    away.Wins++;
                }
                else
                {
                    home.Ties++;
                    home.Points += 1;
                    away.Ties++;
                    away.Points += 1;
                }

                home.Games++;
                home.Goals += (int)match.home_team_goal.Value;
                home.GoalsConceded += (int)match.away_team_goal.Value;
                away.Games++;
                away.Goals += (int)match.away_team_goal.Value;
                away.GoalsConceded += (int)match.home_team_goal.Value;
            }

            foreach (CompleteLeagueStandingEntry entry in leagueStandings)
            {
                entry.GoalDifference = entry.Goals - entry.GoalsConceded;
            }

            leagueStandings = leagueStandings
                .OrderByDescending((entry) => entry.Points)
                .ThenByDescending((entry) => entry.Goals - entry.GoalsConceded)
                .ThenByDescending((entry) => entry.Goals)
                .ToList();

            // Position für die Anzeige setzen
            for (int entryIndex = 0; entryIndex < leagueStandings.Count(); entryIndex++)
            {
                leagueStandings.ElementAt(entryIndex).Position = entryIndex + 1;
            }

            return leagueStandings;
        }
        #endregion

        #region PrintLeagueStanding
        /// <summary>
        /// Methode zum Ausgeben der Tabelle auf der Konsole.
        /// </summary>
        /// <param name="leagueStandingEntries">Die Tabelle.</param>
        public static void PrintLeagueStanding(IEnumerable<LeagueStandingEntry> leagueStandingEntries)
        {
            int i = 1;
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                Debug.WriteLine(string.Format("{0, -3}", i + ".") + string.Format("{0, -25}", entry.TeamLongName) + " - " +
                    string.Format("{0, -2}", entry.Goals) + ":" + string.Format("{0, -2}", entry.GoalsConceded) + " (" + string.Format("{0, -3}", entry.Goals - entry.GoalsConceded) + ")"
                    + " - " + string.Format("{0, -3}", entry.Points));
                i++;
            }
        }
        #endregion

        #region CalculateLeagueStandingForRemainingMatches
        /// <summary>
        /// Methode zum Ermitteln der Tabelle für eine bestimmte Tabelle und den fehlenden Spielen und deren Ergebnissen.
        /// </summary>
        /// <param name="leagueStandingEntries">Die aktuelle Tabelle.</param>
        /// <param name="remainingMatches">Die fehlenden Spiele.</param>
        /// <returns>Die Tabelle als Liste.</returns>
        private static List<LeagueStandingEntry> CalculateLeagueStandingForRemainingMatches(IEnumerable<LeagueStandingEntry> leagueStandingEntries, IEnumerable<RemainingMatch> remainingMatches)
        {
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();

            // Liste befüllen
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                LeagueStandingEntry newEntry = new LeagueStandingEntry(entry.TeamApiId, entry.TeamShortName, entry.TeamLongName)
                {
                    Points = entry.Points
                };

                leagueStandings.Add(newEntry);
            }

            foreach(RemainingMatch remainingMatch in remainingMatches)
            {
                switch (remainingMatch.MatchResult)
                {
                    case MatchResult.Tie:
                        leagueStandings.Single((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId).Points += 1;
                        leagueStandings.Single((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId).Points += 1;
                        break;
                    case MatchResult.WinHome:
                        leagueStandings.Single((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId).Points += 3;
                        break;
                    case MatchResult.WinGuest:
                        leagueStandings.Single((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId).Points += 3;
                        break;
                }
            }

            leagueStandings = leagueStandings
                .OrderByDescending((entry) => entry.Points)
                .ThenBy((entry) => entry.TeamShortName)
                .ToList();

            return leagueStandings;
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
            List<LeagueStandingEntry> leagueStandingEntries = this.CalculateStanding(stage);

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

        #region CalculateNumberOfRemainingMatchesForWorstPossiblePosition
        /// <summary>
        /// Methode zum Ausrechnen der Anzahl der Spiele, die für die Berechnung noch benötigt werden.
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="teamApiId"></param>
        public int CalculateNumberOfRemainingMatchesForWorstPossiblePosition(int stage, long teamApiId)
        {
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);
            long numberOfMissingStages = numberOfMatches - stage;

            // Den aktuellen Stand berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.CalculateStanding(stage);

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
                LeagueStandingEntry homeEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.HomeTeamApiId);
                LeagueStandingEntry guestEntry = unconsideredEntries.Find((entry) => entry.TeamApiId == remainingMatch.AwayTeamApiId);

                // Zuerst alle Spiele, welche dem betrachteten Team sind auf "Lose" setzen
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
            List<LeagueStandingEntry> leagueStandingEntries = this.CalculateStanding(stage);

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
    }
}
