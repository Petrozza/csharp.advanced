using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        private const double SportsCarCubiCentimeters = 3000;
        private const int MinHorsePowerSportsCar = 250;
        private const int MaxHorsePowerSportsCar = 450;
        private int horsePower;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower)
        {
            CubicCentimeters = SportsCarCubiCentimeters;
        }

        public override double CubicCentimeters { get; }
        public override int HorsePower
        {
            get
            {
                return horsePower;
            }
            protected set
            {
                if (value < MinHorsePowerSportsCar || value > MaxHorsePowerSportsCar)
                {
                    string err = String.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(err);
                }
                horsePower = value;
            }
        }
    }
}
