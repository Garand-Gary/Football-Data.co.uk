using System;
using System.Collections.Generic;

namespace FootballData.Entities
{
    /// <summary>
    /// A class which acts as a container for the results but 
    /// also returns when the data was last updated at the source.
    /// </summary>
    public class ResultList
    {
        /// <summary>
        /// The list of results
        /// </summary>
        public List<Result> Results { get; set; }

        /// <summary>
        /// The date and time this data was last updated at the source
        /// </summary>
        public DateTime LastModifiedTime { get; set; }
    }
}
