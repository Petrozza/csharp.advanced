using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = new Dictionary<string, string>();
            var contestData = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }
                string[] validationData = input.Split(':');
                string validationContest = validationData[0];
                string validationPassword = validationData[1];

                if (!inputData.ContainsKey(validationContest))
                {
                    inputData.Add(validationContest, validationPassword);
                }
            }

            while (true)
            {
                string input2 = Console.ReadLine();
                if (input2 == "end of submissions")
                {
                    break;
                }
                string[] data = input2.Split("=>");
                string contest = data[0];
                string password = data[1];
                string username = data[2];
                int points = int.Parse(data[3]);

                if (!(inputData.ContainsKey(contest) && inputData[contest] == password))
                {
                    continue;
                }

                if (!contestData.ContainsKey(username))
                {
                    contestData.Add(username, new Dictionary<string, int>());
                }

                if (!contestData[username].ContainsKey(contest))
                {
                    contestData[username].Add(contest, points);
                }

                if (contestData[username][contest] < points)
                {
                    contestData[username][contest] = points;
                }
            }

            foreach (var ipair in contestData.OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine($"Best candidate is {ipair.Key} with total {ipair.Value.Values.Sum()} points.");
                break;
            }

            Console.WriteLine("Ranking:");
            foreach (var kvp in contestData.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key}");

                foreach (var pair in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
                }
            }

        }
    }
}