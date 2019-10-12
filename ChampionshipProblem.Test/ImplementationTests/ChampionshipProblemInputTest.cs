namespace ChampionshipProblem.Test.Implementation
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Implementation;
    using ChampionshipProblem.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class ChampionshipProblemInputTest
    {
        [TestMethod]
        public void ChampionshipProblemInput_BasicTest()
        {
            ChampionshipViewModel championshipViewModel = new ChampionshipViewModel();

            LeagueStandingService leagueStandingService = new LeagueStandingService(championshipViewModel, Classes.Country.Germany, League.GermanyD0LeagueName, "2008/2009");
            int stage = 33;
            List<LeagueStandingEntry> standing = leagueStandingService.CalculateStanding(stage);
            ChampionshipProblemInput championshipProblemInputTest = new ChampionshipProblemInput(leagueStandingService, standing[0].TeamId, stage);

            stage = 31;
            standing = leagueStandingService.CalculateStanding(stage);
            championshipProblemInputTest = new ChampionshipProblemInput(leagueStandingService, standing[0].TeamId, stage);

            stage = 27;
            standing = leagueStandingService.CalculateStanding(stage);
            championshipProblemInputTest = new ChampionshipProblemInput(leagueStandingService, standing[0].TeamId, stage);
        }
    }
}
