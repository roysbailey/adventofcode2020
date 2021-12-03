using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day11
{
    public interface IDay11Engine
    {
        public int Execute(IEnumerable<string> seats);
        public int Execute2(IEnumerable<string> seats);
    }
}
