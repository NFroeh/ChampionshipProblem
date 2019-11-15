namespace Utility
{
    using ChampionshipProblem.Test.NUnit.ImplementationTests;
    using System;
    using System.IO;
    using System.Reflection;

    public class CSVWriter
    {
        private const string name = "AlgorithmResults.csv";

        public static void WriteTestResult(TestAlgorithm currentAlgorithm, string country, string leagueName, string season, int stage, int teamNumber, bool expected, bool? returned, bool isTrue, long computeTime, int numberTeams, int numberStages)
        {
            TestResultProperties testResultProperties = new TestResultProperties()
            {
                Country = country,
                LeagueName = leagueName,
                Season = season,
                Stage = stage,
                TeamNumber = teamNumber,
                Expected = expected,
                Returned = returned,
                IsTrue = isTrue,
                ComputeTime = computeTime,
                NumberTeams = numberTeams,
                NumberStages = numberStages,
                TeamBackIndex = numberTeams - teamNumber,
                StageBackIndex = numberStages - stage
            };
            string filename = string.Empty;
            switch (currentAlgorithm)
            {
                case TestAlgorithm.Heuristic:
                    filename = nameof(TestAlgorithm.Heuristic) + name;
                    CSVWriter.WriteTestResult(filename, testResultProperties);
                    break;
                case TestAlgorithm.Brute:
                    filename = nameof(TestAlgorithm.Brute) + name;
                    CSVWriter.WriteTestResult(filename, testResultProperties);
                    break;
                case TestAlgorithm.EA:
                    filename = nameof(TestAlgorithm.EA) + name;
                    CSVWriter.WriteTestResult(filename, testResultProperties);
                    break;
                case TestAlgorithm.SA:
                    filename = nameof(TestAlgorithm.SA) + name;
                    CSVWriter.WriteTestResult(filename, testResultProperties);
                    break;
                case TestAlgorithm.Backtracking:
                    filename = nameof(TestAlgorithm.Backtracking) + name;
                    CSVWriter.WriteTestResult(filename, testResultProperties);
                    break;
                case TestAlgorithm.HeuristicR:
                    filename = nameof(TestAlgorithm.HeuristicR) + name;
                    CSVWriter.WriteTestResult(filename, testResultProperties);
                    break;
                case TestAlgorithm.BackNewTest:
                    filename = nameof(TestAlgorithm.BackNewTest) + name;
                    CSVWriter.WriteTestResult(filename, testResultProperties);
                    break;
                default:
                    throw new Exception($"Unknown current algorithm {currentAlgorithm}");
            }
        }
        private static void WriteTestResult(string filename, TestResultProperties testResultProperties)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" +  filename;
            if (!File.Exists(path))
            {
                File.AppendAllText(path, "Country,LeagueName,Season,Stage,TeamNumber,Expected,Returned,IsTrue,ComputeTime,NumberTeams,NumberStages,TeamBackIndex,StageBackIndex");
            }

            File.AppendAllText(path, Environment.NewLine);
            File.AppendAllText(path, testResultProperties.ToString());
        }
    }
}
