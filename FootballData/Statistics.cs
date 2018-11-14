using FootballData.Entities;
using System.Collections.Generic;

namespace FootballData
{
    /// <summary>
    /// A container class for the statistics related to this team for a completed match (Result)
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// The list of metrics and values for this team for the Result in question
        /// </summary>
        public List<Statistic> List { get; set; }
    }
}
