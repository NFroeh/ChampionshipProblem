using ChampionshipProblem.Classes;
using ChampionshipProblem.Extensions;
using ChampionshipProblem.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem.Services
{
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
        /// Konstruktor zum Erstellen des Services für die schlechtmöglichste Position.
        /// </summary>
        /// <param name="championshipViewModel">Die Datengrundlage</param>
        /// <param name="league">Die Liga.</param>
        /// <param name="leagueId">Die Liganummer.</param>
        /// <param name="season">Die Saison.</param>
        /// <param name="leagueStandingService">Der überliegende Service.</param>
        public WorstPossiblePositionService(ChampionshipViewModel championshipViewModel, League league, long leagueId, string season, LeagueStandingService leagueStandingService)
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
        /// <param name="teamApiId">Die Id des Teams.</param>
        /// <returns>Die schlechtmöglichste Position.</returns>
        public int CalculateWorstPossibleFinalPositionForTeam(int stage, long teamApiId)
        {
            long numberOfMatches = this.ChampionshipViewModel.MatchService.GetNumberOfMatches(this.LeagueId, this.Season);

            // Den aktuellen Stand berechnen
            List<LeagueStandingEntry> leagueStandingEntries = this.LeagueStandingService.CalculateStanding(stage);

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
    }
}
