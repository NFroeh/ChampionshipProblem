using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;

namespace ChampionshipProblem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (EuropeanSoccerEntities soccerDb = new EuropeanSoccerEntities())
            {
                LeagueService leagueService = new LeagueService(soccerDb);
                MatchService matchService = new MatchService(soccerDb);
                string leagueName ="Germany 1. Bundesliga";
                string season = "2010/2011";
                LeagueStandingService leagueStandingService = new LeagueStandingService(soccerDb, leagueName, season);

                List<LeagueStandingEntry> standings = leagueStandingService.CalculateStandingForLeague(34);

                // Eine neue Berechnung anstellen
                int stage = 33;
                standings = leagueStandingService.CalculateStandingForLeague(stage);

                // Tabelle ausgeben
                LeagueStandingService.PrintLeagueStanding(standings);

                List<RemainingMatch> remainingMatches = matchService.GetRemainingMatches(leagueName, season, stage);
                int bestPosition = leagueStandingService.CalculateBestPossibleFinalPositionForTeam(stage, standings, standings.ElementAt(6).TeamApiId.Value);
                Debug.Print("Beste Position: " + bestPosition);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
