using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Predicate_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();
            Func<string, string, bool> StartsWithFunc = (name, StartsWithString) => name.StartsWith(StartsWithString);
            Func<string, string, bool> EndsWithFunc = (name, EndsWithString) => name.EndsWith(EndsWithString);
            Func<string, int, bool> LengthFunc = (name, length) => name.Length == length;

            while (input != "Party!")
            {
                string[] commandData = input.Split();

                string command = commandData[0];
                string condition = commandData[1];
                string criteria = commandData[2];

                if (command == "Double")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(criteria);
                        var tempNames = guests.Where(name => LengthFunc(name, length)).ToList();

                        AddCurrentName(guests, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {
                        var tempNames = guests.Where(name => StartsWithFunc(name, criteria)).ToList();
                        
                        AddCurrentName(guests, tempNames);
                    }
                    else if (condition == "EndsWith")
                    {
                        var tempNames = guests.Where(name => EndsWithFunc(name, criteria)).ToList();

                        AddCurrentName(guests, tempNames);
                    }
                    

                }
                else if (command == "Remove")
                {
                    if (condition == "Length")
                    {
                        int length = int.Parse(criteria);
                        guests = guests.Where(x => !LengthFunc(x, length)).ToList();
                    }
                    if (condition == "StartsWith")
                    {
                        guests = guests.Where(name => !StartsWithFunc(name, criteria)).ToList();
                    }
                    else if (condition == "EndsWith")
                    {
                        guests = guests.Where(name => !EndsWithFunc(name, criteria)).ToList();
                    }
                    
                }


                input = Console.ReadLine();
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void AddCurrentName(List<string> guests, List<string> tempNames)
        {
            foreach (var currentName in tempNames)
            {
                int index = guests.IndexOf(currentName);
                guests.Insert(index, currentName);
            }
        }
    }
}
