using System;

namespace Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Action<string> PrintingInput = x => Console.WriteLine(x);

            foreach (var item in input)
            {
                PrintingInput(item);
            }
        }

    }
}
