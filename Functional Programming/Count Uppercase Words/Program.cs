using System;
using System.Linq;

namespace Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, bool> checker = x => x[0] == x.ToUpper()[0];
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));




        }
    }
}
