using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day12
{
    public class Day12Service : IDay12Service
    {
        IFileDataReader _fileReader = null;
        IDay12Engine _engine = null;

        public Day12Service(IFileDataReader fileReader, IDay12Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day12\\directions.txt")
        {
            var directions = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(directions);
            Console.WriteLine($"   Part 1 - Manhattan Distance: {result.ManhattanDistance} - Final Pos: {result.ToString()}");
        }
    }
}
