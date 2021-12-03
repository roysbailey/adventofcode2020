using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace adventofcode2020.Puzzles.Day2
{
    public class Day2Engine : IDay2Engine
    {
        public void Execute(IEnumerable<string> passwordInfoList, out int validPasswordCountEx1, out int validPasswordCountEx2)
        {
            validPasswordCountEx1 = validPasswordCountEx2 = 0;
            foreach (var passwordInfo in passwordInfoList)
            {
                string password, policy, character;
                int numOne, numTwo;

                policy = passwordInfo.Split(':')[0].Trim();
                password = passwordInfo.Split(':')[1].Trim();

                ParsePolicyDetails(policy, out character, out numOne, out numTwo);
                var passwordValid = DoesPasswordMeetPolicy1(password, character, numOne, numTwo);
                validPasswordCountEx1 = passwordValid ? validPasswordCountEx1 + 1 : validPasswordCountEx1;
                passwordValid = DoesPasswordMeetPolicy2(password, character, numOne, numTwo);
                validPasswordCountEx2 = passwordValid ? validPasswordCountEx2 + 1 : validPasswordCountEx2;
            }
        }

        private void ParsePolicyDetails(string policy, out string character, out int minOccurence, out int maxOccurence)
        {
            var policyBreakdown = policy.Split(' ');
            character = policyBreakdown[1];
            var occurenceData = policyBreakdown[0].Split('-');
            minOccurence = int.Parse(occurenceData[0]);
            maxOccurence = int.Parse(occurenceData[1]);
        }

        private bool DoesPasswordMeetPolicy1(string password, string character, int minOccurence, int maxOccurence)
        {
            var charOccurenceCount = password.Count(ch => ch == character[0]);
            var passowrdConforms = charOccurenceCount >= minOccurence && charOccurenceCount <= maxOccurence;
            return passowrdConforms;
        }
        private bool DoesPasswordMeetPolicy2(string password, string character, int posOne, int posTwo)
        {
            string toValidate = string.Concat(password.Substring(posOne - 1, 1), password.Substring(posTwo - 1, 1));
            var isValid = toValidate.Count(ch => ch == character[0]) == 1;
            return isValid;
        }
    }
}
