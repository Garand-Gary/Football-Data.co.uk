using System.Collections.Generic;

namespace FootballData
{
    public static class Countries
    {
        public static List<Country> GetAll()
        {
            return Config.GetCountries();
        }
    }
}
