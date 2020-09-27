using System;
using System.Collections.Generic;

namespace Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] data = input.Split(", ");

                string direction = data[0];
                string carPlate = data[1];

                if (direction == "IN")
                {
                    cars.Add(carPlate);
                }
                else if (direction == "OUT")
                {
                    cars.Remove(carPlate);
                }
            }
            if (cars.Count > 0)
            {
                foreach (var item in cars)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
