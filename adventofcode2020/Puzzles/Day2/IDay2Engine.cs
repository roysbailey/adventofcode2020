using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day2
{
    public interface IDay2Engine
    {
        public void Execute(IEnumerable<string> passwordInfoList, out int validPasswordCountEx1, out int validPasswordCountEx2);
    }
}
