using System;

namespace FootballData.Entities
{
    /// <summary>
    /// A class representing a football match which has been played
    /// </summary>
    public class Result
    {
        private Match thisMatch;

        /// <summary>
        /// The league this match was played in
        /// </summary>
        public League Division { get { return thisMatch.Division; } }

        /// <summary>
        /// The season this match was played in
        /// </summary>
        public Season Season { get { return thisMatch.Season; } }

        /// <summary>
        /// The date this match was played
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
        /// The referee for this match
        /// </summary>
        public Referee Referee { get { return thisMatch.Referee; } }

        /// <summary>
        /// The score as it was at the end of the match
        /// </summary>
        public Score FullTimeScore { get { return thisMatch.FullTimeScore; } }

        /// <summary>
        /// The match outcome as it was at the end of the match
        /// </summary>
        public Outcome FullTimeResult { get { return thisMatch.FullTimeResult; } }

        /// <summary>
        /// The score as it was at half time
        /// </summary>
        public Score HalfTimeScore { get { return thisMatch.HalfTimeScore; } }

        /// <summary>
        /// The match outcome as it was at half time
        /// </summary>
        public Outcome HalfTimeResult { get { return thisMatch.HalfTimeResult; } }

        /// <summary>
        /// The betting data available for this match
        /// </summary>
        public Betting Betting { get { return thisMatch.Betting; } }

        internal Result(Match match)
        {
            thisMatch = match;
        }
    }
}