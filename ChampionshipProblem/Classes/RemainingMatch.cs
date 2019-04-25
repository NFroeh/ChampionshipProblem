using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChampionshipProblem.Classes
{
    public class RemainingMatch
    {
        public RemainingMatch()
        {
            MatchResult = MatchResult.Tie;
        }

        public long Id { get; set; }
        public long CountryId { get; set; }
        public long LeagueId { get; set; }
        public string Season { get; set; }
        public long Stage { get; set; }
        public string Date { get; set; }
        public long MatchApiId { get; set; }
        public long HomeTeamApiId { get; set; }
        public long AwayTeamApiId { get; set; }
        public long HomeTeamGoal { get; set; }
        public long AwayTeamGoal { get; set; }
        public MatchResult MatchResult { get; set; }
    }
}
