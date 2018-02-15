namespace FootballData
{
    /// <summary>
    /// Class representing a league that football-data.co.uk holds data for
    /// </summary>
    public class League
    {
        /// <summary>
        /// The short ID football-data.co.uk uses, found in the data file name
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The country this league is based in
        /// </summary>
        public Country Country { get; set; }

        /// <summary>
        /// The name of this league
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The tier that this league is within the country
        /// </summary>
        public int Tier { get; set; }
    }
}
