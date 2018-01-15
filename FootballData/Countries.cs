using System.Collections.Generic;

namespace FootballData
{
    /// <summary>
    /// Container class for all countries within the library
    /// </summary>
    public static class Countries
    {
        /// <summary>
        /// Returns all countries within the library
        /// </summary>
        /// <returns></returns>
        public static List<Country> Get()
        {
            return Config.GetCountries();
        }
    }
}
