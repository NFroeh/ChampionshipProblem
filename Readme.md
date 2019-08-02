### Code-Repository for the ChampionshipProblem (NP-Problem)
- The project uses the NuGet Package Manager of Visual Studio 2017 with the Package System.Data.SQLite. Therefore the binaries and package need to be installed. (https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)<br>

### Startup for converting the database
- As Database the Kaggle Database 'European Soccer Database' is used and needs to be configured in the App.config (projects: converter and test) or place the file in the Folder 'DatabaseFiles' named 'EuropeanSoccer.sqlite' (https://www.kaggle.com/hugomathien/soccer)<br>
- As World Cub data 'https://www.kaggle.com/abecklas/fifa-world-cup/' is used.
- Furthermore if you want to create a new Database Scheme for a Soccer Database, you would need an SQLite Provider like https://github.com/ErikEJ/SqlCeToolbox/wiki/EF6-workflow-with-SQLite-DDEX-provider <br>