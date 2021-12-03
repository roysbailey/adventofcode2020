using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;

namespace adventofcode2020.Puzzles.Day17
{
    public class Day17Engine : IDay17Engine
    {
        public int Execute(IEnumerable<string> ticketNotes)
        {
            var validNoteSections = ticketNotes.Aggregate(new List<List<string>> { new List<string>() },
                                   (list, value) => {
                                       if (value == string.Empty) list.Add(new List<string>());
                                       else list.Last().Add(value);
                                       return list;
                                   }).ToList();
            
            var validNumberRanges = validNoteSections[0]
                .Select(r => 
                {
                    return r.Split(": ")[1].Split(" or ")
                        .Select(v => 
                        {
                            return v.Split("-")
                                .Select(v1 => int.Parse(v1));
                        });
                }).SelectMany(array => array).ToList();

            var validNumbers = validNumberRanges
                .Select(range => Enumerable.Range(range.First(), range.Last() - range.First() + 1))
                .SelectMany(array => array)
                .Distinct().ToList();

            var invalidValues = new List<int>();
            foreach (var ticket in validNoteSections[2].Skip(1))
            {
                var invalidTicketValues = ticket.Split(",")
                                            .Select(v => int.Parse(v))
                                            .Where(v => !validNumbers.Any(x => x == v)).ToList();
                invalidValues.AddRange(invalidTicketValues);
            }

            return invalidValues.Sum();
        }
    }
}
