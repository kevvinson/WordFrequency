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
                    //group the words so that no repeation
                    GroupBy(x => x).
                    //count words and generate class WordCount to store data
                    Select(x => new WordCount(x.Key, x.Count())).
                    //make the order right
                    OrderByDescending(x => x.Count).
                    //generate proper string expression for words
                    Select(x => x.Word + " " + x.Count).
                    ToList();

                //stringJoiner joiner = new stringJoiner("\n");
                return string.Join("\n", resultWordCount.ToArray());
            }
        }
    }
}
