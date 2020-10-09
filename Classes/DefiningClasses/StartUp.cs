using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string date1 = Console.ReadLine();
            string date2 = Console.ReadLine();

            DateModifier modifier = new DateModifier();

            var result = modifier.GetDateDifferences(date1, date2);
            Console.WriteLine(result);
        }
    }
}
