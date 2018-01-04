using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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