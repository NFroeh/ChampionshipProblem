

namespace System
{
    /// <summary>
    /// Klasse repräsentiert Erweiterungen für die Klasse Objekt.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Methode zum Konvertieren der Objekte zu einem Nullable-Decimal.
        /// </summary>
        /// <param name="obj">Das Objekt.</param>
        /// <returns>Der Nullable-Decimal.</returns>
        public static decimal? ConvertToDecimal(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return null;
            }

            return Convert.ToDecimal(obj);
        }
    }
}
