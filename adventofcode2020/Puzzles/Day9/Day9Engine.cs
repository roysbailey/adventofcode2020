using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace adventofcode2020.Puzzles.Day9
{
    public class Day9Engine : IDay9Engine
    {
        public long Execute(int preambleLength, IEnumerable<long> xmasData)
        {
            var validator = new XmasCodeValidator();
            long stopNumber = -1;

            validator.IsValid(preambleLength, xmasData.ToList(), out stopNumber);

            return stopNumber;
        }

        public long Execute2(long xmasInvalidCodeValue, IEnumerable<long> xmasData)
        {
            var sut = new XmasCodeValidator();
            long encryptionWeakness = -1;

            sut.FindEncryptionWeaknessForInvalidCode(xmasInvalidCodeValue, xmasData.OfType<long>().ToList(), out encryptionWeakness);

            return encryptionWeakness;
        }
    }

    public class XmasCodeValidator
    {
        public bool IsValid(int preambleLength, IList<long> xmasData, out long failedValue)
        {
            failedValue = -1;
            for (int xmasDataOffset = preambleLength; xmasDataOffset < xmasData.Count(); xmasDataOffset++)
            {
                long xmasCodeValue = xmasData[xmasDataOffset];
                var preambleValues = xmasData.Skip(xmasDataOffset - preambleLength).Take(preambleLength);
                if (!IsXmasCodeValueValid(xmasCodeValue, preambleValues))
                {
                    failedValue = xmasCodeValue;
                    return false;
                }
            }

            return true;
        }

        public bool FindEncryptionWeaknessForInvalidCode(long xmasInvalidCodeValue, List<long> xmasData, out long encryptionWeakness)
        {
            encryptionWeakness = -1;
            var match = false;
            for (int i = 0; i < xmasData.Count() - 1 && !match; i++)
            {
                var sequenceLength = 2;
                var sequenceValue = 0L;
                do
                {
                    var currentSequence = xmasData.Skip(i).Take(sequenceLength);
                    sequenceValue = currentSequence.Sum();
                    match = sequenceValue == xmasInvalidCodeValue;
                    if (match)
                        encryptionWeakness = currentSequence.Min() + currentSequence.Max();
                    sequenceLength++;

                } while (!match && sequenceValue < xmasInvalidCodeValue);
            }

            return match;
        }

        private bool IsXmasCodeValueValid(long xmasCodeValue, IEnumerable<long> preambleValues)
        {
            var preambleToCheck = preambleValues.Distinct().ToList();
            if (preambleToCheck.Count != preambleValues.Count())
                Debugger.Break();
            for (int i = 0; i < preambleValues.Count()-1; i++)
            {
                for (int k = i+1; k < preambleValues.Count(); k++)
                {
                    if (xmasCodeValue == preambleToCheck[i] + preambleToCheck[k])
                        return true;
                }
            }

            return false;
        }
    }
}
