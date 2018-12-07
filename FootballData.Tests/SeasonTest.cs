using FootballData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FootballData.Tests
{
    public class SeasonTest
    {
        private readonly Season _season;

        private const int _startYear = 2018;
        private const int _endYear = 2019;

        private const string _id = "1819";
        private const string _name = "2018/19";
        private const string _shortName = "18/19";
        private const string _longName = "2018/2019";

        public SeasonTest()
        {
            _season = new Season(_startYear, _endYear);
        }

        [Fact]
        public void Id()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(_id, _season.Id);
        }

        [Fact]
        public void Name()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(_name, _season.Name);
        }

        [Fact]
        public void ShortName()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(_shortName, _season.ShortName);
        }

        [Fact]
        public void LongName()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(_longName, _season.LongName);
        }
    }
}
