using System;
using System.Collections.Generic;
using System.Linq;

namespace Speed_Racing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> autos = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                
                string[] carData = Console.ReadLine().Split();

                string carmodel = carData[0];
                double fuealAmount = double.Parse(carData[1]);
                double fuelConsumptionPerKilometer = double.Parse(carData[2]);

                Car auto = new Car(carmodel, fuealAmount, fuelConsumptionPerKilometer);
                autos.Add(auto);
            }

            string commandString = Console.ReadLine();
            
            while (commandString != "End")
            {
                string[] command = commandString.Split();
                string carModel = command[1];
                double distance = double.Parse(command[2]);

                Car auto = autos.FirstOrDefault(c => c.Model == carModel);
                auto.CanCarMoveGivenDistance(distance);

                commandString = Console.ReadLine();
            }

            foreach (var auto in autos)
            {
                Console.WriteLine($"{auto.Model} {auto.FuelAmount:f2} {auto.TravelledDistance}");
            }

        }
    }
}
