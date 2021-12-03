using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day9;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day9EngineTests
    {
        [Theory]
        [InlineData(127L, 5, 35L, 20L, 15L, 25L, 47L, 40L, 62L, 55L, 65L, 95L, 102L, 117L, 150L, 182L, 127L, 219L, 299L, 277L, 309L, 576L)]
        public void ValidatorDetectesFailureInTestCase(long expectedStopNumber, int preambleLength, params long[] xmasCodeList)
        {
            // Arrange 
            var sut = new XmasCodeValidator();
            long stopNumber = -1;

            // Act
            var result = sut.IsValid(preambleLength, xmasCodeList, out stopNumber);

            // Assert
            result.Should().BeFalse();
            stopNumber.Should().Be(expectedStopNumber);
        }

        [Theory]
        [InlineData(100L, 2, 1L, 3L, 4L, 100L)]
        [InlineData(99L, 3, 1L, 2L, 3L, 4L, 99L)]
        [InlineData(3L, 3, 1L, 2L, 3L, 4L, 3L)]
        public void ValidatorDetectesFailureInDifferentPreambleLengths(long expectedStopNumber, int preambleLength, params long[] xmasCodeList)
        {
            // Arrange 
            var sut = new XmasCodeValidator();
            long stopNumber = -1;

            // Act
            var result = sut.IsValid(preambleLength, xmasCodeList, out stopNumber);

            // Assert
            result.Should().BeFalse();
            stopNumber.Should().Be(expectedStopNumber);
        }

        [Theory]
        [InlineData(3, 1L, 2L, 3L, 4L)]
        [InlineData(2, 1L, 2L, 3L, 5L)]
        public void ValidatorDetectesSuccessInDifferentPreambleLengths(int preambleLength, params long[] xmasCodeList)
        {
            // Arrange 
            var sut = new XmasCodeValidator();
            long ignored = -1;

            // Act
            var result = sut.IsValid(preambleLength, xmasCodeList, out ignored);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(62L, 127L, 35L, 20L, 15L, 25L, 47L, 40L, 62L, 55L, 65L, 95L, 102L, 117L, 150L, 182L, 127L, 219L, 299L, 277L, 309L, 576L)]
        public void ValidatorFindSequenceForInvalidCode(long expectedEncryptionWeakness, long invalidCode, params long[] xmasCodeList)
        {
            // Arrange 
            var sut = new XmasCodeValidator();
            long encryptionWeakness = -1;

            // Act
            var result = sut.FindEncryptionWeaknessForInvalidCode(invalidCode, xmasCodeList.OfType<long>().ToList(), out encryptionWeakness);

            // Assert
            result.Should().BeTrue();
            encryptionWeakness.Should().Be(expectedEncryptionWeakness);
        }
    }
}
