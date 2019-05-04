using ChampionshipProblem.Classes;
using ChampionshipProblem.Extensions;
using ChampionshipProblem.Scheme;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChampionshipProblem.Services
{
    public class LeagueStandingService
    {
        public EuropeanSoccerEntities SoccerDb { get; set; }
        public long LeagueId { get; set; }
        public string Season { get; set; }
        public League League { get; set; }
        public IEnumerable<Team> Teams { get; set; }

        public LeagueStandingService(EuropeanSoccerEntities soccerDb, string leagueName, string season)
        {
            // Services erstellen
            LeagueService leagueService = new LeagueService(soccerDb);
            TeamService teamService = new TeamService(soccerDb);

            // Parameter merken
            this.SoccerDb = soccerDb;
            this.League = leagueService.GetLeagueByName(leagueName);
            this.LeagueId = this.League.id;
            this.Season = season;
            this.Teams = teamService.GetTeamsByLeagueAndSeason(this.League.id, season);
        }

        public int CalculateBestPossibleFinalPositionForTeam(int stage, IEnumerable<LeagueStandingEntry> leagueStandingEntries, long teamApiId)
        {
            MatchService matchService = new MatchService(this.SoccerDb);
            long numberOfMatches = matchService.GetNumberOfMatches(this.LeagueId);

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
            return LeagueStandingService.CalculateBestPossibleFinalPositionForTeam(leagueStandings, remainingMatches, teamApiId, ((int) numberOfMatches - stage));
        }

        public static int CalculateBestPossibleFinalPositionForTeam(IEnumerable<LeagueStandingEntry> leagueStandingEntries, List<RemainingMatch> remainingMatches, long teamApiId, int numberOfMissingStages)
        {
            // Als Erstes die Liste kopieren, dass die Ansicht nicht verändert wird
            var positionLock = new object();
            int bestPosition = int.MaxValue;
            LeagueStandingEntry leagueStandingEntry = leagueStandingEntries.Single((entry) => entry.TeamApiId == teamApiId);

            // Nun die Teams ermitteln, welche unerreichbar sind für das Team
            List<LeagueStandingEntry> unconsideredEntries = new List<LeagueStandingEntry>();
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                // Falls das Team nurnoch Punktgleich (oder weniger) oder Punktgleich oder mehr Punkte erreichen kann, dann das Team immer gewinnen lassen
                if ((entry.Points + (numberOfMissingStages * 3) <= leagueStandingEntry.Points) ||
                    (entry.Points > leagueStandingEntry.Points + (numberOfMissingStages * 3)))
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
                    leagueStandingEntry.Points += 3;
                    remainingMatches.Remove(remainingMatch);
                }
                else if (remainingMatch.HomeTeamApiId == teamApiId)
                {
                    remainingMatch.MatchResult = MatchResult.WinHome;
                    leagueStandingEntry.Points += 3;
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
            Parallel.For(0, (int) Math.Pow(3, remainingMatches.Count()), (index) =>
            {
                if (index % 10000 == 0) Debug.WriteLine(index);

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
                    }
                }
                
            });

            /*
            // Durchlaufe alle möglichen Spielkombinationen
            for (int possibilityIndex = 0; possibilityIndex < Math.Pow(3, remainingMatches.Count()); possibilityIndex++)
            {
                if (possibilityIndex % 1000 == 0) Debug.WriteLine(possibilityIndex);

                // Hole die ternäre Repräsentation der Zahl
                string ternary = possibilityIndex.ConvertToBase(3);

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
                if (position < bestPosition)
                {
                    bestPosition = position;
                }
            }*/

            return bestPosition;
        }

        public List<LeagueStandingEntry> CalculateStandingForLeague(int stage)
        {
            // Entitäten und Services erzeugen
            List<LeagueStandingEntry> leagueStandings = new List<LeagueStandingEntry>();
            MatchService matchService = new MatchService(SoccerDb);
            LeagueService leagueService = new LeagueService(SoccerDb);

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
            return leagueStandings;
        }

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

    }
}
