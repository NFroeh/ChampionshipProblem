using ChampionshipProblem.Classes;
using System.Collections.Generic;

namespace ChampionshipProblem.Test
{
    /// <summary>
    /// Klasse beinhaltet Hilfsmethoden für die Tests.
    /// </summary>
    public class TestUtils
    {
        #region GenerateSeason1991Standing
        /// <summary>
        /// Methode zum Generieren der Tabelle der Saison von 1991.
        /// </summary>
        /// <returns>Die Tabelle der Saison 1991.</returns>
        public static List<LeagueStandingEntry> GenerateSeason1991Standing()
        {
            LeagueStandingEntry sge = new LeagueStandingEntry(1, "SGE", "Frankfurt")
            {
                Points = 41
            };
            LeagueStandingEntry vfb = new LeagueStandingEntry(2, "VFB", "Stuttgart")
            {
                Points = 40
            };
            LeagueStandingEntry bvb = new LeagueStandingEntry(3, "BVB", "Dortmund")
            {
                Points = 40
            };
            LeagueStandingEntry b04 = new LeagueStandingEntry(4, "B04", "Leverkusen")
            {
                Points = 40
            };
            LeagueStandingEntry fcn = new LeagueStandingEntry(5, "FCN", "Nürnberg")
            {
                Points = 36
            };
            LeagueStandingEntry fck = new LeagueStandingEntry(6, "FCK", "Kaiserslautern")
            {
                Points = 34
            };

            return new List<LeagueStandingEntry>()
            {
                sge,
                vfb,
                bvb,
                b04,
                fcn,
                fck
            };
        }
        #endregion

        #region GenerateSeason1991RemaingMatches
        /// <summary>
        /// Methode zum Generieren der fehlenden Spiele der Saison 1991.
        /// </summary>
        /// <returns>Die fehlenden Spiele.</returns>
        public static List<RemainingMatch> GenerateSeason1991RemaingMatches()
        {
            LeagueStandingEntry sge = new LeagueStandingEntry(1, "SGE", "Frankfurt")
            {
                Points = 41
            };
            LeagueStandingEntry vfb = new LeagueStandingEntry(2, "VFB", "Stuttgart")
            {
                Points = 40
            };
            LeagueStandingEntry bvb = new LeagueStandingEntry(3, "BVB", "Dortmund")
            {
                Points = 40
            };
            LeagueStandingEntry b04 = new LeagueStandingEntry(4, "B04", "Leverkusen")
            {
                Points = 40
            };
            LeagueStandingEntry fcn = new LeagueStandingEntry(5, "FCN", "Nürnberg")
            {
                Points = 36
            };
            LeagueStandingEntry fck = new LeagueStandingEntry(6, "FCK", "Kaiserslautern")
            {
                Points = 34
            };

            // Fehlende Matches in Liste erzeugen
            RemainingMatch sgeb04 = new RemainingMatch()
            {
                HomeTeamApiId = sge.TeamApiId.Value,
                AwayTeamApiId = b04.TeamApiId.Value,
            };
            RemainingMatch vfbbvb = new RemainingMatch()
            {
                HomeTeamApiId = vfb.TeamApiId.Value,
                AwayTeamApiId = bvb.TeamApiId.Value,
            };
            RemainingMatch fcnfck = new RemainingMatch()
            {
                HomeTeamApiId = fcn.TeamApiId.Value,
                AwayTeamApiId = fck.TeamApiId.Value,
            };
            RemainingMatch b04fcn = new RemainingMatch()
            {
                HomeTeamApiId = b04.TeamApiId.Value,
                AwayTeamApiId = fcn.TeamApiId.Value,
            };
            RemainingMatch bvbsge = new RemainingMatch()
            {
                HomeTeamApiId = bvb.TeamApiId.Value,
                AwayTeamApiId = sge.TeamApiId.Value,
            };
            RemainingMatch fckvfb = new RemainingMatch()
            {
                HomeTeamApiId = fck.TeamApiId.Value,
                AwayTeamApiId = vfb.TeamApiId.Value,
            };
            RemainingMatch fcnbvb = new RemainingMatch()
            {
                HomeTeamApiId = fcn.TeamApiId.Value,
                AwayTeamApiId = bvb.TeamApiId.Value,
            };
            RemainingMatch sgefck = new RemainingMatch()
            {
                HomeTeamApiId = sge.TeamApiId.Value,
                AwayTeamApiId = fck.TeamApiId.Value,
            };
            RemainingMatch vfbb04 = new RemainingMatch()
            {
                HomeTeamApiId = vfb.TeamApiId.Value,
                AwayTeamApiId = b04.TeamApiId.Value,
            };

            return new List<RemainingMatch>()
            {
                sgeb04,
                vfbbvb,
                fcnfck,
                b04fcn,
                bvbsge,
                fckvfb,
                fcnbvb,
                sgefck,
                vfbb04
            };
        }
        #endregion
    }
}
