using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day7
{
    public interface IDay7Engine
    {
        public int Execute(IEnumerable<string> customsAnswers, string bagColourToCoun);
        public int Execute2(IEnumerable<string> customsAnswers, string bagColourToCoun);
    }
}
