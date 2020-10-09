using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count 
        {
            get { return cars.Count; } 
        }
        public string AddCar(Car car)
        {
            bool isExist = cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);
            if (isExist)
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }

            cars.Add(car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            var cartoRemove = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
            if (cartoRemove == null)
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(cartoRemove);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                Car carToDelete = cars.FirstOrDefault(x => x.RegistrationNumber == number);
                cars.Remove(carToDelete);
            }
        }
    }
}
