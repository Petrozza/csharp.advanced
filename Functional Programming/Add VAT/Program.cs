using System;
using System.Linq;

namespace Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, double> parser = x => double.Parse(x);
            Func<double, double> vat = y => y * 1.2;
            double[] input = Console.ReadLine()
                .Split(", ")
                .Select(parser)
                .Select(vat)
                .ToArray();

            foreach (var item in input)
            {
                Console.WriteLine($"{item:f2}");
            }




        }
    }
}
