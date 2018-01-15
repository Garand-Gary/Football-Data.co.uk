namespace FootballData
{
    /// <summary>
    /// Class representing a country that football-data.co.uk holds data for
    /// </summary>
    public class Country
    {
        /// <summary>
        /// A short identifier for the country
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the country
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The nationality of people or things from this country
        /// </summary>
        public string Nationality { get; set; }
    }
}
