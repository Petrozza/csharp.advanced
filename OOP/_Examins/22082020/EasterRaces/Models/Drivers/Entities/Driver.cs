using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int MinimumDriverSymbolsLength = 5;

        private string name;
        private bool canParticipate;

        public Driver(string name)
        {
            Name = name;
            canParticipate = false;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinimumDriverSymbolsLength)
                {
                    string err = String.Format(ExceptionMessages.InvalidName, value, MinimumDriverSymbolsLength);
                    throw new ArgumentException(err);
                }
                name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate 
        {
            get
            {
                return canParticipate;
            }
            private set
            {
                if (Car != null)
                {
                    canParticipate = true;
                }
                else
                {
                    canParticipate = false;
                }
            } 
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }
            Car = car;
            CanParticipate = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }
    }
}
