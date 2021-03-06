﻿using FootballData.Entities;
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
            var config = Config.GetConfigFile();

            return Config.GetLeagues(config);
        }

        /// <summary>
        /// Returns all leagues within the specified country
        /// </summary>
        /// <param name="countryCode">The Id of the country for which leagues are being requested</param>
        /// <returns></returns>
        public static List<League> GetAllForCountry(string countryCode)
        {
            return GetAll().Where(x => x.Country.Id == countryCode).ToList();
        }

        /// <summary>
        /// Returns all leagues within the specified country
        /// </summary>
        /// <param name="country">The Country object for which leagues are being requested</param>
        /// <returns></returns>
        public static List<League> GetAllForCountry(Country country)
        {
            return GetAllForCountry(country.Id);
        }
    }
}