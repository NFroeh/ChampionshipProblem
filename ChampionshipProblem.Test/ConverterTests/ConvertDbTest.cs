namespace ChampionshipProblem.Test.ConverterTests
{
    using ChampionshipProblem.Converter;
    using ChampionshipProblem.DatabaseFiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics;
    using System.IO;

    [TestClass]
    public class ConvertDbTest
    {
        /// <summary>
        /// Methode zum Konvertieren der Datenbanken in die neue Datenbank.
        /// </summary>
        [TestMethod]
        public void TestConvertDb()
        {
            if (File.Exists(MainSoccerDb.PathToDatabase))
            {
                File.Delete(MainSoccerDb.PathToDatabase);
            }

            SoccerDBConverter.ConvertToNewDb();
            SoccerDBConverter.ConvertMissingLeagues();
        }
    }
}
