using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day3
{
    public interface IDay3Engine
    {
        public int Execute(IEnumerable<string> skiSlopePattern, int incrementX = 3, int incrementY = 1);
    }
}
