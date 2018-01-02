using System;
using System.Configuration;

namespace FootballData
{
    public class FootballDataConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("baseUrl", IsRequired = true)]
        public string BaseUrl
        {
            get { return this["baseUrl"] as string; }
        }

        [ConfigurationProperty("leagues", IsRequired = true)]
        public FootballDataLeagueConfigurationCollection Leagues
        {
            get { return this["leagues"] as FootballDataLeagueConfigurationCollection; }
        }
    }

    public class FootballDataLeagueConfigurationElement : ConfigurationElement
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
