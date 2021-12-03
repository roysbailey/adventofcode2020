using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day9
{
    public interface IDay9Engine
    {
        public long Execute(int preambleLength, IEnumerable<long> xmasData);
        public long Execute2(long xmasInvalidCodeValue, IEnumerable<long> xmasData);
    }
}
