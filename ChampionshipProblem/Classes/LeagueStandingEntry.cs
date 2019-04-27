using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem.Classes
{
    public class LeagueStandingEntry
    {
        public LeagueStandingEntry(int teamId, long? teamApiId, string shortName, string longName)
        {
            this.TeamId = teamId;
            this.TeamApiId = teamApiId;
            this.TeamShortName = shortName;
            this.TeamLongName = longName;
            this.Points = 0;
            this.Goals = 0;
            this.GoalsConceded = 0;
        }

        public int TeamId { get; set; }

        public long? TeamApiId { get; set; }

        public string TeamShortName { get; set; }

        public string TeamLongName { get; set; }

        public int Games { get; set; }

        public int Wins { get; set; }

        public int Ties { get; set; }

        public int Losses { get; set; }

        public int Points { get; set; }

        public int Goals { get; set; }

        public int GoalsConceded { get; set; }

        public int GoalDifference { get; set; }
    }
}
