using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day10;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day10EngineTests
    {

        [Theory]
        [InlineData(35, 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4)]
        [InlineData(220, 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3)]
        public void CalculatesVoltDifferenceNumbers(int joltDifference, params int[] joltAdapters)
        {
            // Arrange 
            var sut = new Day10Engine();

            // Act
            var result = sut.Execute(joltAdapters);

            // Assert
            result.Should().Be(joltDifference);
        }

        [Theory]
        [InlineData(13, 1, 2, 3, 4, 5)]
        [InlineData(8, 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4)]
        [InlineData(19208, 28, 33, 18, 42, 31, 14, 46, 20, 48, 47, 24, 23, 49, 45, 19, 38, 39, 11, 1, 32, 25, 35, 8, 17, 7, 9, 4, 2, 34, 10, 3)]
        public void CalculatesNumAdapterOptions(int numRoutes, params int[] joltAdapters)
        {
            // Arrange 
            var sut = new Day10Engine();

            // Act
            var result = sut.Execute2(joltAdapters);

            // Assert
            result.Should().Be(numRoutes);
        }
    }
}
