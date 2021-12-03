using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day1
{
    public interface IExpensesService
    {
        public void Execute(int target = 2020, string fileName = ".\\Puzzles\\Day1\\Expenses.txt");
    }
}
