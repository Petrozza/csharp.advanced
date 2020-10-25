using Iterators_and_Comparators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<string> elements = command.Split().Skip(1).ToList();

            ListyIterator<string> listyIterator = new ListyIterator<string>(elements);

            while (command != "END")
            {
                if (command == "Print")
                {
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message); 
                    }
                }

                else if (command == "Move")
                {
                    bool result = listyIterator.Move();
                    Console.WriteLine(result);
                }

                if (command == "HasNext")
                {
                    bool result = listyIterator.HasNext();
                    Console.WriteLine(result);
                }

                if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ", listyIterator));
                }

                command = Console.ReadLine();
            }
        }
    }
}
