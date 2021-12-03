using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day8
{
    public class Day8Service : IDay8Service
    {
        IFileDataReader _fileReader = null;
        IDay8Engine _engine = null;

        public Day8Service(IFileDataReader fileReader, IDay8Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day8\\instructions.txt")
        {
            var instructionsAsText = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(instructionsAsText);
            Console.WriteLine($"   Part 1 - Accumulator value: {result}");

            Console.WriteLine("Staring part 2");
            var result2 = _engine.Execute2(instructionsAsText);
            Console.WriteLine($"   Part 2 - Accumulator value and program end: {result2}");
        }
    }
}
