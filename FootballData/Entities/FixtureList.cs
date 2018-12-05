using System;
using System.Collections.Generic;

namespace FootballData.Entities
{
    /// <summary>
    /// A class which acts as a container for the fixtures but 
    /// also returns when the data was last updated at the source.
    /// </summary>
    public class FixtureList
    {
        /// <summary>
        /// The list of fixtures
        /// </summary>
        public List<Fixture> Fixtures { get; set; }

        /// <summary>
        /// The date and time this data was last updated at the source
        /// </summary>
        public DateTime LastModifiedTime { get; set; }
    }
}
