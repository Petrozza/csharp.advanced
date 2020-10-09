using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int> operationAdd = x => x + 1;
            Func<int, int> operationMultiply = x => x * 2;
            Func<int, int> operationSubtract = x => x - 1;


            string input = Console.ReadLine();

            while (input != "end")
            {

                if (input == "add")
                {
                    numbers = numbers.Select(operationAdd).ToArray();
                }
                else if (input == "multiply")
                {
                    numbers = numbers.Select(operationMultiply).ToArray();

                }
                else if (input == "subtract")
                {
                    numbers = numbers.Select(operationSubtract).ToArray();

                }
                else if (input == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }


                input = Console.ReadLine();


            }
        }
    }
}
