using System;

namespace FootballData.Entities
{
    internal class Match
    {
        public League Division { get; set; }
        public Season Season { get; set; }
        public DateTime MatchDate { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public Referee Referee { get; set; }

        public Score FullTimeScore { get; set; }
        public Outcome FullTimeResult { get { return GetOutcome(FullTimeScore); } }

        public Score HalfTimeScore { get; set; }
        public Outcome HalfTimeResult { get { return GetOutcome(HalfTimeScore); } }

        public Betting Betting { get; set; }

        private Outcome GetOutcome(Score score)
        {
            var goalDelta = score.HomeGoals - score.AwayGoals;

            if (goalDelta > 0) { return Outcome.Home; }
            if (goalDelta < 0) { return Outcome.Away; }

            return Outcome.Draw;
        }
    }

    /// <summary>
    /// Enumeration representing the three outcomes of a football match
    /// </summary>
    public enum Outcome
    {
        /// <summary>
        /// The match was a draw
        /// </summary>
        Draw,

        /// <summary>
        /// The home team won
        /// </summary>
        Home,

        /// <summary>
        /// The away team won
        /// </summary>
        Away
    }
}