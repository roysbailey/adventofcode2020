using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode2020.Puzzles.Day8
{
    public class Day8Engine : IDay8Engine
    {
        static public Dictionary<string, IEnumerable<Instruction>> _bagRuleList = new Dictionary<string, IEnumerable<Instruction>>();

        public int Execute(IEnumerable<string> instructionsAsString)
        {
            var sut = new CPU();
            var program = new Program(instructionsAsString);
            var result = sut.Execute(program);

            return result.Accumulator;
        }

        public int Execute2(IEnumerable<string> instructionsAsString)
        {
            var sut = new CPU();
            var program = new Program(instructionsAsString);

            int result = ExecuteMutations("nop", "jmp", program);
            if (result == 0)
                result = ExecuteMutations("jmp", "nop", program);

            return result;
        }

        private int ExecuteMutations(string fromOp, string toOp, Program program)
        {
            var cpu = new CPU();
            var mutationAttempts = program.ProgrammInstructions.Count(i => i.Operation == fromOp);
            var accumulatorVal = 0;

            for (int i = 0; i < mutationAttempts && accumulatorVal == 0; i++)
            {
                var mutant = OpSwapMutator.Mutate(program, fromOp, toOp, i+1);
                var result = cpu.Execute(mutant);
                if (result.InstructionPointer == program.ProgrammInstructions.Count())
                    accumulatorVal = result.Accumulator;
            }

            return accumulatorVal;
        }
    }

    public static class OpSwapMutator
    {
        static public Program Mutate(Program prog, string swapFrom, string swapTo, int replaceOccurence)
        {
            Program mutant = prog.Duplicate();
            var swapCandidates = mutant.ProgrammInstructions.Where(pi => pi.Operation == swapFrom);
            if (replaceOccurence > swapCandidates.Count())
                return null;

            var instructionToSwap = swapCandidates.Skip(replaceOccurence-1).First();
            instructionToSwap.Operation = swapTo;

            return mutant;
        }
    }

    public class Instruction
    {
        public string Operation { get; set; } = string.Empty;
        public int OperationParam { get; private set; } = 0;

        public Instruction(string instructionAsString)
        {
            var instructionElements = instructionAsString.Split(" ");
            Operation = instructionElements[0].Trim();
            OperationParam = int.Parse(instructionElements[1]);
        }

        public Instruction(string operation, int operatiomParam)
        {
            Operation = operation;
            OperationParam = operatiomParam;
        }
    }

    public class Program
    {
        public List<Instruction> ProgrammInstructions { get; private set; } = new List<Instruction>();

        public Program()
        {

        }

        public Program(IEnumerable<string> instructionsAsString)
        {
            foreach (var instructionAsString in instructionsAsString)
            {
                var accInstruction = new Instruction(instructionAsString);
                ProgrammInstructions.Add(accInstruction);
            }
        }

        internal Program Duplicate()
        {
            var duplicate = new Program
            {
                ProgrammInstructions = this.ProgrammInstructions.ConvertAll(i => new Instruction(i.Operation, i.OperationParam))
            };

            return duplicate;
        }
    }

    public class CPU
    {
        public Dictionary<string, Action<CPUState, Instruction>> OperationSet { get; private set; } = new Dictionary<string, Action<CPUState, Instruction>>();

        public CPU()
        {
            OperationSet.Add("nop", (st, i) => st.InstructionPointer++);
            OperationSet.Add("acc", (st, i) => { st.Accumulator += i.OperationParam; st.InstructionPointer++; });
            OperationSet.Add("jmp", (st, i) => st.InstructionPointer += i.OperationParam);
        }

        public CPUState Execute(Program program)
        {
            List<int> instructionExecutionHistory = new List<int>();
            CPUState cpuState = new CPUState();
            while (!instructionExecutionHistory.Any(ei => ei == cpuState.InstructionPointer) && cpuState.InstructionPointer < program.ProgrammInstructions.Count)
            {
                instructionExecutionHistory.Add(cpuState.InstructionPointer);
                var currentInstruction = program.ProgrammInstructions[cpuState.InstructionPointer];
                OperationSet[currentInstruction.Operation](cpuState, currentInstruction);
            }
            return cpuState;
        }
    }

    public class CPUState
    {
        public int InstructionPointer { get; set; }
        public int Accumulator { get; set; }
    }
}
