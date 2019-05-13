using System;
using System.Windows.Forms;

namespace ChampionshipProblem
{
    /// <summary>
    /// Klasse repräsentiert das Program.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Der Einstiegspunkt des Programms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Datengrundlage erstellen
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            // Form starten
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChampionshipProblemForm(championshipViewModel));
        }
    }
}
