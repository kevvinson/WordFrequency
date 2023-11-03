using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private const string SpaceForSplit = @"\s+";
        private const string SpaceAndOne = " 1";

        public string GetResult(string inputStr)
        {
            if (Regex.Split(inputStr, SpaceForSplit).Length == 1)
            {
                return inputStr + SpaceAndOne;
            }
            else
            {
                //split the input string with 1 to n pieces of spaces
                string[] splittedWords = Regex.Split(inputStr, SpaceForSplit);

                List<string> resultWordCount = splittedWords.
                    GroupBy(x => x).
                    Select(x => new WordCount(x.Key, x.Count())).
                    OrderByDescending(x => x.Count).
                    Select(x => x.Word + " " + x.Count).
                    ToList();

                //stringJoiner joiner = new stringJoiner("\n");
                return string.Join("\n", resultWordCount.ToArray());
            }
        }
    }
}
