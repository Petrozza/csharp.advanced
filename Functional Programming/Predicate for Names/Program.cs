using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, bool> filter = (x) => x.Length <= n;
            
            names = names.Where(filter).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
