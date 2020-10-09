using System;
using System.Collections.Generic;
using System.Linq;

namespace Car_Salesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Engine> engines = new HashSet<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split();
                string model = engineData[0];
                string power = engineData[1];
                string displacement = engineData.Length > 2 ? engineData[2] : "n/a";
                string efficiency = engineData.Length > 3 ? engineData[3] : "n/a";

                Engine motor = new Engine(model, power, displacement, efficiency);
                engines.Add(motor);
            }

            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine().Split();
                string model = carData[0];
                Engine engine = engines.First(e => e.Model == carData[1]);
                string weight = carData.Length > 2 ? carData[2] : "n/a";
                string color = carData.Length > 3 ? carData[3] : "n/a";

                Car auto = new Car(model, engine, weight, color);
                cars.Add(auto);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
