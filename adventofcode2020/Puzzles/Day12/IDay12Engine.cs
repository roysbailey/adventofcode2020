using System;
using System.Collections.Generic;
using System.Text;
using static adventofcode2020.Puzzles.Day12.Day12Engine;

namespace adventofcode2020.Puzzles.Day12
{
    public interface IDay12Engine
    {
        public Position Execute(IEnumerable<string> seats);
    }
}
