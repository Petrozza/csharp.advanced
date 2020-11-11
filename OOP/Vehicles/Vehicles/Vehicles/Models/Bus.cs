using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private double AirConditionAddConsumption = 1.4;
        private double defaultFuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            defaultFuelConsumption = fuelConsumption;
            AirConditionAddConsumption += fuelConsumption;
        }

        public bool IsEmpty { get; set; }
        public override bool Drive(double distance)
        {
            if (!IsEmpty)
            {
                FuelConsumption = AirConditionAddConsumption;
            }
            else
            {
                FuelConsumption = defaultFuelConsumption;
            }
            return base.Drive(distance);
        }
    }
}
