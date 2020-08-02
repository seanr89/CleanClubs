using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Utilities
{
    public static class HelperMethods
    {

        /// <summary>
        /// Static operation to get the name of the method calling this method
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The name of the method that is currently being called</returns>
        public static string GetCallerMemberName([CallerMemberName] string name = "")
        {
            return name;
        }


        /// <summary>
        /// Return a provide date formatted to a string for usage with SQL query parameters
        /// </summary>
        /// <param name="date">Date in question to format</param>
        /// <returns>A date string formatted to yyyy-MM-dd HH:mm:ss</returns>
        public static string GenerateSQLFormattedDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #region Generation Helpers

        /// <summary>
        /// Operation to check if the provided integer value is Even
        /// </summary>
        /// <param name="value">Integer value to compare</param>
        /// <returns>A Boolean True/False response</returns>
        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Static method to handle the "Randox" shuffling of a list of objects
        /// </summary>
        /// <param name="list"></param>
        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        #endregion
    }
}