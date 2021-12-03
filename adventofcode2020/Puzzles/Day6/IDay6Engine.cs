using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day6
{
    public interface IDay6Engine
    {
        public int Execute(IEnumerable<string> customsAnswers);
        public int Execute2(IEnumerable<string> customsAnswers);
    }
}
