using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day8
{
    public interface IDay8Engine
    {
        public int Execute(IEnumerable<string> instructionsAsText);
        public int Execute2(IEnumerable<string> instructionsAsText);
    }
}
