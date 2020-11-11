using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Models;

namespace Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            var car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            var truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            var bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                try
                {
                    string[] inputInfo = Console.ReadLine().Split();

                    string command = inputInfo[0];
                    string vehickeType = inputInfo[1];
                    double value = double.Parse(inputInfo[2]);

                    if (command == "Drive")
                    {
                        if (vehickeType == "Car")
                        {
                            DriveVehicle(car, value);
                        }
                        else if (vehickeType == "Truck")
                        {
                            DriveVehicle(truck, value);
                        }
                        else if (vehickeType == "Bus")
                        {
                            bus.IsEmpty = false;
                            DriveVehicle(bus, value);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (vehickeType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehickeType == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (vehickeType == "Bus")
                        {
                            bus.Refuel(value);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        DriveVehicle(bus, value);

                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f}");
        }

        private static void DriveVehicle(Vehicle vehicle, double value)
        {
            bool canTravell = vehicle.Drive(value);

            string result = !canTravell
                ? $"{vehicle.GetType().Name} needs refueling"
                : $"{vehicle.GetType().Name} travelled {value} km";
            Console.WriteLine(result);
        }
    }
}
