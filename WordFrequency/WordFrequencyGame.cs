using System;
using System.Collections.Generic;
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

                List<WordCount> wordCountList = new List<WordCount>();
                foreach (var word in splittedWords)
                {
                    WordCount input = new WordCount(word, 1);
                    wordCountList.Add(input);
                }

                //get the map for the next step of sizing the same word
                Dictionary<string, List<WordCount>> map = GetListMap(wordCountList);

                List<WordCount> list = new List<WordCount>();
                foreach (var entry in map)
                {
                    WordCount input = new WordCount(entry.Key, entry.Value.Count);
                    list.Add(input);
                }

                wordCountList = list;

                wordCountList.Sort((w1, w2) => w2.Count - w1.Count);

                List<string> strList = new List<string>();

                //stringJoiner joiner = new stringJoiner("\n");
                foreach (WordCount wordCount in wordCountList)
                {
                    string wordWithCount = wordCount.Word + " " + wordCount.Count;
                    strList.Add(wordWithCount);
                }

                return string.Join("\n", strList.ToArray());
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
