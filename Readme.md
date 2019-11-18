# Code-Repository for the championship problem (np-complete problem)
This application uses different algorithms to solves todays championship problem test cases.
This can be done through two different approaches in the repository:
1. The application implemented with Windows.Forms provides a graphical interface, where one can browse the different countries with different leagues and seasons. If you chose all the different parameters through the dropdown boxes, one can select a stage and view the relevant stage standing in the data grid. For this stage standing one can compute the answer for the championship problem ("Can the team still be champion at the end of the season?") and other similiar questions. For some of these questions the computation through the implemented backtracking needs too much time, because the championship problem is NP-complete. If the computation can be done in time and the result was true, one can view the game results, computation results and stage standing results for the last answer computed. Therefore one can easily debug different test cases for the championship problem.

2. The repository contains an test project, which can be browsed through Visual Studio 2017 (ChampionshipProblem.Test). In this project there is a subfolder and namespace "NUnit", which uses parametrized tests to define tests for all championship problem test cases available in the provided database (current: 38858 different test cases, 516 hard test cases). In the "CurrentTestSetup.cs" one can define the currently used test algorithm (Heuristic, Brute-Force, Evolutionary Algorithm, Simulated Annealing, Backtracking and Heuristics R) and the test timeout, which defines how long a test case should be run. Therefore the different test cases of the different algorithms can be started with the build ".dll" or by the provided test window of Visual Studio. Each test case executed writes a line in a created CSV-file placed in the build directory (bin/debug). Therefore test results as ".csv" can be easily used for analysing purposes.

## How to use the graphical interface 
1. The project uses the NuGet Package Manager of Visual Studio 2017 with the Package System.Data.SQLite. Therefore the binaries and package need to be installed or restored. (https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)<br>
2. Build the project and start it through Visual Studio or ChampionshipProblem.exe.
3. Select your desired test case by choosing a country, league, season and stage. 
4. Use the offered buttons to execute different computations for results like best or worst possible position or the championship problem itself. The results (if the computation had the result true) with the appointed match results and the resulting table can be viewed in the additionally datagrids.

## How to use the NUnit test part
1. The project uses the NuGet Package Manager of Visual Studio 2017 with the Package System.Data.SQLite. Therefore the binaries and package need to be installed or restored. (https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)<br>
2. Open your solution in Visual Studio and navigate to the Test Window. There you can find the namespace "ChampionshipProblem.Test.NUnit", which contains the defined test cases. 
3. In "CurrentTestSetup.cs" one can define the timeout for the tests (property TestTimeout) and the algorithm to solve the different test cases (Heuristic, Brute, evolutionary algorithm, simulated annealing, backtracking and Heuristics R for property CurrentTestType). Furthermore used parameters like the number of iterations or the annealing parameters of the (1+1)-EA and Simulated Annealing can be edited in the "CurrentTestSetup.cs"-file.
4. Just run the different tests with your test setup by running the desired test cases. The results with different informations are written in the build directory (bin/debug) in a CSV-file (seperated by algorithm) for each test case. This data extraction could easily be extended.

## How to create your own soccer database with more data
1. The project uses the NuGet Package Manager of Visual Studio 2017 with the Package System.Data.SQLite. Therefore the binaries and package need to be installed or restored. (https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)<br>
2. As Database the Kaggle Database 'European Soccer Database' is used and needs to be configured in the App.config (projects: converter and test) or place the file in the Folder 'DatabaseFiles' named 'EuropeanSoccer.sqlite' (https://www.kaggle.com/hugomathien/soccer). The connection string in the "app.config" file in the projects ".Test" and ".Converter" need to updated for your system.<br>
As World Cub data 'https://www.kaggle.com/abecklas/fifa-world-cup/' is used.
3. Furthermore if you want to create a new Database Scheme for a Soccer Database, you would need an SQLite Provider like https://github.com/ErikEJ/SqlCeToolbox/wiki/EF6-workflow-with-SQLite-DDEX-provider <br>
4. To create more data from CSV-files like from https://www.football-data.co.uk/ you can put those anywhere in the project (like in the folder "ExcelFiles"). After that just add a line to "ConvertDbTest.cs", where you convert the data from that specific excel file.
5. To create your own database, you need to unignore the ConvertDbTest.cs and run the test to create your new MainSoccerDb.sqlite.

If there are remaining questions just leave a note in the issues section.
