using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day3
{
    public class Day3Engine : IDay3Engine
    {
        public int Execute(IEnumerable<string> skiSlopePattern, int incrementX = 3, int incrementY = 1)
        {
            int treeCount=0, rowCount=0;
            var patternWidth = skiSlopePattern.First().Length;
            var currentSkiPosX = 0;
            foreach (var slopeRow in skiSlopePattern)
            {
                if (rowCount % incrementY == 0)
                {
                    treeCount = slopeRow[currentSkiPosX] == '#' ? treeCount + 1 : treeCount;
                    currentSkiPosX += incrementX;
                    currentSkiPosX = currentSkiPosX >= patternWidth ? currentSkiPosX - patternWidth : currentSkiPosX;
                }
                rowCount++;
            }

            return treeCount;
        }

    }
}
