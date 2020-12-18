using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinRaceParticipants = 3;
        private readonly CarRepository carRepository;
        private readonly DriverRepository driverRepository;
        private readonly RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (!this.driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                string err = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(err);
            }
            if (!this.carRepository.GetAll().Any(x => x.Model == carModel))
            {
                string err = string.Format(ExceptionMessages.CarNotFound, carModel);
                throw new InvalidOperationException(err);
            }

            IDriver driver = driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);
            ICar car = this.carRepository.GetAll().FirstOrDefault(c => c.Model == carModel);
            
            driver.AddCar(car);

            string message = string.Format(OutputMessages.CarAdded, driverName, carModel);
            return message;
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (!this.raceRepository.GetAll().Any(x => x.Name == raceName))
            {
                string err = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(err);
            }
            if (!this.driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                string err = string.Format(ExceptionMessages.DriverNotFound, driverName);
                throw new InvalidOperationException(err);
            }

            IRace race = this.raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);
            IDriver driver = this.driverRepository.GetAll().FirstOrDefault(d => d.Name == driverName);

            race.AddDriver(driver);

            string message = string.Format(OutputMessages.DriverAdded, driverName, raceName);
            
            return message;

        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetAll().Any(x => x.Model == model))
            {
                string err = string.Format(ExceptionMessages.CarExists, model);
                throw new ArgumentException(err);
            }

            ICar car = CarFabric(type, model, horsePower);
            this.carRepository.Add(car);
            string message = string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
            
            return message;
        }

        

        public string CreateDriver(string driverName)
        {
            if (this.driverRepository.GetAll().Any(x => x.Name == driverName))
            {
                string err = string.Format(ExceptionMessages.DriversExists, driverName);
                throw new ArgumentException(err);
            }

            Driver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            string message = string.Format(OutputMessages.DriverCreated, driverName);
            return message;
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetAll().Any(x => x.Name == name))
            {
                string err = string.Format(ExceptionMessages.RaceExists, name);
                throw new InvalidOperationException(err);
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);

            string message = string.Format(OutputMessages.RaceCreated, name);
            
            return message;

        }

        public string StartRace(string raceName)
        {
            if (!this.raceRepository.GetAll().Any(x => x.Name == raceName))
            {
                string err = string.Format(ExceptionMessages.RaceNotFound, raceName);
                throw new InvalidOperationException(err);
            }

            IRace race = this.raceRepository.GetAll().FirstOrDefault(r => r.Name == raceName);
            
            if (race.Drivers.Count < MinRaceParticipants)
            {
                string err = string.Format(ExceptionMessages.RaceInvalid, raceName, MinRaceParticipants);
                throw new InvalidOperationException(err);
            }

            int laps = race.Laps;
            List<IDriver> sortedDrivers = race.Drivers.OrderByDescending(d => d.Car.CalculateRacePoints(laps)).Take(3).ToList();
            this.raceRepository.Remove(race);

            StringBuilder bbb = new StringBuilder();

            int counter = 1;
            string msg = null;
            foreach (var driver in sortedDrivers)
            {
                if (counter == 1)
                {
                    msg = string.Format(OutputMessages.DriverFirstPosition, driver.Name, raceName);
                }
                else if (counter == 2)
                {
                    msg = string.Format(OutputMessages.DriverSecondPosition, driver.Name, raceName);
                }
                else if (counter == 3)
                {
                    msg = string.Format(OutputMessages.DriverThirdPosition, driver.Name, raceName);
                }
                bbb.AppendLine(msg);
                counter++;
            }

            

            return bbb.ToString().TrimEnd();
        }

        private static ICar CarFabric(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            return car;
        }
    }
}
