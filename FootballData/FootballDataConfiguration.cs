using System;
using System.Configuration;

namespace FootballData
{
    public class FootballDataConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("resultUrl", IsRequired = true)]
        public string ResultUrl
        {
            get { return this["resultUrl"] as string; }
        }

        [ConfigurationProperty("fixturesUrl", IsRequired = true)]
        public string FixturesUrl
        {
            get { return this["fixturesUrl"] as string; }
        }

        [ConfigurationProperty("leagues", IsRequired = true)]
        public FootballDataLeagueConfigurationCollection Leagues
        {
            get { return this["leagues"] as FootballDataLeagueConfigurationCollection; }
        }
    }

    public class FootballDataCountryConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id
        {
            get { return this["id"] as string; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
        }

        [ConfigurationProperty("nationality", IsRequired = true)]
        public string Nationality
        {
            get { return this["nationality"] as string; }
        }
    }

    public class FootballDataCountryConfigurationCollection : ConfigurationElementCollection
    {
        public FootballDataCountryConfigurationElement this[int index]
        {
            get { return BaseGet(index) as FootballDataCountryConfigurationElement; }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FootballDataCountryConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FootballDataCountryConfigurationElement)element).Id;
        }
    }

    public class FootballDataLeagueConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string Id
        {
            get { return this["id"] as string; }
        }

        [ConfigurationProperty("country", IsRequired = true)]
        public string Country
        {
            get { return this["country"] as string; }
        }

        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return this["name"] as string; }
        }

        [ConfigurationProperty("tier", IsRequired = true)]
        public int Tier
        {
            get { return (int)this["tier"]; }
        }
    }

    public class FootballDataLeagueConfigurationCollection : ConfigurationElementCollection
    {
        public FootballDataLeagueConfigurationElement this[int index]
        {
            get { return BaseGet(index) as FootballDataLeagueConfigurationElement; }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FootballDataLeagueConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FootballDataLeagueConfigurationElement)element).Id;
        }
    }
}
