using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day6
{
    public class Day6Service : IDay6Service
    {
        IFileDataReader _fileReader = null;
        IDay6Engine _engine = null;

        public Day6Service(IFileDataReader fileReader, IDay6Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day6\\postivecustomsqs.txt")
        {
            var customsAnswers = _fileReader.ReadData<string>(fileName);

            var result = _engine.Execute(customsAnswers);
            Console.WriteLine($"   Part 1 - Total distinct positive answers from ANY party member: {result}");

            var result2 = _engine.Execute2(customsAnswers);
            Console.WriteLine($"   Part 2 - Total distinct positive answers for ALL party members: {result2}");
        }
    }
}
