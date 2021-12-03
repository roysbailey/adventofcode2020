using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode2020.Puzzles.Day6
{
    public class Day6Engine : IDay6Engine
    {
        public int Execute(IEnumerable<string> customsAnswers)
        {
            List<PartyPositiveCustomsAnswers> partyList = GetPartyAnswersFromInput(customsAnswers);

            var distinctCountOAnswersFromANYParticipants = partyList.Sum(pa => pa.DistinctPositiveResponsesFromAnyParticipantCount);

            return distinctCountOAnswersFromANYParticipants;
        }

        public int Execute2(IEnumerable<string> customsAnswers)
        {
            List<PartyPositiveCustomsAnswers> partyList = GetPartyAnswersFromInput(customsAnswers);

            var distinctCountOAnswersFromAllParticipants = partyList.Sum(pa => pa.DistinctPositiveResponsesFromALLParticipantCount);

            return distinctCountOAnswersFromAllParticipants;
        }

        private static List<PartyPositiveCustomsAnswers> GetPartyAnswersFromInput(IEnumerable<string> customsAnswers)
        {
            var partyList = new List<PartyPositiveCustomsAnswers>();
            var partyAnswers = new PartyPositiveCustomsAnswers();
            foreach (var customsAnswer in customsAnswers)
            {
                if (string.IsNullOrEmpty(customsAnswer))
                {
                    partyList.Add(partyAnswers);
                    partyAnswers = new PartyPositiveCustomsAnswers();
                }
                else
                {
                    partyAnswers.AddParticipantPositiveAnswers(customsAnswer);
                }
            }
            partyList.Add(partyAnswers);
            return partyList;
        }

    }

    public class PartyPositiveCustomsAnswers
    {
        private List<string> _postiveAnswers = new List<string>();

        public int DistinctPositiveResponsesFromAnyParticipantCount
        {
            get
            {
                var allAnswersCount = string.Concat(_postiveAnswers).Trim().Distinct().Count();
                return allAnswersCount;
            }
        }

        public int DistinctPositiveResponsesFromALLParticipantCount
        {
            get
            {
                var allAnswersCount = 
                    string.Concat(_postiveAnswers).Trim()
                    .GroupBy(q => q).Where(grp => grp.Count() == _postiveAnswers.Count())
                    .Count();

                return allAnswersCount;
            }
        }

        public void AddParticipantPositiveAnswers(string participantPositiveAnswers)
        {
            _postiveAnswers.Add(participantPositiveAnswers);
        }
    }
}
