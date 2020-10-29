using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class StartUp
    {
        public static void Main()
        {
            RandomList randomList = new RandomList();
            randomList.Add("acho");
            randomList.Add("aort");
            randomList.Add("nuru");
            randomList.Add("nti");

            Console.WriteLine(randomList.Count);
            Console.WriteLine(randomList.RandomString());
            Console.WriteLine(randomList.Count);

        }
    }
}
