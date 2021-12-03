using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode2020.Puzzles.Day4
{
    public class Day4Engine : IDay4Engine
    {
        public Engine4Result Execute(IEnumerable<string> passportData)
        {
            var passports = ParsePassportData(passportData);
            var result = new Engine4Result
            {
                countMandatory= passports.Count(p => p.HasMadatoryFields()),
                countMandatoryAndOptional = passports.Count(p => p.HasOptionalFields()),
                countValid = passports.Count(p => p.IsValid()),
                countInValid = passports.Count(p => !p.IsValid()),
            };
            return result;
        }

          private IEnumerable<Passport> ParsePassportData(IEnumerable<string> passportsData)
        {
            var passportLines = new List<string>();
            var passports = new List<Passport>();
            var passportString = String.Empty;

            foreach (var passportData in passportsData)
            {
                if (String.IsNullOrWhiteSpace(passportData))
                {
                    passports.Add(new Passport(passportString));
                    passportString = string.Empty;
                }
                else
                    passportString += passportString.Length > 0 ? " " + passportData : passportData;
            }
            if (passportString.Length > 0)
                passports.Add(new Passport(passportString));

            return passports;
        }
    }

    public class Passport
    {
        public string Eyr { get; set; }
        public string Pid { get; set; }
        public string Hcl { get; set; }
        public string Byr { get; set; }
        public string Iyr { get; set; }
        public string Ecl { get; set; }
        public string Hgt { get; set; }
        public string Cid { get; set; }

        public Passport(string dataAsString)
        {
            var fields = dataAsString.Split(" ");
            foreach (var field in fields)
            {
                var nameValuePair = field.Split(":");
                switch (nameValuePair[0])
                {
                    case "byr":
                        Byr = nameValuePair[1];
                        break;
                    case "iyr":
                        Iyr = nameValuePair[1];
                        break;
                    case "eyr":
                        Eyr = nameValuePair[1];
                        break;
                    case "hgt":
                        Hgt = nameValuePair[1];
                        break;
                    case "hcl":
                        Hcl = nameValuePair[1];
                        break;
                    case "ecl":
                        Ecl = nameValuePair[1];
                        break;
                    case "pid":
                        Pid = nameValuePair[1];
                        break;
                    case "cid":
                        Cid = nameValuePair[1];
                        break;
                }
            }
        }

        public bool HasMadatoryFields()
        {
            var mandatoryFieldsPresent =
                !string.IsNullOrWhiteSpace(Eyr) &&
                !string.IsNullOrWhiteSpace(Pid) &&
                !string.IsNullOrWhiteSpace(Hcl) &&
                !string.IsNullOrWhiteSpace(Byr) &&
                !string.IsNullOrWhiteSpace(Iyr) &&
                !string.IsNullOrWhiteSpace(Ecl) &&
                !string.IsNullOrWhiteSpace(Hgt);

            return mandatoryFieldsPresent;
        }

        public bool HasOptionalFields()
        {
            var mandatoryAndOptionalFieldsPresent =
                HasMadatoryFields() &&
                !string.IsNullOrWhiteSpace(Cid);

            return mandatoryAndOptionalFieldsPresent;
        }

        public bool IsValid()
        {
            if (!HasMadatoryFields())
                return false;

            if (!int.TryParse(Byr, out var byr))
                return false;

            if (byr < 1920 || byr > 2002)
                return false;

            if (!int.TryParse(Iyr, out var iyr))
                return false;

            if (iyr < 2010 || iyr > 2020)
                return false;

            if (!int.TryParse(Eyr, out var eyr))
                return false;

            if (eyr < 2020 || eyr > 2030)
                return false;

            if (!Hgt.EndsWith("cm") && !Hgt.EndsWith("in"))
                return false;

            if (Hgt.EndsWith("cm"))
            {
                if (!int.TryParse(Hgt.Replace("cm", ""), out var hgt))
                    return false;
                if (hgt < 150 || hgt > 193)
                    return false;
            }

            if (Hgt.EndsWith("in"))
            {
                if (!int.TryParse(Hgt.Replace("in", ""), out var hgt))
                    return false;
                if (hgt < 59 || hgt > 76)
                    return false;
            }

            var hairRegEx = new Regex("#[a-z0-9]{6}");
            if (!hairRegEx.Match(Hcl).Success)
                return false;


            string[] eyeColours = new string[] {
                "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
            };
            if (!eyeColours.Contains(Ecl.ToLower()))
                return false;

            if (Pid.Length != 9)
                return false;

            if (!int.TryParse(Pid, out var ignored))
                return false;

            return true;
        }
    }

    public class Engine4Result
    {
        public int countMandatory { get; set; }
        public int countMandatoryAndOptional { get; set; }
        public int countInValid { get; set; }
        public int countValid { get; set; }
        public int totalPassportsValidated { get => countValid + countInValid; }


        static public Engine4Result operator+(Engine4Result A, Engine4Result B)
        {
            var C = new Engine4Result
            {
                countMandatory = A.countMandatory + A.countMandatory,
                countMandatoryAndOptional = A.countMandatoryAndOptional + B.countMandatoryAndOptional,
                countInValid = A.countInValid + B.countInValid,
                countValid = A.countValid + B.countValid
            };
            return C;
        }
    }
}
