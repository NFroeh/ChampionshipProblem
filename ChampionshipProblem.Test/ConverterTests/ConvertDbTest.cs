namespace ChampionshipProblem.Test.ConverterTests
{
    using ChampionshipProblem.Classes;
    using ChampionshipProblem.Converter;
    using ChampionshipProblem.DatabaseFiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            SoccerDBConverter.ConvertEuropeanSoccerDb();

            // Als Nächstes die zusätzlichen Ligen konvertieren
            // England
            ExcelFileConverter.ConvertExcelFile("England\\E01617.csv", League.EnglandD0LeagueName, Country.England, 20, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("England\\E01718.csv", League.EnglandD0LeagueName, Country.England, 20, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("England\\E01819.csv", League.EnglandD0LeagueName, Country.England, 20, "2018/2019");

            // England Championship
            ExcelFileConverter.ConvertExcelFile("England\\E10809.csv", League.EnglandD1LeagueName, Country.England, 24, "2008/2009");
            ExcelFileConverter.ConvertExcelFile("England\\E10910.csv", League.EnglandD1LeagueName, Country.England, 24, "2009/2010");
            ExcelFileConverter.ConvertExcelFile("England\\E11011.csv", League.EnglandD1LeagueName, Country.England, 24, "2010/2011");
            ExcelFileConverter.ConvertExcelFile("England\\E11112.csv", League.EnglandD1LeagueName, Country.England, 24, "2011/2012");
            ExcelFileConverter.ConvertExcelFile("England\\E11213.csv", League.EnglandD1LeagueName, Country.England, 24, "2012/2013");
            ExcelFileConverter.ConvertExcelFile("England\\E11314.csv", League.EnglandD1LeagueName, Country.England, 24, "2013/2014");
            ExcelFileConverter.ConvertExcelFile("England\\E11415.csv", League.EnglandD1LeagueName, Country.England, 24, "2014/2015");
            ExcelFileConverter.ConvertExcelFile("England\\E11516.csv", League.EnglandD1LeagueName, Country.England, 24, "2015/2016");
            ExcelFileConverter.ConvertExcelFile("England\\E11617.csv", League.EnglandD1LeagueName, Country.England, 24, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("England\\E11718.csv", League.EnglandD1LeagueName, Country.England, 24, "2017/2018");

            // Germany
            ExcelFileConverter.ConvertExcelFile("Germany\\D01617.csv", League.GermanyD0LeagueName, Country.Germany, 18, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Germany\\D01718.csv", League.GermanyD0LeagueName, Country.Germany, 18, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("Germany\\D01819.csv", League.GermanyD0LeagueName, Country.Germany, 18, "2018/2019");

            // Germany 2. Bundesliga 
            ExcelFileConverter.ConvertExcelFile("Germany\\D10809.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2008/2009");
            ExcelFileConverter.ConvertExcelFile("Germany\\D10910.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2009/2010");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11011.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2010/2011");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11112.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2011/2012");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11213.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2012/2013");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11314.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2013/2014");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11415.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2014/2015");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11516.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2015/2016");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11617.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11718.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2017/2018");
        }
    }
}
