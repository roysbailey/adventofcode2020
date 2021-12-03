using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2020.Puzzles.Day15
{
    public class Day15Engine : IDay15Engine
    {
        public int Execute(int numTurns, string startingNumbersAsString)
        {
            var previousTurns = new Dictionary<int, int>();

            var startingNumbers = startingNumbersAsString.Split(",").Select(n => int.Parse(n)).ToArray();
            int prevNum = startingNumbers.Last();
            for (int i = 0; i < startingNumbers.Length-1; i++)
                previousTurns[startingNumbers[i]] = i;

            for (int turn = startingNumbers.Length; turn < numTurns; turn++)
            {
                var newNum = 0;
                if (!previousTurns.ContainsKey(prevNum))
                    newNum = 0;
                else
                    newNum = (turn-1) - previousTurns[prevNum];
                previousTurns[prevNum] = turn-1;
                prevNum = newNum;
            }

            return prevNum;
        }
    }
}
