using FootballData.Entities;
using Xunit;

namespace FootballData.Tests
{
    public class MatchTest
    {
        [Fact]
        public void FullTimeResult_HomeWin()
        {
            // Arrange
            var expectedResult = Outcome.Home;

            var match = new Match();
            var score = new Score()
            {
                HomeGoals = 1,
                AwayGoals = 0
            };

            // Act
            match.FullTimeScore = score;

            // Assert
            Assert.Equal(expectedResult, match.FullTimeResult);
        }

        [Fact]
        public void FullTimeResult_AwayWin()
        {
            // Arrange
            var expectedResult = Outcome.Away;

            var match = new Match();
            var score = new Score()
            {
                HomeGoals = 0,
                AwayGoals = 1
            };

            // Act
            match.FullTimeScore = score;

            // Assert
            Assert.Equal(expectedResult, match.FullTimeResult);
        }

        [Fact]
        public void FullTimeResult_Draw()
        {
            // Arrange
            var expectedResult = Outcome.Draw;

            var match = new Match();
            var score = new Score()
            {
                HomeGoals = 0,
                AwayGoals = 0
            };

            // Act
            match.FullTimeScore = score;

            // Assert
            Assert.Equal(expectedResult, match.FullTimeResult);
        }
        [Fact]
        public void HalfTimeResult_HomeWin()
        {
            // Arrange
            var expectedResult = Outcome.Home;

            var match = new Match();
            var score = new Score()
            {
                HomeGoals = 1,
                AwayGoals = 0
            };

            // Act
            match.HalfTimeScore = score;

            // Assert
            Assert.Equal(expectedResult, match.HalfTimeResult);
        }

        [Fact]
        public void HalfTimeResult_AwayWin()
        {
            // Arrange
            var expectedResult = Outcome.Away;

            var match = new Match();
            var score = new Score()
            {
                HomeGoals = 0,
                AwayGoals = 1
            };

            // Act
            match.HalfTimeScore = score;

            // Assert
            Assert.Equal(expectedResult, match.HalfTimeResult);
        }

        [Fact]
        public void HalfTimeResult_Draw()
        {
            // Arrange
            var expectedResult = Outcome.Draw;

            var match = new Match();
            var score = new Score()
            {
                HomeGoals = 0,
                AwayGoals = 0
            };

            // Act
            match.HalfTimeScore = score;

            // Assert
            Assert.Equal(expectedResult, match.HalfTimeResult);
        }
    }
}
