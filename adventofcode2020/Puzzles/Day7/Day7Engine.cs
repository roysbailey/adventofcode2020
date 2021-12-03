using adventofcode2020.Puzzles.Day1;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace adventofcode2020.Puzzles.Day7
{
    public class Day7Engine : IDay7Engine
    {
        static public Dictionary<string, IEnumerable<BagRule>> _bagRuleList = new Dictionary<string, IEnumerable<BagRule>>();
        static int _recursionDepth = 0;

        public int Execute(IEnumerable<string> bagRuleStrings, string bagColourToCount)
        {
            LoadBagRules(bagRuleStrings);
            var matchedColours = new List<string>();
            foreach (var bagRule in _bagRuleList)
            {
                int containedBagCount = 0;
                bagRule.BagCount(b => b.BagColour == bagColourToCount, ref containedBagCount);
                if (containedBagCount > 0)
                    matchedColours.Add(bagRule.Key);
            }

            return matchedColours.Count;
        }

        public int Execute2(IEnumerable<string> bagRuleStrings, string bagColourToCount)
        {
            LoadBagRules(bagRuleStrings);
            var bagRule = _bagRuleList.First(r => r.Key == bagColourToCount);
            int containedBagCount=0;
            bagRule.BagCount(b => true, ref containedBagCount);

            return containedBagCount;
        }

        private void LoadBagRules(IEnumerable<string> bagRulesAsText)
        {
            _bagRuleList.Clear();
            foreach (var bagRuleAsText in bagRulesAsText)
            {
                var bagRuleAsTextClean = bagRuleAsText.Replace("bags", "").Replace("bag", "").Replace(".", "").Replace(", ", ",");
                // bright olive contain 5 dotted white,2 wavy lavender
                var ruleElements = bagRuleAsTextClean.Split("contain", 2);
                var currentBagName = ruleElements[0].Trim();
                var currentBagRules = ruleElements[1].Split(',').Select(r => new BagRule(r.Trim())).ToList();

                _bagRuleList.Add(currentBagName, currentBagRules);
            }
        }
    }

    public static class BagExtensions
    {
        public static void BagCount(this KeyValuePair<string, IEnumerable<BagRule>> rule, Func<BagRule, bool> matchRule, ref int bagCount)
        {
            //bagCount += rule.Value.Count(matchRule);
            bagCount += rule.Value.Where(matchRule).Sum(r => r.RequiredCount); ;

            var rulesToExplore = rule.Value.Where(r => r.RequiredCount > 0);
            foreach (var ruleToExplore in rulesToExplore)
            {
                var containedBagRules = Day7Engine._bagRuleList.First(r => r.Key == ruleToExplore.BagColour);
                int countPerBag=0;
                containedBagRules.BagCount(matchRule, ref countPerBag);     // How many contained bags in a single instance of the bag
                bagCount += countPerBag * ruleToExplore.RequiredCount;      // Need to count for "each" required bag.
            }
        }
    }

    public class BagRule
    {
        // Initialization of a property    
        public int RequiredCount
        {
            get;
            private set;
        } = -1;
        public string BagColour
        {
            get;
            private set;
        } = string.Empty;

        public BagRule(string bagRuleString)
        {
            if (bagRuleString == "no other")
            {
                BagColour = string.Empty;
                RequiredCount = 0;
                return;
            }
            var ruleElements = bagRuleString.Split(" ");
            RequiredCount = int.Parse(ruleElements[0]);
            BagColour = string.Join(" ", ruleElements, 1, ruleElements.Count()-1).Trim();
        }
    }
}
