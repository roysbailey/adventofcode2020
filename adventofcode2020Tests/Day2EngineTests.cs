using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day2;
using FluentAssertions;
using System;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day2EngineTests
    {
        [Theory]
        [InlineData("1-3 a: abcde", "2-9 c: ccccccccc")]
        [InlineData("10-13 z: zzabzzzzzzdezz", "2-4 x: cxcccccxc")]
        [InlineData("1-1 q: zzabzzzqzzzdezz", "2-2 p: pxcccccxp")]
        public void Policy1_GivenValidPassword_IndicatesValidity(params string[] passordInfoList)
        {
            // Arrange
            var sut = new Day2Engine();
            int result, ignored;

            // Act
            sut.Execute(passordInfoList, out result, out ignored);

            // Assert
            result.Should().Be(passordInfoList.Length);
        }

        [Theory]
        [InlineData("1-3 b: cdefg")]
        [InlineData("1-1 b: cdefg")]
        [InlineData("2-3 b: cdbfg")]
        public void Policy1_GivenInValidPassword_IndicatesNotValid(params string[] passordInfoList)
        {
            // Arrange
            var sut = new Day2Engine();
            int result, ignored;

            // Act
            sut.Execute(passordInfoList, out result, out ignored);

            // Assert
            result.Should().Be(0);
        }
        [Theory]
        [InlineData("1-3 a: abcde")]
        [InlineData("1-3 c: abcde")]
        public void Policy2_GivenValidPassword_IndicatesValidity(params string[] passordInfoList)
        {
            // Arrange
            var sut = new Day2Engine();
            int result, ignored;

            // Act
            sut.Execute(passordInfoList, out ignored, out result);

            // Assert
            result.Should().Be(passordInfoList.Length);
        }

        [Theory]
        [InlineData("1-3 b: cdefg")]
        [InlineData("2-9 c: ccccccccc")]
        [InlineData("1-3 b: cdefbbb")]
        public void Policy2_GivenInValidPassword_IndicatesNotValid(params string[] passordInfoList)
        {
            // Arrange
            var sut = new Day2Engine();
            int result, ignored;

            // Act
            sut.Execute(passordInfoList, out ignored, out result);

            // Assert
            result.Should().Be(0);
        }
    }
}
