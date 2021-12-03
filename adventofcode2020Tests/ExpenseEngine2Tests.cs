using adventofcode2020.Puzzles.Day1;
using FluentAssertions;
using System;
using Xunit;

namespace adventofcode2020Tests
{
    public class ExpenseEngine2Tests
    {
        [Theory]
        [InlineData(241861950, 1721, 979, 366, 299, 675, 1456)]
        [InlineData(2018, 2018, 1500, 1, 1, 675, 520)]
        public void GivenValidInputs_CalculatesCorrectOutcomes(int expected, params int[] expenses)
        {
            // Arrange
            var sut = new ExpensesEngine2();

            // Act
            var result = sut.Execute(2020, expenses);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(500, 1721, 979, 366, 299, 675, 1456)]
        [InlineData(500, 3222, 1500, 500, 283, 675, 520)]
        [InlineData(500, 3222, 1500, 500, 283, 333, 2020)]
        [InlineData(500, 3222, 1500, 500, 283, 1, 2019)]
        public void GivenInvalidInputs_ThrowsAnException(params int[] expenses)
        {
            // Arrange
            var sut = new ExpensesEngine2();

            // Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.Execute(500, expenses));
        }

        [Theory]
        [InlineData(2000)]
        [InlineData(300,20)]
        public void LessThanThreeExpenses_ThrowsAnException(params int[] expenses)
        {
            // Arrange
            var sut = new ExpensesEngine2();

            // Act and Assert
            Assert.Throws<ArgumentException>(() => sut.Execute(2020, expenses));
        }
    }
}
