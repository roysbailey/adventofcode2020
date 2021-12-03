using adventofcode2020.Puzzles.Day16;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static adventofcode2020.Puzzles.Day16.Day16Engine;

namespace adventofcode2020Tests
{
    public class Day16EngineTests
    {

        [Theory]
        [InlineData(71, "class: 1-3 or 5-7", "row: 6-11 or 33-44", "seat: 13-40 or 45-50", "", "your ticket:", "7,1,14", "", "nearby tickets:", "7,3,47", "40,4,50", "55,2,20", "38,6,12")]
        public void CanIdenitfyScanningErrorRate(int expectedScanningError, params string[] ticketNotes )
        {
            // Arrange 
            var sut = new Day16Engine();

            // Act
            var result = sut.Execute(ticketNotes);

            // Assert
            result.Should().Be(expectedScanningError);
        }
    }
}
