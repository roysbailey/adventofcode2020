using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day11
{
    public class Day11Service : IDay11Service
    {
        IFileDataReader _fileReader = null;
        IDay11Engine _engine = null;

        public Day11Service(IFileDataReader fileReader, IDay11Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day11\\seatingplan.txt")
        {
            var seats = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(seats);
            Console.WriteLine($"   Part 1 - Occupied seats: {result}");

            //Console.WriteLine("Staring part 2");
            //var result2 = _engine.Execute2(adapters);
            //Console.WriteLine($"   Part 2 - Adapter combinations: {result2}");
        }
    }
}
