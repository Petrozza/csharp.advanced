using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    
    public class Race : IRace
    {
        private const int MinRaceNameLength = 5;
        private const int MinLaps = 1;

        private string name;
        private int laps;
        private readonly List<IDriver> drivers;

        private Race()
        {
            drivers = new List<IDriver>();
        }
        public Race(string name, int laps) : this()
        {
            Name = name;
            Laps = laps;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinRaceNameLength)
                {
                    string err = String.Format(ExceptionMessages.InvalidName, value, MinRaceNameLength);
                    throw new ArgumentException(err);
                }
                name = value;
            }
        }

        public int Laps 
        {
            get
            {
                return laps;
            }
            private set
            {
                if (value < MinLaps)
                {
                    string err = String.Format(ExceptionMessages.InvalidNumberOfLaps, MinLaps);
                    throw new ArgumentException(err);
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers 
            => drivers;

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                string err = String.Format(ExceptionMessages.DriverNotParticipate, driver.Name);
                throw new ArgumentException(err);
            }

            if (Drivers.Contains(driver))
            {
                string err = String.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, Name);
                throw new ArgumentNullException(err);
            }

            drivers.Add(driver);
        }
    }
}
