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
                string displacement = "n/a";
                string efficiency = "n/a";
                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                string power = engineData[1];
                
                if (engineData.Length == 3)
                {
                    if (char.IsDigit(engineData[2][0]))
                    {
                        displacement = engineData[2];
                    }
                    else if (char.IsLetter(engineData[2][0]))
                    {
                        efficiency = engineData[2];
                    }
                }

                else if (engineData.Length == 4)
                {
                    if (char.IsDigit(engineData[2][0]))
                    {
                        displacement = engineData[2];
                    }
                    else if (char.IsLetter(engineData[2][0]))
                    {
                        efficiency = engineData[2];
                    }
                    
                    if (char.IsDigit(engineData[3][0]))
                    {
                        displacement = engineData[3];
                    }
                    else if (char.IsLetter(engineData[3][0]))
                    {
                        efficiency = engineData[3];
                    }
                }

                Engine motor = new Engine(model, power, displacement, efficiency);
                engines.Add(motor);
            }

            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < m; i++)
            {
                string weight = "n/a";
                string color = "n/a";
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carData[0];
                Engine engine = engines.First(e => e.Model == carData[1]);
                
                if (carData.Length == 3)
                {
                    if (char.IsDigit(carData[2][0]))
                    {
                        weight = carData[2];
                    }
                    else if (char.IsLetter(carData[2][0]))
                    {
                        color = carData[2];
                    }
                }

                else if (carData.Length == 4)
                {
                    if (char.IsDigit(carData[2][0]))
                    {
                        weight = carData[2];
                    }
                    else if (char.IsLetter(carData[2][0]))
                    {
                        color = carData[2];
                    }

                    if (char.IsDigit(carData[3][0]))
                    {
                        weight = carData[3];
                    }
                    else if (char.IsLetter(carData[3][0]))
                    {
                        color = carData[3];
                    }
                }

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
