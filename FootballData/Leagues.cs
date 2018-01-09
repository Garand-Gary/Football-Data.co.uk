using System.Collections.Generic;
using System.Linq;

namespace FootballData
{
    public static class Leagues
    {
        public static List<League> GetAll()
        {
            return Config.GetLeagues();
        }

        public static List<League> GetAllForCountry(string countryCode)
        {
            return GetAll().Where(x => x.Country == countryCode).ToList();
        }
    }
}