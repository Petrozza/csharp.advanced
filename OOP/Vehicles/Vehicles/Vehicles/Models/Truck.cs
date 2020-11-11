using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AirConditionAddConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += AirConditionAddConsumption; 
        }

        public override void Refuel(double fuel)
        {
            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }
            fuel *= 0.95;
            base.Refuel(fuel);
        }
    }
}
