using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int yellowLightDuration = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string hittedCar = string.Empty;
            bool isHitted = false;
            char hittedSymbol = '\0';
            int passedCarsCounter = 0;

            string input = Console.ReadLine();

            while (input != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currentGreenLightDuration = greenLightDuration;



                while (currentGreenLightDuration > 0 && cars.Count > 0)
                {
                    string car = cars.Dequeue();
                    int carLenght = car.Length;

                    if (currentGreenLightDuration - carLenght >= 0)
                    {
                        currentGreenLightDuration -= carLenght;
                        passedCarsCounter++;
                    }
                    else
                    {
                        currentGreenLightDuration += yellowLightDuration;

                        if (currentGreenLightDuration - carLenght >= 0)
                        {
                            passedCarsCounter++;
                            break;
                        }
                        else
                        {
                            isHitted = true;
                            hittedCar = car;
                            hittedSymbol = car[currentGreenLightDuration];
                            break;
                        }
                    }
                }

                if (isHitted)
                {
                    break;
                }

                input = Console.ReadLine();
            }
            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCar} was hit at {hittedSymbol}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCarsCounter} total cars passed the crossroads.");
            }
        }
    }
}
