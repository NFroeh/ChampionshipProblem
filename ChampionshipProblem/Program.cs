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
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ChampionshipProblemForm(soccerDb));
            }
        }
    }
}
