using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day5;
using FluentAssertions;
using System;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day5EngineTests
    {
        [Theory]
        [InlineData(0, "FFFFFFF")]
        [InlineData(44, "FBFBBFF")]
        [InlineData(45, "FBFBBFB")]
        [InlineData(70, "BFFFBBF")]
        [InlineData(14, "FFFBBBF")]
        [InlineData(102, "BBFFBBF")]
        [InlineData(127, "BBBBBBB")]
        public void ParsesRowCorrectlyFromBarCode(int expected, string barCode)
        {
            // Arrange
            var sut = new BoardingCard(barCode);

            // Act
            var result = sut.Row;

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, "AAAAAAALLL")]
        [InlineData(1, "AAAAAAALLR")]
        [InlineData(2, "AAAAAAALRL")]
        [InlineData(3, "AAAAAAALRR")]
        [InlineData(4, "AAAAAAARLL")]
        [InlineData(5, "AAAAAAARLR")]
        [InlineData(6, "AAAAAAARRL")]
        [InlineData(7, "AAAAAAARRR")]
        public void ParsesColCorrectlyFromBarCode(int expected, string barCode)
        {
            // Arrange
            var sut = new BoardingCard(barCode);

            // Act
            var result = sut.Col;

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(357, "FBFBBFFRLR")]
        [InlineData(567, "BFFFBBFRRR")]
        [InlineData(119, "FFFBBBFRRR")]
        [InlineData(820, "BBFFBBFRLL")]
        public void CalculatesSeatIdCorrectly(int expected, string barCode)
        {
            // Arrange
            var sut = new BoardingCard(barCode);

            // Act
            var result = sut.SeatId;

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(-1, "FFFFFFFLLL", "FFFFFFFLRL", "FFFFFFBLLL", "FFFFFFBLLR")]
        [InlineData(-1, "BBBBBBBLLL", "BBBBBBBLRL", "FFFFFFBLLL", "FFFFFFBLLR")]
        public void IgnoresFirstAndLastRows(int expected, params string[] barCodeData)
        {
            // Arrange
            var sut = new Day5Engine();

            // Act
            var result = sut.Execute2(barCodeData);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(9, "FFFFFFFLLL", "FFFFFFBLRL", "FFFFFFBLLL", "BBBBBBBLLL")]
        [InlineData(334, "FBFBFFBLLL", "FBFBFFBLLR", "FBFBFFBRRR", "FBFBFFBRLR")]
        public void FindsMatch_OutsideOfFirstAndLastRows(int expected, params string[] barCodeData)
        {
            // Arrange
            var sut = new Day5Engine();

            // Act
            var result = sut.Execute2(barCodeData);

            // Assert
            result.Should().Be(expected);
        }

    }
}
