using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day10
{
    public interface IDay10Engine
    {
        public int Execute(IEnumerable<int> xmasDatajoltAdapters);
        public long Execute2(IEnumerable<int> joltAdapters);
    }
}
