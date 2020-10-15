using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>(); 
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Tire[] tires = new Tire[4];
                int counter = 0;
                for (int j = 5; j < input.Length; j+=2)
                {
                    double currentPressure = double.Parse(input[j]);
                    int currentAge = int.Parse(input[j + 1]);
                    Tire tire = new Tire(currentPressure, currentAge);
                    tires[counter++] = tire;
                }

                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Engine motor = new Engine(engineSpeed, enginePower);
                 
                Car car = new Car(model, motor, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars.Where(x => x.Cargo.GargoType == command && x.Tires.Any(x => x.TirePressure < 1)) 
                    .ToList().ForEach(x => Console.WriteLine(x.Model));
            }
            else if (command == "flamable")
            {
                cars.Where(y => y.Cargo.GargoType == command && (y.Engine.EnginePower > 250))
                    .ToList().ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
