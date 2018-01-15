namespace FootballData
{
    /// <summary>
    /// Represents a team which participated in a match
    /// </summary>
    public class Team
    {
        /// <summary>
        /// The name of the team
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Statistics related to this team for a past match. Only applicable to results, not fixtures
        /// </summary>
        public Statistics Stats { get; set; }
    }
}
