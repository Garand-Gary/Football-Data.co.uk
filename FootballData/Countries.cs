using System.Collections.Generic;

namespace FootballData
{
    public static class Countries
    {
        public static List<Country> GetAll()
        {
            // TODO: Get this information from a config file
            var result = new List<Country>();

            result.Add(new Country { Id = "EN", Name = "England", Nationality = "English" });
            result.Add(new Country { Id = "SC", Name = "Scotland", Nationality = "Scottish" });

            return result;
        }
    }
}
