using System;
using System.IO;
using System.Linq;

namespace _2._Line.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../text.txt");

            int counter = 1;
            string[] result = new string[input.Length];
            
            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];
                int letters = 0;
                int punctuationMarks = 0;


                foreach (var item in line)
                {
                    char[] punctuationMarksArray = { '-', ',', '.', '!', '?', '\'', ':', ';' };
                    
                    if (char.IsLetter(item))
                    {
                        letters++;
                    }
                    else if (punctuationMarksArray.Contains(item))
                    {
                        punctuationMarks++;
                    }
                }

                result[i] = $"Line {counter++}: {input[i]} ({letters})({punctuationMarks})";

            }
            File.WriteAllLines("../../../output.txt", result);
        }
    }
}
