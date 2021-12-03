using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day16
{
    public class Day16Service : IDay16Service
    {
        IFileDataReader _fileReader = null;
        IDay16Engine _engine = null;

        public Day16Service(IFileDataReader fileReader, IDay16Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day16\\ticketNotes.txt")
        {
            var ticketNotes = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(ticketNotes);
            Console.WriteLine($"   Part 1 - Scanning error rate: {result}");
        }
    }
}
