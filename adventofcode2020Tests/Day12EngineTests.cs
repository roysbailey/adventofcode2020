using adventofcode2020.Puzzles.Day12;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static adventofcode2020.Puzzles.Day12.Day12Engine;

namespace adventofcode2020Tests
{
    public class Day12EngineTests
    {

        [Theory]
        [InlineData("SN=3;WE=0", 3, "N3")]
        [InlineData("SN=0;WE=0", 0, "N3", "S3")]
        [InlineData("SN=0;WE=4", 4, "F1", "F3")]
        [InlineData("SN=1;WE=1", 2, "F1", "L90", "F1")]
        [InlineData("SN=-8;WE=17", 25, "F10", "N3", "F7", "R90", "F11")]

        public void FerryCanSail(string expectedPos, int expectedManhattanDistance, params string[] directions)
        {
            // Arrange 
            var sut = new Ferry();

            // Act
            var result = sut.Sail(directions);

            // Assert
            result.ToString().Should().Be(expectedPos);
            result.ManhattanDistance.Should().Be(expectedManhattanDistance);
        }

        [Theory]
        [InlineData(3, 3, "N3")]
        [InlineData(121, 121, "N121")]
        [InlineData(-121, 121, "S121")]
        public void CanMoveNorthSouth(int expectedPos, int expectedManhattanDistance, string nsDirection)
        {
            // Arrange 
            var sut = new DirectionInstruction(nsDirection);
            var result = new Position();

            // Act
            sut.Move(result);

            // Assert
            result.SouthNorth.Should().Be(expectedPos);
            result.ManhattanDistance.Should().Be(expectedManhattanDistance);
        }

        [Theory]
        [InlineData(3, 3, "E3")]
        [InlineData(121, 121, "E121")]
        [InlineData(-121, 121, "W121")]
        public void CanMoveWestEast(int expectedPos, int expectedManhattanDistance, string weDirection)
        {
            // Arrange 
            var sut = new DirectionInstruction(weDirection);
            var result = new Position();

            // Act
            sut.Move(result);

            // Assert
            result.WestEast.Should().Be(expectedPos);
            result.ManhattanDistance.Should().Be(expectedManhattanDistance);
        }

        [Theory]
        [InlineData("S", "R", 90)]
        [InlineData("N", "R", 270)]
        [InlineData("W", "R", 180)]
        [InlineData("N", "L", 90)]
        [InlineData("E", "L", 360)]
        [InlineData("E", "R", 360)]
        public void ShipMovesCorrectly(string expectedHeading, string turnDirection, int degrees)
        {
            // Arrange 
            var sut = new Position();

            // Act
            sut.SetNewHeading(turnDirection, degrees);

            // Assert
            sut.CurrentHeading.Should().Be(expectedHeading);
        }

        [Theory]
        [InlineData("S", "R", 90)]
        [InlineData("N", "R", 270)]
        [InlineData("W", "R", 180)]
        [InlineData("N", "L", 90)]
        [InlineData("E", "L", 360)]
        [InlineData("E", "R", 360)]
        public void ShipTurnsCorrectly(string expectedHeading, string turnDirection, int degrees)
        {
            // Arrange 
            var sut = new Position();

            // Act
            sut.SetNewHeading(turnDirection, degrees);

            // Assert
            sut.CurrentHeading.Should().Be(expectedHeading);
        }
    }
}
