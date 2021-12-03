using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day7;
using FluentAssertions;
using System;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day7EngineTests
    {
        [Theory]
        [InlineData(5, "dotted white", "5 dotted white")]
        [InlineData(2, "wavy lavender", "2 wavy lavender")]
        public void BagRuleParsesInputCorrectly(int expectedCount, string expectedColour, string ruleAsString)
        {
            // Arrange / Act
            var sut = new BagRule(ruleAsString);

            // Assert
            sut.RequiredCount.Should().Be(expectedCount);
            sut.BagColour.Should().Be(expectedColour);
        }

        [Theory]
        [InlineData(4, "light red bags contain 1 bright white bag, 2 muted yellow bags.", "dark orange bags contain 3 bright white bags, 4 muted yellow bags.", "bright white bags contain 1 shiny gold bag.", "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.", "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.", "dark olive bags contain 3 faded blue bags, 4 dotted black bags.", "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.", "faded blue bags contain no other bags.", "dotted black bags contain no other bags.")]
        public void EngineCorrectlyCountsContainersOfTargetColour(int expectedCount, params string[] rulesAsStrings)
        {
            // Arrange / Act
            var sut = new Day7Engine();

            var result = sut.Execute(rulesAsStrings, "shiny gold");

            // Assert
            result.Should().Be(expectedCount);
        }

        [Theory]
        [InlineData(32, "light red bags contain 1 bright white bag, 2 muted yellow bags.", "dark orange bags contain 3 bright white bags, 4 muted yellow bags.", "bright white bags contain 1 shiny gold bag.", "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.", "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.", "dark olive bags contain 3 faded blue bags, 4 dotted black bags.", "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.", "faded blue bags contain no other bags.", "dotted black bags contain no other bags.")]
        [InlineData(126, "shiny gold bags contain 2 dark red bags.", "dark red bags contain 2 dark orange bags.", "dark orange bags contain 2 dark yellow bags.", "dark yellow bags contain 2 dark green bags.", "dark green bags contain 2 dark blue bags.", "dark blue bags contain 2 dark violet bags.", "dark violet bags contain no other bags.")]
        public void EngineCorrectlyCountsAllBagsInAGivenBag(int expectedCount, params string[] rulesAsStrings)
        {
            // Arrange
            var sut = new Day7Engine();

            // Act
            var result = sut.Execute2(rulesAsStrings, "shiny gold");

            // Assert
            result.Should().Be(expectedCount);
        }
    }
}
