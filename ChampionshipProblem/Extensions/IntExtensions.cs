using System;

namespace ChampionshipProblem.Extensions
{
    /// <summary>
    /// Klasse für die Extensions des Int-Datentyps.
    /// </summary>
    public static class IntExtensions
    {
        #region ConvertToBase
        /// <summary>
        /// Methode zum Konvertieren der Int-Zahl in eine bestimmte Basis.
        /// </summary>
        /// <param name="number">Die Zahl.</param>
        /// <param name="radix">Die Basis.</param>
        /// <returns>Die Zahl in der bestimmten Basis.</returns>
        public static string ConvertToBase(this int number, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (number == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(number);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (number < 0)
            {
                result = "-" + result;
            }

            return result;
        }
        #endregion
    }
}
