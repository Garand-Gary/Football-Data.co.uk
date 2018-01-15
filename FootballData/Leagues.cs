using System.Collections.Generic;
using System.Linq;

namespace FootballData
{
    /// <summary>
    /// Container class for all leagues within the library
    /// </summary>
    public static class Leagues
    {
        /// <summary>
        /// Returns all leagues within the library
        /// </summary>
        /// <returns></returns>
        public static List<League> GetAll()
        {
            return Config.GetLeagues();
        }

        /// <summary>
        /// Returns all leagues within the specified country
        /// </summary>
        /// <param name="countryCode">The Id of the country for which leagues are being requested</param>
        /// <returns></returns>
        public static List<League> GetAllForCountry(string countryCode)
        {
            return GetAll().Where(x => x.Country == countryCode).ToList();
        }
    }
}