namespace ChampionshipProblem.Services
{
    using ChampionshipProblem.Extensions;
    using System;

    /// <summary>
    /// Service enthält Methoden zum Errechnen der Erreichbarkeit von bestimmten Positionen.
    /// </summary>
    public class PositionService
    {
        #region CalculateIfTeamCanReachPosition
        /// <summary>
        /// Methode zum Berechnen, welche Position noch erreicht werden kann.
        /// </summary>
        /// <param name="pointDifferences">Die Punkteunterschiede zum betrachteten Team.</param>
        /// <param name="remainingGames">Die fehlenden Spiele.</param>
        /// <param name="index">Der index für die Ergebnisse des aktuellen Spieltags.</param>
        /// <returns>0, wenn möglich, sonst die Anzahl der teams, die über diesem stehen würden.</returns>
        public static int CalculateIfTeamCanReachPosition(int[] pointDifferences, Tuple<int, int>[] remainingGames, long index)
        {
            int numberOfTeamsAboveEntry = 0;

            // Hole die ternäre Repräsentation der Zahl
            string ternary = index.ConvertToBase(3);

            // Erzeuge die Tabelle
            for (int matchIndex = 0; matchIndex < remainingGames.Length; matchIndex++)
            {
                Tuple<int, int> game = remainingGames[matchIndex];
                byte matchResult = (matchIndex < ternary.Length) ? Convert.ToByte(ternary[ternary.Length - matchIndex - 1].ToString()) : (byte)0;

                if (matchResult == 0)
                {
                    pointDifferences[game.Item1]++;
                    pointDifferences[game.Item2]++;
                }
                else if (matchResult == 1)
                {
                    pointDifferences[game.Item1] += 3;
                }
                else
                {
                    pointDifferences[game.Item2] += 3;
                }
            }

            // Berechne die Anzahl der Mannschaften, die übr der aktuellen Mannschaft stehen
            for (int teamIndex = 0; teamIndex < pointDifferences.Length; teamIndex++)
            {
                if (pointDifferences[teamIndex] > 0)
                {
                    numberOfTeamsAboveEntry++;
                }
            }

            return numberOfTeamsAboveEntry;
        }
        #endregion
    }
}
