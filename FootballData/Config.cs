using FootballData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FootballData
{
    internal static class Config
    {
        private static readonly string configFileName = "FootballData.FootballDataConfig.xml";

        internal static string ResultUrl
        {
            get { return GetConfigValue("url", "resultUrl", "url"); }
        }

        internal static string FixturesUrl
        {
            get { return GetConfigValue("url", "fixturesUrl", "url"); ; }
        }

        internal static List<Country> GetCountries()
        {
            var config = GetConfigFile();

            return config.Descendants("country")
                .Select(x => new Country()
                {
                    Id = x.Attribute("id").Value,
                    Name = x.Attribute("name").Value,
                    Nationality = x.Attribute("nationality").Value
                })
                .ToList();
        }

        internal static List<League> GetLeagues()
        {
            var config = GetConfigFile();

            // We want the proper country object associated with each league, not just the ID
            var countries = GetCountries();

            return config.Descendants("league")
                .Select(x => new League()
                {
                    Id = x.Attribute("id").Value,
                    Country = countries.First(c => c.Id == x.Attribute("country").Value),
                    Name = x.Attribute("name").Value,
                    Tier = Convert.ToInt32(x.Attribute("tier").Value)
                })
                .ToList();
        }

        internal static List<Bookmaker> GetBookmakers()
        {
            var config = GetConfigFile();

            return config.Descendants("bookmaker")
                .Select(x => new Bookmaker()
                {
                    Id = x.Attribute("id").Value,
                    Name = x.Attribute("name").Value
                })
                .ToList();
        }

        private static XDocument GetConfigFile()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var doc = assembly.GetManifestResourceStream(configFileName);

            XDocument config = XDocument.Load(doc);
            return config;
        }

        private static string GetConfigValue(string nodeType, string id, string attribute)
        {
            var config = GetConfigFile();

            return config.Descendants(nodeType)
                .Where(x => (string)x.Attribute("id") == id)
                .Select(x => x.Attribute(attribute).Value)
                .First();
        }
    }
}
