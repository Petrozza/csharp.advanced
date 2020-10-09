using System;
using System.IO;

namespace Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string words = File.ReadAllText("../../../words.txt");
            string[] wordsArr = words.Split();
            string input = File.ReadAllText("../../../input.txt");
            string[] inputArr = input.Split();

            foreach (var word in wordsArr)
            {
                foreach (var item in inputArr)
                {
                    if (item == word)
                    {
                        File.AppendAllText("../../../output.txt", item);
                    }
                }
            }
        }
    }
}
