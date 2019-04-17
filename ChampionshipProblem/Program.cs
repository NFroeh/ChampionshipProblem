using ChampionshipProblem.Scheme;
using System;
using System.Diagnostics;
using System.Linq;
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
                Debug.WriteLine(soccerDb.Leagues.Count());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
