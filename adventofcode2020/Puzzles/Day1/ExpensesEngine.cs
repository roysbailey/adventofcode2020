using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day1
{
    public class ExpensesEngine : IExpensesEngine
    {
        public ExpensesEngine()
        {
        }

        public int Execute(int target, int[] expenses)
        {
            if (expenses.Length < 2)
                throw new ArgumentException("Insufficient number of expenses.  Two needed as a minimum");

            bool found = false;
            int num1 = -1;
            int num2 = -1;
            for (int i = 0; i < expenses.Length - 1 && !found; i++)
            {
                for (int k = i + 1; k < expenses.Length && !found; k++)
                {
                    if (target == expenses[i] + expenses[k])
                    {
                        found = true;
                        num1 = i;
                        num2 = k;
                    }
                }
            }

            if (!found)
                throw new ArgumentOutOfRangeException($"No 2 expenses total {target}");

            return expenses[num1] * expenses[num2];
        }
    }
}
