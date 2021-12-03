using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day13
{
    public class Day13Service : IDay13Service
    {
        IFileDataReader _fileReader = null;
        IDay13Engine _engine = null;

        public Day13Service(IFileDataReader fileReader, IDay13Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day13\\arrivalnotes.txt")
        {
            var arrivalNotes = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(arrivalNotes.ToArray());
            Console.WriteLine($"   Part 1 - Bus code: {result}");
        }
    }
}
