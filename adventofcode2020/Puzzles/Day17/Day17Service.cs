using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day17
{
    public class Day17Service : IDay17Service
    {
        IFileDataReader _fileReader = null;
        IDay17Engine _engine = null;

        public Day17Service(IFileDataReader fileReader, IDay17Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day17\\ticketNotes.txt")
        {
            var ticketNotes = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(ticketNotes);
            Console.WriteLine($"   Part 1 - Scanning error rate: {result}");
        }
    }
}
