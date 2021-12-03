using adventofcode2020.Puzzles.Day14;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static adventofcode2020.Puzzles.Day14.Day14Engine;

namespace adventofcode2020Tests
{
    public class Day14EngineTests
    {

        [Theory]
        [InlineData(165, "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X", "mem[8] = 11", "mem[7] = 101", "mem[8] = 0")]
        [InlineData(1, "mask = XXXXXXXXX0", "mem[8] = 1", "mask = XXXXXXXXX1", "mem[2] = 0")]
        [InlineData(6, "mask = XXXXXXXXX0", "mem[0] = 3", "mask = XXXXXXXXX1", "mem[1] = 0", "mem[2] = 2")]
        [InlineData(1, "mask = XXXXXXXXX0", "mem[0] = 3", "mask = XXXXXXXXX1", "mem[0] = 2", "mem[0] = 0")]
        public void SumsMemoryCorrectly(int expectedSumMemory, params string[] initProgram)
        {
            // Arrange 
            var sut = new Day14Engine();

            // Act
            var result = sut.Execute(initProgram.ToList());

            // Assert
            result.Should().Be(expectedSumMemory);
        }

        [Theory]
        [InlineData(1, 1, "XXXXXXXXXX")]
        [InlineData(1, 0, "XXXXXXXXX1")]
        [InlineData(3, 2, "XXXXXXXXX1")]
        [InlineData(9, 1, "XXXXXX1XXX")]
        [InlineData(0, 1, "XXXXXXXXX0")]
        [InlineData(2, 3, "XXXXXXXXX0")]
        [InlineData(2, 0, "XXXXXXXX10")]
        [InlineData(73, 11, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        [InlineData(101, 101, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        [InlineData(64, 0, "XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X")]
        [InlineData(151523437, 97, "X1001000X10X00X01000X01X01101")]
        [InlineData(151523437, 127, "X1001000X10X00X01000X01X01101")]
        [InlineData(11962683501, 97, "0X10110X1001000X10X00X01000X01X01101")]
        
        public void AppliesMaskCorrectly(long expectedValueAfterMask, long valueBeforeMask, string mask)
        {
            // Arrange 
            var sut = new MemoryAssignment(0, valueBeforeMask, mask);

            // Act
            var result = sut.Value;

            // Assert
            result.Should().Be(expectedValueAfterMask);
        }

    }
}
