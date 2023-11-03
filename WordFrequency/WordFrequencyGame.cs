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

                List<WordCount> wordCountList =
                    splittedWords.Select(word => new WordCount(word, 1)).ToList();

                //get the map for the next step of sizing the same word
                Dictionary<string, List<WordCount>> map = GetListMap(wordCountList);

                // now the list has no repeation
                wordCountList =
                    map.Select(entry => new WordCount(entry.Key, entry.Value.Count)).ToList();

                // now the order is descending
                wordCountList.Sort((word1, word2) => word2.Count - word1.Count);

                List<string> wordsExpressionList =
                    wordCountList.Select(wordCount => wordCount.Word + " " + wordCount.Count).ToList();

                //stringJoiner joiner = new stringJoiner("\n");
                return string.Join("\n", wordsExpressionList.ToArray());
            }
        }

        private Dictionary<string, List<WordCount>> GetListMap(List<WordCount> inputList)
        {
            Dictionary<string, List<WordCount>> map = new Dictionary<string, List<WordCount>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Word))
                {
                    List<WordCount> arr = new List<WordCount>();
                    arr.Add(input);
                    map.Add(input.Word, arr);
                }
                else
                {
                    map[input.Word].Add(input);
                }
            }

            return map;
        }
    }
}
