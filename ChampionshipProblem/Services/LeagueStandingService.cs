using ChampionshipProblem.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem.Services
{
    public class LeagueStandingService
    {
        public static void PrintLeagueStanding(IEnumerable<LeagueStandingEntry> leagueStandingEntries)
        {
            foreach (LeagueStandingEntry entry in leagueStandingEntries)
            {
                Debug.WriteLine(string.Format("{0, -25}", entry.TeamLongName) + " - "  + 
                    string.Format("{0, -2}", entry.Goals) + ":" + string.Format("{0, -2}", entry.GoalsConceded) + " (" + string.Format("{0, -3}", entry.Goals - entry.GoalsConceded) + ")" 
                    + " - " + string.Format("{0, -3}", entry.Points));
            }
        }
    }
}
