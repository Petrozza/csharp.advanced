using System;
using System.Collections.Generic;

namespace Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var bigData = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split();

                string continent = inputData[0];
                string country = inputData[1];
                string city = inputData[2];

                if (!bigData.ContainsKey(continent))
                {
                    bigData.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!bigData[continent].ContainsKey(country))
                {
                    bigData[continent].Add(country, new List<string>());
                }
                
                bigData[continent][country].Add(city);
            }

            foreach (var kvp in bigData)
            {
                Console.WriteLine(kvp.Key + ":");

                foreach (var pair in kvp.Value)
                {
                    Console.WriteLine($"  {pair.Key} -> {string.Join(", ", pair.Value)}");
                }
            }
        }
    }
}
