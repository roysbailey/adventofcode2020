using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day15
{
    public class Day15Service : IDay15Service
    {
        IFileDataReader _fileReader = null;
        IDay15Engine _engine = null;

        public Day15Service(IFileDataReader fileReader, IDay15Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day15\\startingNumbers.txt")
        {
            var startingNumbersAsString = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(2020, startingNumbersAsString.ToArray()[0]);
            Console.WriteLine($"   Part 1 - Last number: {result}");
        }
    }
}
