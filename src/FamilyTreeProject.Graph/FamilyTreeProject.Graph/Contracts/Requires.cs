using System;
using System.Globalization;

namespace FamilyTreeProject.Graph.Contracts
{
    /// <summary>
    /// Requires provides methods to enforce certain contracts
    /// </summary>
    public static class Requires
    {
        /// <summary>
        /// NotNull tests that the parameter is not null and throws if it is
        /// </summary>
        /// <param name="item">The object to test</param>
        /// <typeparam name="T">The type of the object to test</typeparam>
        /// <exception cref="ArgumentNullException">Throws an ArgumentNullException if the parameter is null</exception>
        public static void NotNull<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(typeof(T).Name);
            }
        }
        
        /// <summary>
        /// NotNullOrEmpty tests that the parameter is not null or an empty string and throws if it is
        /// </summary>
        /// <param name="parameter">The parameter to test</param>
        /// <param name="value">the value to test</param>
        /// <exception cref="ArgumentException">Throws an ArgumentException if the parameter is null or ""</exception>
        public static void NotNullOrEmpty(string parameter, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Argument '{parameter}' cannot be null or an empty string");
            }
        }
    }
}