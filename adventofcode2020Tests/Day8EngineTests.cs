using adventofcode2020.Puzzles.Day1;
using adventofcode2020.Puzzles.Day8;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace adventofcode2020Tests
{
    public class Day8EngineTests
    {
        [Theory]
        [InlineData("nop", 0, "nop +0")]
        [InlineData("acc", 1, "acc +1")]
        [InlineData("jmp", -3, "jmp -3 ")]
        [InlineData("acc", -99, "acc -99")]
        public void InstructionParsesInputCorrectly(string expectedOperator, int expectedOperand, string ruleAsString)
        {
            // Arrange / Act
            var sut = new Instruction(ruleAsString);

            // Assert
            sut.Operation.Should().Be(expectedOperator);
            sut.OperationParam.Should().Be(expectedOperand);
        }

        [Theory]
        [InlineData(0, "acc +0")]
        [InlineData(4, "acc +4")]
        [InlineData(99, "acc +99")]
        [InlineData(-99, "acc -99")]
        public void AccOperationExecutesCorrectly(int expectedAccValue, params string[] instructionsAsString)
        {
            // Arrange
            var sut = new CPU();
            var program = new Program(instructionsAsString);

            // Act
            var result = sut.Execute(program);

            // Assert
            result.Accumulator.Should().Be(expectedAccValue);
        }


        [Theory]
        [InlineData("nop +0")]
        [InlineData("nop +100")]
        [InlineData("nop -100")]
        public void NopOperationHasNoImpact(params string[] instructionsAsString)
        {
            // Arrange
            var sut = new CPU();
            var program = new Program(instructionsAsString);

            // Act
            var result = sut.Execute(program);

            // Assert
            result.Accumulator.Should().Be(0);
            result.InstructionPointer.Should().Be(1);
        }

        [Theory]
        [InlineData(0, 0, "nop +0", "jmp -1")]
        [InlineData(1, 2, "nop +0", "acc +2", "jmp -1")]
        public void ExecuteDetectsPreviouslyExecutedInstruction(int finalIPValue, int finalAccValue, params string[] instructionsAsString)
        {
            // Arrange
            var sut = new CPU();
            var program = new Program(instructionsAsString);

            // Act
            var result = sut.Execute(program);

            // Assert
            result.InstructionPointer.Should().Be(finalIPValue);
            result.Accumulator.Should().Be(finalAccValue);
        }

        [Theory]
        [InlineData(2, 0, "nop +0", "nop +0")]
        [InlineData(2, 2, "nop +0", "acc +2")]
        [InlineData(3, 7, "nop +0", "acc +2", "acc +5")]
        public void ExecuteStopsAfterLastInstruction(int finalIPValue, int finalAccValue, params string[] instructionsAsString)
        {
            // Arrange
            var sut = new CPU();
            var program = new Program(instructionsAsString);

            // Act
            var result = sut.Execute(program);

            // Assert
            result.InstructionPointer.Should().Be(finalIPValue);
            result.Accumulator.Should().Be(finalAccValue);
        }

        [Theory]
        [InlineData(1, 5, "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "acc +6")]
        public void TestCaseExecutesCorrectly(int finalIPValue, int finalAccValue, params string[] instructionsAsString)
        {
            // Arrange
            var sut = new CPU();
            var program = new Program(instructionsAsString);

            // Act
            var result = sut.Execute(program);

            // Assert
            result.InstructionPointer.Should().Be(finalIPValue);
            result.Accumulator.Should().Be(finalAccValue);
        }

        [Theory]
        [InlineData("nop", "jmp", 1, 0, "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "acc +6")]
        [InlineData("nop", "jmp", 2, 5, "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "nop -99", "acc +1", "jmp -4", "acc +6")]
        [InlineData("jmp", "nop", 4, 8, "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "jmp +6")]
        public void MutatorGeneratesCorrectMutation(string fromOp, string toOp, int occurence, int updatedIndex, params string[] instructionsAsString)
        {
            // Arrange
            var program = new Program(instructionsAsString);

            // Act
            var result = OpSwapMutator.Mutate(program, fromOp, toOp, occurence);

            // Assert
            result.ProgrammInstructions[updatedIndex].Operation.Should().Be(toOp);
        }

        [Theory]
        [InlineData("nop", "jmp", 10, "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "acc +6")]
        public void MutatorGeneratesNullWhenIndexOutOfRange(string fromOp, string toOp, int occurence, params string[] instructionsAsString)
        {
            // Arrange
            var program = new Program(instructionsAsString);

            // Act
            var result = OpSwapMutator.Mutate(program, fromOp, toOp, occurence);

            // Assert
            result.Should().Be(null);
        }

        [Theory]
        [InlineData(8, "nop +0", "acc +1", "jmp +4", "acc +3", "jmp -3", "acc -99", "acc +1", "jmp -4", "acc +6")]
        public void MutatedProgramFindsResult(int expectedAccVal, params string[] instructionsAsString)
        {
            // Arrange
            var day8Engine = new Day8Engine();

            // Act
            var result = day8Engine.Execute2(instructionsAsString);

            // Assert
            result.Should().Be(expectedAccVal);
        }
    }
}
