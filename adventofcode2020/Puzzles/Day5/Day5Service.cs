using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day5
{
    public class Day5Service : IDay5Service
    {
        IFileDataReader _fileReader = null;
        IDay5Engine _engine = null;

        public Day5Service(IFileDataReader fileReader, IDay5Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day5\\boardingcards.txt")
        {
            var boardCardBarCodes = _fileReader.ReadData<string>(fileName);

            var result = _engine.Execute(boardCardBarCodes);
            Console.WriteLine($"   Part 1 - Max Seat ID is: {result}");

            var result2 = _engine.Execute2(boardCardBarCodes);
            Console.WriteLine($"   Part 2 - Your seat is: {result2}");
        }
    }
}
