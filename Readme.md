### Code-Repository for the championship problem (np-complete problem)
This application uses different concepts to use todays championship problem test cases.
This can be done through two different approaches in the repository:
1. The application implemented with Windows.Forms provides a graphical interface, where one can browse the different countries with different leagues and seasons. If you chose all the different parameters through the dropdown boxes, one can select a stage and view the relevant stage standing in the data grid. For this stage standing one can compute the answer to the championship question ("Can the team still be champion at the end of the season?") and other similiar questions. For some of these questions the computation through the implemented backtracking needs to much time, because this computation can't be done in time. If the computation can be done in time, one can view the game results, computation results and stage standing results for the last question answer computed. Therefore one can easily debug different test cases of the championship problem.

2. The repository contains an test project, which can be browsed through Visual Studio 2017 (ChampionshipProblem.Test). In this project there is a subfolder and namespace "NUnit", which uses parametrized tests to define tests for all championship problem test cases available in the provided database (current: 38858 different test cases, 516 hard test cases). In the "CurrentTestSetup.cs" one can define the currently used test algorithm (Heuristic, Brute, evolutionary algorithm, simulated annealing, backtracking and Heuristics R) and the test timeout, which defines how long a test case should be run. Therefore the different test cases of the different algorithms can be started with the build ".dll" or by the provided test window of visual studio. Each test case executed writes a line in a created ".csv"-file placed in the build directory (bin/debug). Therefore test results as ".csv" can be easily used for analysing purposes.

### How to use the application part 
- The project uses the NuGet Package Manager of Visual Studio 2017 with the Package System.Data.SQLite. Therefore the binaries and package need to be installed or restored. (https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)<br>

### How to use the test part
- The project uses the NuGet Package Manager of Visual Studio 2017 with the Package System.Data.SQLite. Therefore the binaries and package need to be installed or restored. (https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)<br>


### How to create your own soccer database with more data
- The project uses the NuGet Package Manager of Visual Studio 2017 with the Package System.Data.SQLite. Therefore the binaries and package need to be installed or restored. (https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki)<br>
- As Database the Kaggle Database 'European Soccer Database' is used and needs to be configured in the App.config (projects: converter and test) or place the file in the Folder 'DatabaseFiles' named 'EuropeanSoccer.sqlite' (https://www.kaggle.com/hugomathien/soccer)<br>
- As World Cub data 'https://www.kaggle.com/abecklas/fifa-world-cup/' is used.
- Furthermore if you want to create a new Database Scheme for a Soccer Database, you would need an SQLite Provider like https://github.com/ErikEJ/SqlCeToolbox/wiki/EF6-workflow-with-SQLite-DDEX-provider <br>
