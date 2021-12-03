using System;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day1
{
    public interface IFileDataReader
    {
        IEnumerable<T> ReadData<T>(string fileName);
    }
}
