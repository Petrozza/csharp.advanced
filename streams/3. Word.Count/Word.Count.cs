using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._Word.Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = File.ReadAllText("../../../words.txt").ToLower();
            string text = File.ReadAllText("../../../text.txt").ToLower();
            string[] wordArr = word.Split(Environment.NewLine);
            
            Dictionary<string, int> words = new Dictionary<string, int>();

            string pattern = @"[A-Za-z]+";

            Regex pureWords = new Regex(pattern);

            foreach (var item in wordArr)
            {
                foreach (Match match in pureWords.Matches(text))
                {
                    if (match.Value == item)
                    {
                        if (!words.ContainsKey(item))
                        {
                            words.Add(item, 1);
                        }
                        else
                        {
                            words[item]++;
                        }
                    }
                }
            }

            string[] result = new string[wordArr.Length];
            string[] expectedResult = new string[wordArr.Length];

            int count = 0;

            foreach (var item in words)
            {
                result[count] = $"{item.Key} - {item.Value}";
                count++;
            }

            File.WriteAllLines("../../../actualResult.txt", result);
           
            int count1 = 0;

            foreach (var item in words.OrderByDescending(x => x.Value))
            {
                expectedResult[count1] = $"{item.Key} - {item.Value}";
                count1++;
            }

            File.WriteAllLines("../../../expectedResult.txt", expectedResult);
            count1++;
        }
    }
}
