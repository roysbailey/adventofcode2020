using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day1
{
    public class ExpensesEngine2 : IExpensesEngine
    {
        public ExpensesEngine2()
        {
        }

        public int Execute(int target, int[] expenses)
        {
            if (expenses.Length < 3)
                throw new ArgumentException("Insufficient number of expenses.  Two needed as a minimum");

            bool found = false;
            int num1 = -1;
            int num2 = -1;
            int num3 = -1;
            for (int i = 0; i < expenses.Length - 2 && !found; i++)
            {
                for (int k = i + 1; k < expenses.Length -1 && !found; k++)
                {
                    for (int l = k + 1; l < expenses.Length && !found; l++)
                    {
                        if (target == expenses[i] + expenses[k] + expenses[l])
                        {
                            found = true;
                            num1 = i;
                            num2 = k;
                            num3 = l;
                        }
                    }
                }
            }

            if (!found)
                throw new ArgumentOutOfRangeException($"No 3 expenses total {target}");

            return expenses[num1] * expenses[num2] * expenses[num3];
        }
    }
}
