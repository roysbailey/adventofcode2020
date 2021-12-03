using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day2
{
    public class Day2Service : IDay2Service
    {
        IFileDataReader _fileReader = null;
        IDay2Engine _engine = null;

        public Day2Service(IFileDataReader fileReader, IDay2Engine engine)
        {
            _fileReader = fileReader;
            _engine = engine;
        }

        public void Execute(string fileName = ".\\Puzzles\\Day2\\Passwords.txt")
        {
            var passwordInfoList = _fileReader.ReadData<string>(fileName);
            int validPasswordCountEx1, validPasswordCountEx2;
            _engine.Execute(passwordInfoList, out validPasswordCountEx1, out validPasswordCountEx2);
            Console.WriteLine($"There were {validPasswordCountEx1} valid passwords for policy 1 and {validPasswordCountEx2}  for policy 2.");
        }
    }
}
