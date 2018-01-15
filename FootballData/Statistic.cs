namespace FootballData
{
    /// <summary>
    /// A class representing a statistic about this team during a completed match (Result)
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// The metric being represented here
        /// </summary>
        public StatType Type { get; set; }

        /// <summary>
        /// The number of times the metric occurred
        /// </summary>
        public int? Value { get; set; }

        /// <summary>
        /// An enumeration representing the different metrics available
        /// </summary>
        public enum StatType
        {
            /// <summary>
            /// The number of attempts on goal
            /// </summary>
            Shots,

            /// <summary>
            /// The number of shots on target
            /// </summary>
            ShotsOnTarget,

            /// <summary>
            /// The number of times the woodwork was struck
            /// </summary>
            HitWoodwork,

            /// <summary>
            /// The number of corners won
            /// </summary>
            Corners,

            /// <summary>
            /// The number of fouls committed
            /// </summary>
            FoulsCommitted,

            /// <summary>
            /// The number of times the team was found offside
            /// </summary>
            Offsides,

            /// <summary>
            /// The number of yellow cards received
            /// </summary>
            YellowCards,

            /// <summary>
            /// The number of red cards received
            /// </summary>
            RedCards,

            /// <summary>
            /// The number of booking points the cards received represent
            /// </summary>
            BookingPoints
        }
    }
}
