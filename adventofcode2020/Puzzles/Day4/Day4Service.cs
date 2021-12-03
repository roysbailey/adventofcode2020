using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day4
{
    public class Day4Service : IDay4Service
    {
        IFileDataReader _fileReader = null;
        IDay4Engine _engine = null;

        public Day4Service(IFileDataReader fileReader, IDay4Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day4\\passports.txt")
        {
            var passportData = _fileReader.ReadData<string>(fileName);
            var results = _engine.Execute(passportData);

            Console.WriteLine($"Total passports: {results.totalPassportsValidated}");
            Console.WriteLine($"   Total passports with mandatory: {results.countMandatory}, of which also had optional {results.countMandatoryAndOptional}");
            Console.WriteLine($"   Total passports valid: {results.countValid}, total invalid {results.countInValid}");
        }
    }
}
