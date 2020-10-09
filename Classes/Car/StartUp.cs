using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Car car = new Car();

            //car.Make = "VW";
            //car.Model = "MK3";
            //car.Year = 1992;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 200;
            //car.Drive(2000);
            //Console.WriteLine(car.WhoAmI());

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());

            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //var tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.3),
            //    new Tire(2, 2.0),
            //    new Tire(1, 2.3),
            //};

            //Engine engine = new Engine(560, 7000);
            //Car car = new Car("Lamborghini", "Ursus", 2010, 250, 9, engine, tires);


            var tires = new List<Tire[]>();

            string tiresInput = Console.ReadLine();

            while (tiresInput != "No more tires")
            {
                string[] tiresData = tiresInput.Split();
                var tire1 = new Tire(int.Parse(tiresData[0]), double.Parse(tiresData[1]));
                var tire2 = new Tire(int.Parse(tiresData[2]), double.Parse(tiresData[3]));
                var tire3 = new Tire(int.Parse(tiresData[4]), double.Parse(tiresData[5]));
                var tire4 = new Tire(int.Parse(tiresData[6]), double.Parse(tiresData[7]));
                
                tires.Add(new Tire[] { tire1, tire2, tire3, tire4 });
                
                tiresInput = Console.ReadLine();
            }

            string enginesInput = Console.ReadLine();
            
            var engineslist = new List<Engine>();

            while (enginesInput != "Engines done")
            {
                string[] enginesData = enginesInput.Split();
                int hrsPower = int.Parse(enginesData[0]);
                double cubCapacity = double.Parse(enginesData[1]);
                var newEngine = new Engine(hrsPower, cubCapacity);

                engineslist.Add(newEngine);

                enginesInput = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            string carInput = Console.ReadLine();

            while (carInput != "Show special")
            {
                string[] caraData = carInput.Split();
                string make = caraData[0];
                string model = caraData[1];
                int year = int.Parse(caraData[2]);
                int fuelQuantity = int.Parse(caraData[3]);
                int fuelConsumption = int.Parse(caraData[4]);
                var engine = engineslist[int.Parse(caraData[5])];
                var tire = tires[int.Parse(caraData[6])];

                var newCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tire);

                cars.Add(newCar);
                
                carInput = Console.ReadLine();
            }

            cars = cars.Where(x => x.Year >= 2017 
                            && x.Engine.HorsePower > 330 && x.Tires.Sum(y => y.Pressure) >=9 
                            && x.Tires.Sum(y => y.Pressure) <= 10).ToList();


            foreach (var item in cars)
            {
                item.Drive(20);
                //Console.WriteLine(item.WhoAmI());
                Console.WriteLine($"Make: {item.Make}");
                Console.WriteLine($"Model: {item.Model}");
                Console.WriteLine($"Year: {item.Year}");
                Console.WriteLine($"HorsePowers: {item.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {item.FuelQuantity}");

            }
        }


    }
}
