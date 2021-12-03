using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;

namespace adventofcode2020.Puzzles.Day11
{
    public class Day11Engine : IDay11Engine
    {
        public int Execute(IEnumerable<string> seats)
        {
            IEnumerable<string> seatsNext = seats;

            do
            {
                seats = seatsNext;
                seatsNext = ApplyRules(seats.ToList());
            } while (string.Concat(seats) != string.Concat(seatsNext));

            return string.Concat(seats).Where(s => s == '#').Count();
        }

        public IEnumerable<string> ApplyRules(List<string> seats)
        {
            var seatsNext = new List<string>();
            for (int r = 0; r < seats.Count(); r++)
            {
                var row = string.Empty;
                for (int c = 0; c < seats[r].Count(); c++)
                {
                    var adjascentSeats = GetAdjascentSeats(r, c, seats);
                    row += applyRules(seats[r][c], adjascentSeats);
                }
                seatsNext.Add(row);
            }

            return seatsNext;
        }

        private char applyRules(char seat, string adjSeats)
        {
            if (seat == 'L' && !adjSeats.Contains("#"))
                return '#';
            else if (seat == '#' && adjSeats.Where(s => s == '#').Count() >= 4)
                return 'L';

            return seat;
        }

        public int Execute2(IEnumerable<string> seats)
        {
            return 0;
        }

        public string GetAdjascentSeats(int row, int col, List<string> seats)
        {
            string adjSeats = string.Empty;
            var rowStart = row - 1; ;
            var rowTake = 3;
            var colStart = col - 1;
            var colTake = 3;
            if (row == 0)
            {
                rowStart = row;
                rowTake = 2;
            }
            else if (row == seats.Count()-1)
            {
                rowStart = seats.Count() - 2;
                rowTake = 2;
            }
            if (col == 0)
            {
                colStart = col;
                colTake = 2;
            }
            else if (col == seats[0].Length-1)
            {
                colStart = seats[0].Length - 2;
                colTake = 2;
            }

            for (int r = rowStart; r < rowStart+rowTake; r++)
            {
                for (int c = colStart; c < colStart+colTake; c++)
                {
                    if (c != col || r != row)
                        adjSeats = adjSeats + seats[r][c];
                }
            }

            return adjSeats;
        }

    }
}
