using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace adventofcode2020.Puzzles.Day10
{
    public class Day10Engine : IDay10Engine
    {
        private Dictionary<int, long> _branches = new Dictionary<int, long>();

        public int Execute(IEnumerable<int> joltAdaptersData)
        {
            var joltAdapters = joltAdaptersData.OrderBy(n => n).ToArray();
            var v = joltAdapters.Zip(joltAdapters.Skip(1), (a, b) => b - a);
            var voltSetCode = (v.Where(x => x == 1).Count() + 1) * (v.Where(x => x == 3).Count() + 1);
            return voltSetCode;
        }


        public long Execute2(IEnumerable<int> joltAdaptersData)
        {
            var joltAdapters = joltAdaptersData.OrderBy(n => n).ToArray();

            _branches[joltAdapters.Max()] = 0;
            long possiblePaths = 0;
            int i = 0;
            do
            {
                possiblePaths += 1 + branchesFrom(joltAdapters, i);
                ++i;
            } while (joltAdapters[i] <= 3);

            return possiblePaths;
        }

        private long branchesFrom(int[] adapters, int index)
        {
            int a = adapters[index];

            if (_branches.ContainsKey(a))
                return _branches[a];

            long count = 0;
            int x = index + 1;
            while (x < adapters.Length && adapters[x] - a <= 3)
            {
                int b = adapters[x];
                count += 1 + (_branches.ContainsKey(b) ? _branches[b] : branchesFrom(adapters, x));
                ++x;
            }

            _branches[a] = count - 1;

            return _branches[a];
        }
    }
}
