using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day7
{
    public class Day7Service : IDay7Service
    {
        IFileDataReader _fileReader = null;
        IDay7Engine _engine = null;

        public Day7Service(IFileDataReader fileReader, IDay7Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day7\\bagrules.txt")
        {
            var bagRulesAsText = _fileReader.ReadData<string>(fileName);

            Console.WriteLine("Staring part 1");
            var result = _engine.Execute(bagRulesAsText, "shiny gold");
            Console.WriteLine($"   Part 1 - Total containers for shiny gold bag is: {result}");

            Console.WriteLine("Staring part 2");
            var result2 = _engine.Execute2(bagRulesAsText, "shiny gold");
            Console.WriteLine($"   Part 2 - Total bags within a shiny gold bag is: {result2}");
        }
    }
}
