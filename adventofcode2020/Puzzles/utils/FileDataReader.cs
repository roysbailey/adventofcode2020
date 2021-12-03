using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace adventofcode2020.Puzzles.Day1
{
    public class FileDataReader : IFileDataReader
    {
        public IEnumerable<T> ReadData<T>(string fileName)
        {
            return File.ReadAllLines(fileName).Select(s => (T)Convert.ChangeType(s, typeof(T)));
        }
    }
}
