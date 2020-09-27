using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> nameList = new List<string>();
            HashSet<string> nameHash = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                nameList.Add(input);
            }

            foreach (var word in nameList)
            {
                nameHash.Add(word);
            }

            foreach (var item in nameHash)
            {
                Console.WriteLine(item);
            }

        }
    }
}
