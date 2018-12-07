using FootballData.Entities;
using System;
using Xunit;

namespace FootballData.Tests
{
    public class ResultTest
    {
        private readonly Match _match;

        public ResultTest()
        {
            var match = new Match()
            {
                MatchDate = new DateTime(2018, 11, 26),
                Division = new League() { Name = "Test Division" },
                Season = new Season(2018, 2019),
                HomeTeam = new Team() { Name = "Home Team" },
                AwayTeam = new Team() { Name = "Away Team" },
                Referee = new Referee() { Name = "Test Referee" },
                HalfTimeScore = new Score() { HomeGoals = 3, AwayGoals = 5 },
                FullTimeScore = new Score() { HomeGoals = 6, AwayGoals = 10 }
            };

            _match = match;
        }

        [Fact]
        public void MatchDate()
        {
            // Arrange
            var expectedValue = new DateTime(2018, 11, 26);

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedValue, result.MatchDate);
        }

        [Fact]
        public void Division()
        {
            // Arrange
            const string expectedValue = "Test Division";

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedValue, result.Division.Name);
        }

        [Fact]
        public void Season()
        {
            // Arrange
            const int expectedValue = 2018;

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedValue, result.Season.StartYear);
        }

        [Fact]
        public void HomeTeam()
        {
            // Arrange
            const string expectedValue = "Home Team";

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedValue, result.HomeTeam.Name);
        }

        [Fact]
        public void AwayTeam()
        {
            // Arrange
            const string expectedValue = "Away Team";

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedValue, result.AwayTeam.Name);
        }

        [Fact]
        public void Referee()
        {
            // Arrange
            const string expectedValue = "Test Referee";

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedValue, result.Referee.Name);
        }

        [Fact]
        public void HalfTimeScore()
        {
            // Arrange 
            var expectedResult = new Score() { HomeGoals = 3, AwayGoals = 5 };

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedResult.HomeGoals, result.HalfTimeScore.HomeGoals);
            Assert.Equal(expectedResult.AwayGoals, result.HalfTimeScore.AwayGoals);
        }

        [Fact]
        public void FullTimeScore()
        {
            // Arrange 
            var expectedResult = new Score() { HomeGoals = 6, AwayGoals = 10 };

            // Act
            var result = new Result(_match);

            // Assert
            Assert.Equal(expectedResult.HomeGoals, result.FullTimeScore.HomeGoals);
            Assert.Equal(expectedResult.AwayGoals, result.FullTimeScore.AwayGoals);
        }
    }
}
