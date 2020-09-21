using System;
using System.Collections.Generic;
using System.Linq;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            int nCars = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int counter = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                else if (input != "green")
                {
                    cars.Enqueue(input);
                }
                
                else
                {
                    for (int i = 0; i < nCars; i++)
                    {
                        if (cars.Any())
                        {
                            Console.WriteLine($"{cars.Peek()} passed!");
                            cars.Dequeue();
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
