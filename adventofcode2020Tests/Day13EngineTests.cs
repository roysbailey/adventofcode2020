using adventofcode2020.Puzzles.Day13;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static adventofcode2020.Puzzles.Day13.Day13Engine;

namespace adventofcode2020Tests
{
    public class Day13EngineTests
    {

        [Theory]
        [InlineData(295, "939", "7,13,x,x,59,x,31,19")]

        public void CanFindNextDepartureForArrivalTime(int expectedBusCode, params string[] arrivalNotes)
        {
            // Arrange 
            var sut = new Day13Engine();

            // Act
            var result = sut.Execute(arrivalNotes);

            // Assert
            result.Should().Be(expectedBusCode);
        }
    }
}
