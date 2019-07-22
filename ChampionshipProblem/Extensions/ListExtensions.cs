using System.Collections.Generic;
using System.Linq;

namespace System
{
    /// <summary>
    /// Klasse für die Extensions des List-Datentyps.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Extension dafür, dass keine Element dem predicate zutrifft.
        /// </summary>
        /// <typeparam name="T">Die Entität.</typeparam>
        /// <param name="list">Die Liste.</param>
        /// <param name="predicate">Die Funktion.</param>
        /// <returns>Wahr, wenn es kein Element gibt, sonst falsch.</returns>
        public static bool None<T>(this List<T> list, Func<T, bool> predicate)
        {
            return !list.Any(predicate);
        }
    }
}
