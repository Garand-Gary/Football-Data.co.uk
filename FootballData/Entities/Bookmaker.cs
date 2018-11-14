namespace FootballData.Entities
{
    /// <summary>
    /// Class giving the football-data.co.uk ID for a bookmaker and its proper name
    /// </summary>
    public class Bookmaker
    {
        /// <summary>
        /// The football-data.co.uk short ID for the bookmaker, often found as a column name prefix
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The full name of the bookmaker
        /// </summary>
        public string Name { get; set; }
    }
}
