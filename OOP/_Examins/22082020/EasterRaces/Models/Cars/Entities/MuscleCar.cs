using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double MuscleCarCubiCentimeters = 5000;
        private const int MinHorsePowerMuscleCar = 400;
        private const int MaxHorsePowerMuscleCar = 600;
        private int horsePower;

        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower)
        {
            CubicCentimeters = MuscleCarCubiCentimeters;
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
                if (value < MinHorsePowerMuscleCar || value > MaxHorsePowerMuscleCar)
                {
                    string err = String.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(err);
                }
                horsePower = value;
            }
        }

    }
}
