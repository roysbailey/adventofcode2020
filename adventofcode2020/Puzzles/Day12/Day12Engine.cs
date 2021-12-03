using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing;

namespace adventofcode2020.Puzzles.Day12
{
    public class Day12Engine : IDay12Engine
    {
        public Position Execute(IEnumerable<string> directions)
        {
            var ferry = new Ferry();
            var result = ferry.Sail(directions);

            return result;
        }

        public class Ferry
        {
            public Position Sail(IEnumerable<string> directionsAsStrings)
            {
                var directions = directionsAsStrings.Select(s => new DirectionInstruction(s));
                var pos = new Position();

                foreach (var direction in directions)
                    direction.Move(pos);

                return pos;
            }
        }

        public class DirectionInstruction
        {
            public string Command { get; private set; } = string.Empty;
            public int Value { get; private set; } = 0;

            public DirectionInstruction(string directionAsString)
            {
                Command = directionAsString[0].ToString();
                Value = int.Parse(directionAsString.Substring(1, directionAsString.Length-1));
            }

            public void Move(Position pos)
            {
                var direction = Command == "F" ? pos.CurrentHeading : Command;

                if (direction == "N")
                    pos.SouthNorth += Value;
                else if (direction == "S")
                    pos.SouthNorth -= Value;
                else if (direction == "E")
                    pos.WestEast += Value;
                else if (direction == "W")
                    pos.WestEast-= Value;
                else
                    pos.SetNewHeading(Command, Value);
            }
        }

        public class Position
        {
            private int _heading = 1;   // 0=N, 1=E, 2=S, 3=W
            public string CurrentHeading { 
                get
                {
                    if (_heading == 0) return "N";
                    if (_heading == 1) return "E";
                    if (_heading == 2) return "S";
                    return "W";
                }
            }

            public int WestEast { get; set; } = 0;
            public int SouthNorth { get; set; } = 0;

            public void SetNewHeading(string turnDirection, int degress)
            {
                var turns = degress / 90;
                if (turnDirection == "L")
                    turns *= -1;

                _heading += turns;

                if (_heading > 3) _heading = _heading - 4;
                if (_heading < 0) _heading = 4 + _heading;
            }

            public int ManhattanDistance 
            { 
                get
                {
                    var sn = SouthNorth < 0 ? SouthNorth * - 1 : SouthNorth ;
                    var we = WestEast < 0 ? WestEast * - 1 : WestEast;

                    return sn + we;
                }
            }

            public override string ToString()
            {
                return $"SN={SouthNorth};WE={WestEast}";
            }
        }

    }
}
