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
        [Ignore]
        public void TestConvertDb()
        {
            if (File.Exists(MainSoccerDb.PathToDatabase))
            {
                File.Delete(MainSoccerDb.PathToDatabase);
            }

            SoccerDBConverter.ConvertEuropeanSoccerDb();

            // Als Nächstes die zusätzlichen Ligen konvertieren
            // England
            // ExcelFileConverter.ConvertExcelFile("England\\E01617.csv", League.EnglandD0LeagueName, Country.England, 20, "2016/2017");
            // ExcelFileConverter.ConvertExcelFile("England\\E01718.csv", League.EnglandD0LeagueName, Country.England, 20, "2017/2018");
            // ExcelFileConverter.ConvertExcelFile("England\\E01819.csv", League.EnglandD0LeagueName, Country.England, 20, "2018/2019");

            // England Championship
            // ExcelFileConverter.ConvertExcelFile("England\\E10809.csv", League.EnglandD1LeagueName, Country.England, 24, "2008/2009");
            // ExcelFileConverter.ConvertExcelFile("England\\E10910.csv", League.EnglandD1LeagueName, Country.England, 24, "2009/2010");
            // ExcelFileConverter.ConvertExcelFile("England\\E11011.csv", League.EnglandD1LeagueName, Country.England, 24, "2010/2011");
            // ExcelFileConverter.ConvertExcelFile("England\\E11112.csv", League.EnglandD1LeagueName, Country.England, 24, "2011/2012");
            // ExcelFileConverter.ConvertExcelFile("England\\E11213.csv", League.EnglandD1LeagueName, Country.England, 24, "2012/2013");
            // ExcelFileConverter.ConvertExcelFile("England\\E11314.csv", League.EnglandD1LeagueName, Country.England, 24, "2013/2014");
            // ExcelFileConverter.ConvertExcelFile("England\\E11415.csv", League.EnglandD1LeagueName, Country.England, 24, "2014/2015");
            // ExcelFileConverter.ConvertExcelFile("England\\E11516.csv", League.EnglandD1LeagueName, Country.England, 24, "2015/2016");
            // ExcelFileConverter.ConvertExcelFile("England\\E11617.csv", League.EnglandD1LeagueName, Country.England, 24, "2016/2017");
            // ExcelFileConverter.ConvertExcelFile("England\\E11718.csv", League.EnglandD1LeagueName, Country.England, 24, "2017/2018");

            // Germany
            ExcelFileConverter.ConvertExcelFile("Germany\\D01617.csv", League.GermanyD0LeagueName, Country.Germany, 18, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Germany\\D01718.csv", League.GermanyD0LeagueName, Country.Germany, 18, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("Germany\\D01819.csv", League.GermanyD0LeagueName, Country.Germany, 18, "2018/2019"); 

            // Germany 2. Bundesliga 
            ExcelFileConverter.ConvertExcelFile("Germany\\D10809.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2008/2009");
            ExcelFileConverter.ConvertExcelFile("Germany\\D10910.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2009/2010"); // (nur bis Spieltag 23)
            ExcelFileConverter.ConvertExcelFile("Germany\\D11011.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2010/2011");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11112.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2011/2012"); // (nur bis Spieltag 25)
            ExcelFileConverter.ConvertExcelFile("Germany\\D11213.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2012/2013");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11314.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2013/2014");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11415.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2014/2015");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11516.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2015/2016");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11617.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11718.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("Germany\\D11819.csv", League.GermanyD1LeagueName, Country.Germany, 18, "2018/2019"); // (nur bis Spieltag (23)

            // Italy
            //ExcelFileConverter.ConvertExcelFile("Italy\\I01617.csv", League.ItalyD0LeagueName, Country.Italy, 20, "2016/2017");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I01718.csv", League.ItalyD0LeagueName, Country.Italy, 20, "2017/2018");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I01819.csv", League.ItalyD0LeagueName, Country.Italy, 20, "2018/2019");

            // Italy Serie B
            //ExcelFileConverter.ConvertExcelFile("Italy\\I10809.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2008/2009");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I10910.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2009/2010");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11011.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2010/2011");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11112.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2011/2012");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11213.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2012/2013");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11314.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2013/2014");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11415.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2014/2015");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11516.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2015/2016");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11617.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2016/2017");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11718.csv", League.ItalyD1LeagueName, Country.Italy, 22, "2017/2018");
            //ExcelFileConverter.ConvertExcelFile("Italy\\I11819.csv", League.ItalyD1LeagueName, Country.Italy, 20, "2018/2019");

            // Spain Liga Premiera
            //ExcelFileConverter.ConvertExcelFile("Spain\\SP01617.csv", League.SpainD0LeagueName, Country.Spain, 20, "2016/2017");
            //ExcelFileConverter.ConvertExcelFile("Spain\\SP01718.csv", League.SpainD0LeagueName, Country.Spain, 20, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("Spain\\SP01819.csv", League.SpainD0LeagueName, Country.Spain, 20, "2018/2019");

            // Spain Liga Segunda
            ExcelFileConverter.ConvertExcelFile("Spain\\SP10809.csv", League.SpainD1LeagueName, Country.Spain, 22, "2008/2009"); // 22
            ExcelFileConverter.ConvertExcelFile("Spain\\SP10910.csv", League.SpainD1LeagueName, Country.Spain, 22, "2009/2010"); // 22
            ExcelFileConverter.ConvertExcelFile("Spain\\SP11011.csv", League.SpainD1LeagueName, Country.Spain, 22, "2010/2011"); // 21
            // ExcelFileConverter.ConvertExcelFile("Spain\\SP11112.csv", League.SpainD1LeagueName, Country.Spain, 22, "2011/2012");
            ExcelFileConverter.ConvertExcelFile("Spain\\SP11213.csv", League.SpainD1LeagueName, Country.Spain, 22, "2012/2013");
            ExcelFileConverter.ConvertExcelFile("Spain\\SP11314.csv", League.SpainD1LeagueName, Country.Spain, 22, "2013/2014");
            //ExcelFileConverter.ConvertExcelFile("Spain\\SP11415.csv", League.SpainD1LeagueName, Country.Spain, 22, "2014/2015");
            //ExcelFileConverter.ConvertExcelFile("Spain\\SP11516.csv", League.SpainD1LeagueName, Country.Spain, 22, "2015/2016");
            //ExcelFileConverter.ConvertExcelFile("Spain\\SP11617.csv", League.SpainD1LeagueName, Country.Spain, 22, "2016/2017");
            //ExcelFileConverter.ConvertExcelFile("Spain\\SP11718.csv", League.SpainD1LeagueName, Country.Spain, 22, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("Spain\\SP11819.csv", League.SpainD1LeagueName, Country.Spain, 22, "2018/2019");

            // France La Championnat
            //ExcelFileConverter.ConvertExcelFile("France\\F01617.csv", League.FranceD0LeagueName, Country.France, 20, "2016/2017");
            //ExcelFileConverter.ConvertExcelFile("France\\F01718.csv", League.FranceD0LeagueName, Country.France, 20, "2017/2018");
            //ExcelFileConverter.ConvertExcelFile("France\\F01819.csv", League.FranceD0LeagueName, Country.France, 20, "2018/2019");

            // France Divison 2
            //ExcelFileConverter.ConvertExcelFile("France\\F10809.csv", League.FranceD1LeagueName, Country.France, 20, "2008/2009");
            //ExcelFileConverter.ConvertExcelFile("France\\F10910.csv", League.FranceD1LeagueName, Country.France, 20, "2009/2010");
            ExcelFileConverter.ConvertExcelFile("France\\F11011.csv", League.FranceD1LeagueName, Country.France, 20, "2010/2011");
            //ExcelFileConverter.ConvertExcelFile("France\\F11112.csv", League.FranceD1LeagueName, Country.France, 20, "2011/2012");
            //ExcelFileConverter.ConvertExcelFile("France\\F11213.csv", League.FranceD1LeagueName, Country.France, 20, "2012/2013");
            //ExcelFileConverter.ConvertExcelFile("France\\F11314.csv", League.FranceD1LeagueName, Country.France, 20, "2013/2014");
            //ExcelFileConverter.ConvertExcelFile("France\\F11415.csv", League.FranceD1LeagueName, Country.France, 20, "2014/2015");
            ExcelFileConverter.ConvertExcelFile("France\\F11516.csv", League.FranceD1LeagueName, Country.France, 20, "2015/2016");
            //ExcelFileConverter.ConvertExcelFile("France\\F11617.csv", League.FranceD1LeagueName, Country.France, 20, "2016/2017");
            //ExcelFileConverter.ConvertExcelFile("France\\F11718.csv", League.FranceD1LeagueName, Country.France, 20, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("France\\F11819.csv", League.FranceD1LeagueName, Country.France, 20, "2018/2019"); // 22

            // Netherlands 1
            ExcelFileConverter.ConvertExcelFile("Netherlands\\N01617.csv", League.NetherlandsD0LeagueName, Country.Netherlands, 18, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Netherlands\\N01718.csv", League.NetherlandsD0LeagueName, Country.Netherlands, 18, "2017/2018");
            //ExcelFileConverter.ConvertExcelFile("Netherlands\\N01819.csv", League.NetherlandsD0LeagueName, Country.Netherlands, 18, "2018/2019");

            // Belgium Jupiler League
            //ExcelFileConverter.ConvertExcelFile("Belgium\\B01617.csv", League.BelgiumD0LeagueName, Country.Belgium, 16, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Belgium\\B01718.csv", League.BelgiumD0LeagueName, Country.Belgium, 16, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("Belgium\\B01819.csv", League.BelgiumD0LeagueName, Country.Belgium, 16, "2018/2019");

            // Portugal Zon Sagres
            ExcelFileConverter.ConvertExcelFile("Portugal\\P01617.csv", League.PortugalD0LeagueName, Country.Portugal, 18, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Portugal\\P01718.csv", League.PortugalD0LeagueName, Country.Portugal, 18, "2017/2018"); // 23
            ExcelFileConverter.ConvertExcelFile("Portugal\\P01819.csv", League.PortugalD0LeagueName, Country.Portugal, 18, "2018/2019");

            // Turkey D0
            ExcelFileConverter.ConvertExcelFile("Turkey\\T00809.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2008/2009");
            //ExcelFileConverter.ConvertExcelFile("Turkey\\T00910.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2009/2010");
            ExcelFileConverter.ConvertExcelFile("Turkey\\T01011.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2010/2011");
            //ExcelFileConverter.ConvertExcelFile("Turkey\\T01112.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2011/2012");
            ExcelFileConverter.ConvertExcelFile("Turkey\\T01213.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2012/2013");
            ExcelFileConverter.ConvertExcelFile("Turkey\\T01314.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2013/2014");
            ExcelFileConverter.ConvertExcelFile("Turkey\\T01415.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2014/2015");
            //ExcelFileConverter.ConvertExcelFile("Turkey\\T01516.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2015/2016");
            //ExcelFileConverter.ConvertExcelFile("Turkey\\T01617.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2016/2017");
            ExcelFileConverter.ConvertExcelFile("Turkey\\T01718.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2017/2018");
            ExcelFileConverter.ConvertExcelFile("Turkey\\T01819.csv", League.TurkeyD0LeagueName, Country.Turkey, 18, "2018/2019");

            // Greece D0
            ExcelFileConverter.ConvertExcelFile("Greece\\G00809.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2008/2009");
            ExcelFileConverter.ConvertExcelFile("Greece\\G00910.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2009/2010");
            //ExcelFileConverter.ConvertExcelFile("Greece\\G01011.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2010/2011");
//            ExcelFileConverter.ConvertExcelFile("Greece\\G01112.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2011/2012");
            //ExcelFileConverter.ConvertExcelFile("Greece\\G01213.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2012/2013");
            ExcelFileConverter.ConvertExcelFile("Greece\\G01314.csv", League.GreeceD0LeagueName, Country.Greece, 18, "2013/2014");
//            ExcelFileConverter.ConvertExcelFile("Greece\\G01415.csv", League.GreeceD0LeagueName, Country.Greece, 18, "2014/2015");
            //ExcelFileConverter.ConvertExcelFile("Greece\\G01516.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2015/2016");
            ExcelFileConverter.ConvertExcelFile("Greece\\G01617.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2016/2017"); // bis 18
            ExcelFileConverter.ConvertExcelFile("Greece\\G01718.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2017/2018");
//            ExcelFileConverter.ConvertExcelFile("Greece\\G01819.csv", League.GreeceD0LeagueName, Country.Greece, 16, "2018/2019");
        }
    }
}
