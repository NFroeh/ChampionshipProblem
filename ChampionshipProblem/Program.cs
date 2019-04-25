using ChampionshipProblem.Classes;
using ChampionshipProblem.Scheme;
using ChampionshipProblem.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

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

                League bundesliga = leagueService.GetLeagueByName("Germany 1. Bundesliga");
                string season = "2010/2011";
                List<LeagueStandingEntry> standings = leagueService.CalculateStandingForLeague(bundesliga.id, season, 34);

                // Tabelle ausgeben
                LeagueStandingService.PrintLeagueStanding(standings);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
