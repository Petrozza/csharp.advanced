using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int MinimumModelSymbolsLength = 4;
        
        private string model;

        public Car(string model, int horsePower)
        {
            Model = model;
            HorsePower = horsePower;
        }
        public string Model
        {
            get
            {
                return model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinimumModelSymbolsLength)
                {
                    string err = String.Format(ExceptionMessages.InvalidModel, value, MinimumModelSymbolsLength);
                    throw new ArgumentException(err);
                }
                model = value;
            }
        }

        public abstract int HorsePower { get; protected set; }

        public abstract double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
