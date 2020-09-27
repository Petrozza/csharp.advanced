using System;
using System.Collections.Generic;
using System.Linq;

namespace The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggers = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Statistics")
                {
                    break;
                }

                string[] commandString = input.Split();
                string vloggerName = commandString[0];
                string command = commandString[1];



                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(vloggerName))
                    {
                        vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggers[vloggerName].Add("followers", new HashSet<string>());
                        vloggers[vloggerName].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string nameFollower = commandString[0];
                    string nameFollowing = commandString[2];

                    if (!vloggers.ContainsKey(nameFollower)
                        || !vloggers.ContainsKey(nameFollowing)
                        || nameFollowing == nameFollower)
                    {
                        continue;
                    }
                    vloggers[nameFollower]["following"].Add(nameFollowing);
                    vloggers[nameFollowing]["followers"].Add(nameFollower);

                }

            }
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var sortedVloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(k => k.Key, v => v.Value);

            int counter = 1;

            foreach (var kvp in sortedVloggers)
            {
                Console.WriteLine($"{counter}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");

                if (counter == 1)
                {
                    foreach (var pair in kvp.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {pair}");
                    }
                }

                counter++;
            }
        }
    }
}
