using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day10
{
    public class Day10Service : IDay10Service
    {
        IFileDataReader _fileReader = null;
        IDay10Engine _engine = null;

        public Day10Service(IFileDataReader fileReader, IDay10Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day10\\adapters.txt")
        {
            var adapters = _fileReader.ReadData<int>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(adapters);
            Console.WriteLine($"   Part 1 - Adapters check code: {result}");

            Console.WriteLine("Staring part 2");
            var result2 = _engine.Execute2(adapters);
            Console.WriteLine($"   Part 2 - Adapter combinations: {result2}");
        }
    }
}
