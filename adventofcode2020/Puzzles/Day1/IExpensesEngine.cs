using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day1
{
    public interface IExpensesEngine
    {
        public int Execute(int target, int[] expenses);
    }
}
