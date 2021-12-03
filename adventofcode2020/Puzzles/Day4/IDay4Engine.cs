using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day4
{
    public interface IDay4Engine
    {
        public Engine4Result Execute(IEnumerable<string> passportData);
    }
}
