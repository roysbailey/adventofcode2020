using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day6;
using FluentAssertions;
using System;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day6EngineTests
    {
        [Theory]
        [InlineData(4, "abc", "", "a")]
        [InlineData(11, "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b")]
        public void CorrectlyCalculatesSumOfQuestionFromAnyParticipant(int expected, params string[] customsAnswers)
        {
            // Arrange
            var sut = new Day6Engine();

            // Act
            var result = sut.Execute(customsAnswers);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(6, "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b")]
        [InlineData(3, "abc", "a", "", "ab", "bc", "cd", "", "ab", "cde", "", "ab", "a", "ab", "ab", "", "b")]
        public void CorrectlyCalculatesSumOfQuestionFromALLParticipants(int expected, params string[] customsAnswers)
        {
            // Arrange
            var sut = new Day6Engine();

            // Act
            var result = sut.Execute2(customsAnswers);

            // Assert
            result.Should().Be(expected);
        }

    }
}
