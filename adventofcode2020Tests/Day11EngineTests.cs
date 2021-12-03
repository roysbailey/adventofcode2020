using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day11;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day11EngineTests
    {
        [Theory]
        [InlineData(".L#", 0, 0, "#.L#.L#.L#",
                                 "L#.L#.L#.L")]
        [InlineData("#.LL.#.L", 1, 1, "#.L#.L#.L#", 
                                      "L#.L#.L#.L", 
                                      "#.L#.L#.L#")]
        [InlineData("#.LL.#.L", 1, 4, "#.L#.L#.L#", 
                                      "L#.L#.L#.L", 
                                      "#.L#.L#.L#")]
        public void CanGetAdjascentSeats(string expectedAdjSeats, int row, int col, params string[] seats)
        {
            // Arrange 
            var sut = new Day11Engine();

            // Act
            var result = sut.GetAdjascentSeats(row, col, seats.ToList());

            // Assert
            result.Should().Be(expectedAdjSeats);
        }


        [Fact]
        public void RuleAppliesStep1()
        {
            // Arrange 
            var sut = new Day11Engine();

            string[] seats = { "L.LL.LL.LL", "LLLLLLL.LL", "L.L.L..L..", "LLLL.LL.LL", "L.LL.LL.LL", "L.LLLLL.LL", "..L.L.....", "LLLLLLLLLL", "L.LLLLLL.L", "L.LLLLL.LL" };
            string[] expectedSeats = { "#.##.##.##", "#######.##", "#.#.#..#..", "####.##.##", "#.##.##.##", "#.#####.##", "..#.#.....", "##########", "#.######.#", "#.#####.##" };

            // Act
            var result = sut.ApplyRules(seats.ToList());

            // Assert
            string.Concat(result).Should().Be(string.Concat(expectedSeats));
        }

        public void RuleAppliesStep2()
        {
            // Arrange 
            var sut = new Day11Engine();

            string[] seats = { "#.##.##.##", "#######.##", "#.#.#..#..", "####.##.##", "#.##.##.##", "#.#####.##", "..#.#.....", "##########", "#.######.#", "#.#####.##" };
            string[] expectedSeats = { "#.LL.L#.##", "# LLLLLL.L#", "L.L.L..L..", "#LLL.LL.L#", "#.LL.LL.LL", "#.LLLL#.##", "..L.L.....", "#LLLLLLLL#", "#.LLLLLL.L", "#.#LLLL.##" };

            // Act
            var result = sut.ApplyRules(seats.ToList());

            // Assert
            string.Concat(result).Should().Be(string.Concat(expectedSeats));
        }



        [Theory]
        [InlineData(37, "#.##.##.##", "#######.##", "#.#.#..#..", "####.##.##", "#.##.##.##", "#.#####.##", "..#.#.....", "##########", "#.######.#", "#.#####.##")]
        public void CalculatesOccupiedSeats(int expectedOccupiedSeats, params string[] seats)
        {
            // Arrange 
            var sut = new Day11Engine();

            // Act
            var result = sut.Execute(seats);

            // Assert
            result.Should().Be(expectedOccupiedSeats);
        }
    }
}
