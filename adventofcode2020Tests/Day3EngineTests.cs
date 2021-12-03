using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day3;
using FluentAssertions;
using System;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day3EngineTests
    {
        [Theory]
        [InlineData(2, 1, "..##.......", "#...#...#..", ".#....#..#.", "..#.#...#.#", ".#...##..#.", "..#.##.....", ".#.#.#....#", ".#........#", "#.##...#...", "#...##....#", ".#..#...#.#")]
        [InlineData(7, 3, "..##.......", "#...#...#..", ".#....#..#.", "..#.#...#.#", ".#...##..#.", "..#.##.....", ".#.#.#....#", ".#........#", "#.##...#...", "#...##....#", ".#..#...#.#")]
        [InlineData(3, 5, "..##.......", "#...#...#..", ".#....#..#.", "..#.#...#.#", ".#...##..#.", "..#.##.....", ".#.#.#....#", ".#........#", "#.##...#...", "#...##....#", ".#..#...#.#")]
        [InlineData(4, 7, "..##.......", "#...#...#..", ".#....#..#.", "..#.#...#.#", ".#...##..#.", "..#.##.....", ".#.#.#....#", ".#........#", "#.##...#...", "#...##....#", ".#..#...#.#")]
        [InlineData(4, 3, "....", "####", "....", "####", "....", "####", "....", "####", "....")]
        [InlineData(7, 1, "....", ".#..", "..#.", "...#", "#...", ".#..", "..#.", "...#")]
        [InlineData(1, 2, "....", ".#..", "..#.", "...#", "#...", ".#..", "..#.", "...#")]
        public void YStep_1_SuccessSamples(int expected, int xStep, params string[] skiSlopePattern)
        {
            // Arrange
            var sut = new Day3Engine();
            int result;

            // Act
            result = sut.Execute(skiSlopePattern, xStep);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(2, 1, "..##.......", "#...#...#..", ".#....#..#.", "..#.#...#.#", ".#...##..#.", "..#.##.....", ".#.#.#....#", ".#........#", "#.##...#...", "#...##....#", ".#..#...#.#")]
        [InlineData(0, 1, "....", "####", "....", "####", "....", "####", "....", "####", "....")]
        [InlineData(4, 2, ".###", "....", "####", "....", "####", "....", "####", "....", "####", "....")]
        public void YStep_2_SuccessSamples(int expected, int xStep, params string[] skiSlopePattern)
        {
            // Arrange
            var sut = new Day3Engine();
            int yIncrement = 2;
            int result;

            // Act
            result = sut.Execute(skiSlopePattern, xStep, yIncrement);

            // Assert
            result.Should().Be(expected);
        }

    }
}
