using adventofcode2020.Puzzles.Day15;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static adventofcode2020.Puzzles.Day15.Day15Engine;

namespace adventofcode2020Tests
{
    public class Day15EngineTests
    {

        [Theory]
        [InlineData(0, 4, "0,3,6")]
        [InlineData(3, 5, "0,3,6,0")]
        [InlineData(3, 6, "0,3,6,0,3")]
        [InlineData(1, 7, "0,3,6,0,3,3")]
        [InlineData(0, 8, "0,3,6,0,3,3,1")]
        [InlineData(4, 9, "0,3,6,0,3,3,1,0")]
        [InlineData(0, 10, "0,3,6,0,3,3,1,0,4")]
        [InlineData(1, 7, "0,3,6")]
        [InlineData(436, 2020, "0,3,6")]
        [InlineData(1, 2020, "1,3,2")]
        [InlineData(10, 2020, "2,1,3")]
        [InlineData(27, 2020, "1,2,3")]
        [InlineData(78, 2020, "2,3,1")]
        [InlineData(438, 2020, "3,2,1")]
        [InlineData(1836, 2020, "3,1,2")]

        public void CalculatesLastNumberCorrectly(int expectedFinalValue, int turns, string startingNumbers)
        {
            // Arrange 
            var sut = new Day15Engine();

            // Act
            var result = sut.Execute(turns, startingNumbers);

            // Assert
            result.Should().Be(expectedFinalValue);
        }
    }
}
