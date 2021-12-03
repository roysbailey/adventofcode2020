using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day9
{
    public class Day9Service : IDay9Service
    {
        IFileDataReader _fileReader = null;
        IDay9Engine _engine = null;

        public Day9Service(IFileDataReader fileReader, IDay9Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day9\\XMASData.txt")
        {
            var xmasData = _fileReader.ReadData<long>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(25, xmasData);
            Console.WriteLine($"   Part 1 - first invalid value: {result}");

            Console.WriteLine("Staring part 2");
            var result2 = _engine.Execute2(result, xmasData);
            Console.WriteLine($"   Part 2 - Encryption Weakness Number: {result2}");
        }
    }
}
