namespace ChampionshipProblem.Test
{
    using ChampionshipProblem.Classes;
    using System.Collections.Generic;

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
            LeagueStandingEntry sge = new LeagueStandingEntry(1, "Frankfurt")
            {
                Points = 41
            };
            LeagueStandingEntry vfb = new LeagueStandingEntry(2, "Stuttgart")
            {
                Points = 40
            };
            LeagueStandingEntry bvb = new LeagueStandingEntry(3, "Dortmund")
            {
                Points = 40
            };
            LeagueStandingEntry b04 = new LeagueStandingEntry(4, "Leverkusen")
            {
                Points = 40
            };
            LeagueStandingEntry fcn = new LeagueStandingEntry(5, "Nürnberg")
            {
                Points = 36
            };
            LeagueStandingEntry fck = new LeagueStandingEntry(6, "Kaiserslautern")
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
            LeagueStandingEntry sge = new LeagueStandingEntry(1, "Frankfurt")
            {
                Points = 41
            };
            LeagueStandingEntry vfb = new LeagueStandingEntry(2, "Stuttgart")
            {
                Points = 40
            };
            LeagueStandingEntry bvb = new LeagueStandingEntry(3, "Dortmund")
            {
                Points = 40
            };
            LeagueStandingEntry b04 = new LeagueStandingEntry(4, "Leverkusen")
            {
                Points = 40
            };
            LeagueStandingEntry fcn = new LeagueStandingEntry(5, "Nürnberg")
            {
                Points = 36
            };
            LeagueStandingEntry fck = new LeagueStandingEntry(6, "Kaiserslautern")
            {
                Points = 34
            };

            // Fehlende Matches in Liste erzeugen
            RemainingMatch sgeb04 = new RemainingMatch()
            {
                HomeTeamId = sge.TeamId,
                AwayTeamId = b04.TeamId,
            };
            RemainingMatch vfbbvb = new RemainingMatch()
            {
                HomeTeamId = vfb.TeamId,
                AwayTeamId = bvb.TeamId,
            };
            RemainingMatch fcnfck = new RemainingMatch()
            {
                HomeTeamId = fcn.TeamId,
                AwayTeamId = fck.TeamId,
            };
            RemainingMatch b04fcn = new RemainingMatch()
            {
                HomeTeamId = b04.TeamId,
                AwayTeamId = fcn.TeamId,
            };
            RemainingMatch bvbsge = new RemainingMatch()
            {
                HomeTeamId = bvb.TeamId,
                AwayTeamId = sge.TeamId,
            };
            RemainingMatch fckvfb = new RemainingMatch()
            {
                HomeTeamId = fck.TeamId,
                AwayTeamId = vfb.TeamId,
            };
            RemainingMatch fcnbvb = new RemainingMatch()
            {
                HomeTeamId = fcn.TeamId,
                AwayTeamId = bvb.TeamId,
            };
            RemainingMatch sgefck = new RemainingMatch()
            {
                HomeTeamId = sge.TeamId,
                AwayTeamId = fck.TeamId,
            };
            RemainingMatch vfbb04 = new RemainingMatch()
            {
                HomeTeamId = vfb.TeamId,
                AwayTeamId = b04.TeamId,
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
