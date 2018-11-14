using System;

namespace FootballData.Entities
{
    /// <summary>
    /// A class representing a football match which has yet to be played
    /// </summary>
    public class Fixture
    {
        private Match thisMatch;

        /// <summary>
        /// The league this match will be played in
        /// </summary>
        public League Division { get { return thisMatch.Division; } }

        /// <summary>
        /// The date this match will be played
        /// </summary>
        public DateTime MatchDate { get { return thisMatch.MatchDate; } }

        /// <summary>
        /// The home team for this match
        /// </summary>
        public Team HomeTeam { get { return thisMatch.HomeTeam; } }

        /// <summary>
        /// The away team for this match
        /// </summary>
        public Team AwayTeam { get { return thisMatch.AwayTeam; } }

        /// <summary>
        /// The betting data available for this match
        /// </summary>
        public Betting Betting { get { return thisMatch.Betting; } }

        internal Fixture(Match match)
        {
            thisMatch = match;
        }
    }
}
