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
            // Services erstellen
            LeagueService leagueService = new LeagueService(championshipViewModel);
            TeamService teamService = new TeamService(championshipViewModel);

            // Parameter merken und ermitteln
            this.ChampionshipViewModel = championshipViewModel;
            this.League = leagueService.GetLeagueByName(leagueName);
            this.LeagueId = this.League.id;
            this.Season = season;
            this.Teams = teamService.GetTeamsByLeagueAndSeason(this.League.id, season);
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
        public int CalculateBestPossibleFinalPositionForTeam(int stage, IEnumerable<LeagueStandingEntry> leagueStandingEntries, long teamApiId)
        {
            // Service erzeugen und Anzahl der Spiele ermitteln
            MatchService matchService = new MatchService(this.ChampionshipViewModel);
            long numberOfMatches = matchService.GetNumberOfMatches(this.LeagueId, this.Season);

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
            List<RemainingMatch> remainingMatches = matchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Liste kopieren, da sonst die Einträge verändert werden 
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                LeagueStandingEntry newEntry = new LeagueStandingEntry(entry.TeamId, entry.TeamApiId, entry.TeamShortName, entry.TeamLongName)
                {
                    Points = entry.Points
                };

                leagueStandings.Add(newEntry);
            }

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandings, remainingMatches, teamApiId, (int) numberOfMatches - stage);
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

            // Die Entries neu sortieren
            Parallel.For(0, (int) Math.Pow(3, remainingMatches.Count()), (index, loopState) =>
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
                    if (position < (int) bestPosition)
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
        public int CalculateWorstPossibleFinalPositionForTeam(int stage, IEnumerable<LeagueStandingEntry> leagueStandingEntries, long teamApiId)
        {
            MatchService matchService = new MatchService(this.ChampionshipViewModel);
            long numberOfMatches = matchService.GetNumberOfMatches(this.LeagueId, this.Season);

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
            List<RemainingMatch> remainingMatches = matchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Liste kopieren, da sonst die Einträge verändert werden 
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                LeagueStandingEntry newEntry = new LeagueStandingEntry(entry.TeamId, entry.TeamApiId, entry.TeamShortName, entry.TeamLongName)
                {
                    Points = entry.Points
                };

                leagueStandings.Add(newEntry);
            }

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateWorstPossibleFinalPositionForTeam(leagueStandings, remainingMatches, teamApiId, (int)numberOfMatches - stage);
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
                // Falls das Team nichtmehr erreich bar ist, oder das Team über dem Team steht, dann sind diese Teams irrelevant und diese dürfen alle Spiele verlieren
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

            // Die Entries neu sortieren
            Parallel.For(0, (int)Math.Pow(3, remainingMatches.Count()), (index, loopState) =>
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
        public bool CalculateIfTeamCanWinChampionship(int stage, IEnumerable<LeagueStandingEntry> leagueStandingEntries, long teamApiId)
        {
            // Service erzeugen und Anzahl der Spiele ermitteln
            MatchService matchService = new MatchService(this.ChampionshipViewModel);
            long numberOfMatches = matchService.GetNumberOfMatches(this.LeagueId, this.Season);

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
            List<RemainingMatch> remainingMatches = matchService.GetRemainingMatches(this.LeagueId, this.Season, stage).ToList();

            // Liste kopieren, da sonst die Einträge verändert werden 
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                LeagueStandingEntry newEntry = new LeagueStandingEntry(entry.TeamId, entry.TeamApiId, entry.TeamShortName, entry.TeamLongName)
                {
                    Points = entry.Points
                };

                leagueStandings.Add(newEntry);
            }

            // Berechnung mit den ermittelten Werten durchführen (Liste hier kopieren, dass diese nicht in der Ansicht geändert wird)
            return LeagueStandingService.CalculateIfTeamCanWinChampionship(leagueStandings, remainingMatches, teamApiId, (int)numberOfMatches - stage);
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

            // Die Entries neu sortieren
            Parallel.For(0, (int)Math.Pow(3, remainingMatches.Count()), (index, loopState) =>
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
            MatchService matchService = new MatchService(this.ChampionshipViewModel);
            LeagueService leagueService = new LeagueService(this.ChampionshipViewModel);

            // Die Liga ermitteln
            League currentLeague = leagueService.GetLeague(this.LeagueId);

            // Für jedes Team einen Eintrag anlegen
            foreach (Team team in this.Teams)
            {
                LeagueStandingEntry entry = new LeagueStandingEntry((int)team.id, team.team_api_id, team.team_short_name, team.team_long_name);
                leagueStandings.Add(entry);
            }

            // Die Spiele ermitteln
            IEnumerable<Match> matchesTilStage = matchService.GetMatchesUntilStage(this.LeagueId, this.Season, stage);

            // Die Spiele durchlaufen und werten
            foreach (Match match in matchesTilStage)
            {
                LeagueStandingEntry home = leagueStandings.Single((entry) => entry.TeamApiId == match.home_team_api_id);
                LeagueStandingEntry away = leagueStandings.Single((entry) => entry.TeamApiId == match.away_team_api_id);

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

            foreach(LeagueStandingEntry entry in leagueStandings)
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
                LeagueStandingEntry newEntry = new LeagueStandingEntry(entry.TeamId, entry.TeamApiId, entry.TeamShortName, entry.TeamLongName)
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
    }
}
