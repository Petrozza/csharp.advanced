using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Data= new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        public List<Car> Data { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return Data.Count; }
        }

        public void Add(Car car)
        {
            if (Capacity > Data.Count)
            {
                Data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model) 
        {
            bool exist = Data.Any(c => c.Manufacturer == manufacturer && c.Model == model);
            if (exist)
            {
                Car carToRemove = Data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
                Data.Remove(carToRemove);
            }
            return exist;
        }

        public Car GetLatestCar()
        {
            var oldestCar = Data.OrderByDescending(y => y.Year).FirstOrDefault();
            return oldestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            if (!Data.Any(c => c.Manufacturer == manufacturer && c.Model == model))
            {
                return null;
            }
            Car car = Data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return car;
        }
        public string GetStatistics()
        {
            StringBuilder bb = new StringBuilder();
            bb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in Data)
            {
                bb.AppendLine($"{car}");
            }

            return bb.ToString().TrimEnd();
        }



    }
}
