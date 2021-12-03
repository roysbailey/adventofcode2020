using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day5
{
    public interface IDay5Engine
    {
        public int Execute(IEnumerable<string> boardingCardData);
        public int Execute2(IEnumerable<string> boardingCardData);
    }
}
