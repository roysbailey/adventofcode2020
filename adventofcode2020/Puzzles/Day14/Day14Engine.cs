using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2020.Puzzles.Day14
{
    public class Day14Engine : IDay14Engine
    {
        public long Execute(List<string> initProgram)
        {
            var memory = new Dictionary<long, long>();
            var currentMask = string.Empty;

            foreach (var progLine in initProgram)
            {
                if (progLine.ToLower().Contains("mask"))
                    currentMask = progLine.Split(" = ")[1];
                else
                {
                    var locVal = progLine.Split(" = ");
                    var assignment = new MemoryAssignment(long.Parse(locVal[0].Substring(4, locVal[0].Length - 5)),
                        long.Parse(locVal[1]),
                        currentMask);

                    memory[assignment.Address] = assignment.Value;
                }
            }

            return memory.Values.Sum();
        }
    }

    public class MemoryAssignment
    {
        public long Address { get; private set; }
        private long _preMaskValue;
        private string _mask = string.Empty;
        public long Value
        {
            get
            {
                return ApplyMaskToValue();
            }
        }

        public MemoryAssignment(long address, long value, string mask)
        {
            Address = address;
            _preMaskValue = value;
            _mask = mask;
        }

        private long ApplyMaskToValue()
        {
            // Apply inclusive mask
            var inclusiveMaskValue = (long)_mask.Select((c, i) => new { C = c, I = _mask.Length - 1 - i })
                .Where(v => v.C == '1')
                .Sum(v => Math.Pow(2, v.I));
            var masked = _preMaskValue | inclusiveMaskValue;

            // Apply exclusive mask
            var exclusiveMaskBits = _mask.Select((c, i) => new { C = c, I = _mask.Length - 1 - i })
                .Where(v => v.C == '0');
            foreach (var exclusiveMaskBit in exclusiveMaskBits)
                masked &= ~(1L << exclusiveMaskBit.I);

            return masked;
        }
    }
}
