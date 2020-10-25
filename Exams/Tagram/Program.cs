using System;
using System.Collections.Generic;
using System.Linq;

namespace Tagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Dictionary<string, int>> data = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end")
            {
                if (input.Contains(" -> "))
                {
                    string[] command = input.Split(" -> ");
                    string username = command[0];
                    string tag = command[1];
                    int likes = int.Parse(command[2]);

                    if (!data.ContainsKey(username))
                    {
                        data.Add(username, new Dictionary<string, int>());
                    }
                    if (!data[username].ContainsKey(tag))
                    {
                        data[username].Add(tag, likes);
                    }
                    else
                    {
                        data[username][tag] += likes;
                    }
                }
                else
                {
                    string[] bannedCommand = input.Split();
                    string bannedName = bannedCommand[1];

                    if (data.ContainsKey(bannedName))
                    {
                        data.Remove(bannedName);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var user in data.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(y => y.Value.Values.Count))
            {
                Console.WriteLine(user.Key);

                foreach (var kvp in user.Value)
                {
                    Console.WriteLine($"- {kvp.Key}: {kvp.Value}");
                }
            }
        }
    }
}
