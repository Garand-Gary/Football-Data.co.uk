using FootballData.Entities;
using System;
using Xunit;

namespace FootballData.Tests
{
    public class FixtureTest
    {
        private readonly Match _match;

        public FixtureTest()
        {
            var match = new Match()
            {
                MatchDate = new DateTime(2018, 11, 26),
                Division = new League() { Name = "Test Division" },
                Season = new Season(2018, 2019),
                HomeTeam = new Team() { Name = "Home Team" },
                AwayTeam = new Team() { Name = "Away Team" }
            };

            _match = match;
        }

        [Fact]
        public void MatchDate()
        {
            // Arrange
            var expectedValue = new DateTime(2018, 11, 26);

            // Act
            var fixture = new Fixture(_match);

            // Assert
            Assert.Equal(expectedValue, fixture.MatchDate);
        }

        [Fact]
        public void Division()
        {
            // Arrange
            const string expectedValue = "Test Division";

            // Act
            var fixture = new Fixture(_match);

            // Assert
            Assert.Equal(expectedValue, fixture.Division.Name);
        }

        [Fact]
        public void Season()
        {
            // Arrange
            const int expectedValue = 2018;

            // Act
            var fixture = new Fixture(_match);

            // Assert
            Assert.Equal(expectedValue, fixture.Season.StartYear);
        }

        [Fact]
        public void HomeTeam()
        {
            // Arrange
            const string expectedValue = "Home Team";

            // Act
            var fixture = new Fixture(_match);

            // Assert
            Assert.Equal(expectedValue, fixture.HomeTeam.Name);
        }

        [Fact]
        public void AwayTeam()
        {
            // Arrange
            const string expectedValue = "Away Team";

            // Act
            var fixture = new Fixture(_match);

            // Assert
            Assert.Equal(expectedValue, fixture.AwayTeam.Name);
        }
    }
}
