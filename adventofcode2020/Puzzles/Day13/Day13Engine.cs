using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;

namespace adventofcode2020.Puzzles.Day13
{
    public class Day13Engine : IDay13Engine
    {
        public long Execute(string[] arrivalNotes)
        {
            var arrivalTime = long.Parse(arrivalNotes[0]);
            var nextBus = string.Concat(arrivalNotes[1].Where(c => c != 'x'))
                .Split(",").Where(b => !string.IsNullOrEmpty(b)).Select(b => int.Parse(b))
                .Select(b =>
                   {
                       int dt = (int)Math.Ceiling((double)arrivalTime / b) * b;
                       return new { BusNo = b, DepartureTime = dt };
                   })
                .OrderBy(b => b.DepartureTime)
                .First();

            return (nextBus.DepartureTime - arrivalTime) * nextBus.BusNo;
        }
    }
}
