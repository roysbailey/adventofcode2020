using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace adventofcode2020.Puzzles.Day1
{
    public class ExpensesService : IExpensesService
    {
        IFileDataReader _dataReader = null;
        IExpensesEngine _engine = null;

        public ExpensesService(IFileDataReader dataReader, IExpensesEngine engine)
        {
            _dataReader = dataReader;
            _engine = engine;
        }

        public void Execute(int target = 2020, string fileName = ".\\Puzzles\\Day1\\Expenses.txt")
        {
            var expenses = _dataReader.ReadData<int>(fileName);
            var result = _engine.Execute(target, expenses.Cast<int>().ToArray());

            Console.WriteLine($"Target was: {target} answer is: {result}");
        }
    }
}
