using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> sta = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input[0] == '1')
                {
                    int elementToInsert = int.Parse(input.Substring(2, input.Length - 2));
                    sta.Push(elementToInsert);
                }
                else if (input == "2")
                {
                    if (sta.Any())
                    {
                        sta.Pop();
                    }
                }
                else
                {
                    if (sta.Any())
                    {
                        if (input == "3")
                        {
                            Console.WriteLine(sta.Max());
                        }
                        else if (input == "4")
                        {
                            Console.WriteLine(sta.Min());
                        }
                    }
                }

            }
            if (sta.Any())
            {
                Console.WriteLine(string.Join(", ", sta));
            }

        }
    }
}
