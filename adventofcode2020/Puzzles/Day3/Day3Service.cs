using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day3
{
    public class Day3Service : IDay3Service
    {
        IFileDataReader _fileReader = null;
        IDay3Engine _engine = null;

        public Day3Service(IFileDataReader fileReader, IDay3Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day3\\SkiSlope.txt")
        {
            var skiSlopePattern = _fileReader.ReadData<string>(fileName);
            var trees_1_1 = _engine.Execute(skiSlopePattern, 1, 1);
            Console.WriteLine($"There were {trees_1_1} trees on the slope");
            var trees_3_1 = _engine.Execute(skiSlopePattern, 3, 1);
            Console.WriteLine($"There were {trees_3_1} trees on the slope");
            var trees_5_1 = _engine.Execute(skiSlopePattern, 5, 1);
            Console.WriteLine($"There were {trees_5_1} trees on the slope");
            var trees_7_1 = _engine.Execute(skiSlopePattern, 7, 1);
            Console.WriteLine($"There were {trees_7_1} trees on the slope");
            var trees_1_2 = _engine.Execute(skiSlopePattern, 1, 2);
            Console.WriteLine($"There were {trees_1_2} trees on the slope");

            Console.WriteLine($"Multiplied total trees: {trees_1_1 * trees_3_1 * trees_5_1 * trees_7_1 * trees_1_2} trees on the slope");
        }
    }
}
