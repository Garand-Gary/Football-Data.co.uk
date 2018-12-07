using System;
using System.Linq;
using Xunit;

namespace FootballData.Tests
{
    public class SeasonsTest
    {
        [Fact]
        public void StartYear()
        {
            // Arrange
            const int expectedResult = 1993;

            // Act
            var year = Seasons.StartYear;

            // Assert
            Assert.Equal(expectedResult, year);
        }

        [Fact]
        public void LatestStartYear_June30th()
        {
            // Arrange
            var now = new DateTime(2018, 06, 30);
            int expected = 2017;

            // Act
            var latestYear = Seasons.LatestSeasonStartYear(now);

            // Assert
            Assert.Equal(expected, latestYear);
        }

        [Fact]
        public void LatestStartYear_July1st()
        {
            // Arrange
            var now = new DateTime(2018, 07, 01);
            int expected = 2018;

            // Act
            var latestYear = Seasons.LatestSeasonStartYear(now);

            // Assert
            Assert.Equal(expected, latestYear);
        }

        [Fact]
        public void GeneratedSeasons()
        {
            // Arrange
            var startYear = 2017;
            var endYear = 2020;

            var noOfSeasons = 4;

            // Act
            var seasons = Seasons.GenerateSeasons(startYear, endYear);

            // Assert
            Assert.Equal(noOfSeasons, seasons.Count);
            Assert.Equal("2021", seasons.First().Id); // Equivalent of the GetLatest() method
        }
    }
}
