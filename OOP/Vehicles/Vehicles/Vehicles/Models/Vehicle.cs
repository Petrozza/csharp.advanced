using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;

            if (fuelQuantity > TankCapacity)
            {
                FuelQuantity = 0;
            }
            else
            {
                FuelQuantity = fuelQuantity;
            }

            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; set; }

        public virtual bool Drive(double distance)
        {
            bool canDrive = FuelQuantity - FuelConsumption * distance >= 0;
            
            if (canDrive)
            {
                FuelQuantity -= FuelConsumption * distance;
                return true;
            }
            return false;
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            if (this.FuelQuantity + fuel > TankCapacity )
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }
            FuelQuantity += fuel;
        }

    }

}
