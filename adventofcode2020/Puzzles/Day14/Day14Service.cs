using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day14
{
    public class Day14Service : IDay14Service
    {
        IFileDataReader _fileReader = null;
        IDay14Engine _engine = null;

        public Day14Service(IFileDataReader fileReader, IDay14Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day14\\initprogram.txt")
        {
            var arrivalNotes = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(arrivalNotes.ToList());
            Console.WriteLine($"   Part 1 - Sum of memory addresses: {result}");
        }
    }
}
