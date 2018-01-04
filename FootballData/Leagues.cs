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
            // TODO: Get this information from a config file
            var result = new List<League>();

            result.Add(new League { Id = "E0", Country = "EN", Name = "Premier League" });
            result.Add(new League { Id = "E1", Country = "EN", Name = "Championship" });
            result.Add(new League { Id = "E2", Country = "EN", Name = "League One" });
            result.Add(new League { Id = "E3", Country = "EN", Name = "League Two" });
            result.Add(new League { Id = "EC", Country = "EN", Name = "Conference" });
            
            return result;
        }

        public static List<League> GetAllForCountry(string countryCode)
        {
            return GetAll().Where(x => x.Country == countryCode).ToList();
        }
    }
}
