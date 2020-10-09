using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Raw_Data
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> autos = new List<Car>();
            List<Engine> engines = new List<Engine>();
            List<Cargo> cargos = new List<Cargo>();
            List<Tires> tyres = new List<Tires>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                double tire1Pressure = double.Parse(input[5]);
                int tire1Age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2Age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3Age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4Age = int.Parse(input[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure,
                    tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);
                Engine motor = new Engine(engineSpeed, enginePower);
                Cargo maersk = new Cargo(cargoWeight, cargoType);
                Tires tyre = new Tires(tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure,
                    tire3Age, tire4Pressure, tire4Age);

                autos.Add(car);
                engines.Add(motor);
                cargos.Add(maersk);
                tyres.Add(tyre);
            }

            string command = Console.ReadLine();
           
            if (command == "fragile")
            {
                autos = autos.Where(x => x.CargoType == command &&
                (x.Tire1Pressure < 1 || x.Tire2Pressure < 1 ||
                x.Tire3Pressure < 1 || x.Tire4Pressure < 1)).ToList();
            }
            else if (command == "flamable")
            {
                autos = autos.Where(y => y.CargoType == command && (y.EnginePower > 250)).ToList();
            }

            foreach (var item in autos)
            {
                Console.WriteLine(item.Model);

            }
        }
    }
}
