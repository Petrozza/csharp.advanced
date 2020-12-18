using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components;

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals;

        public void AddComponent(IComponent component)
        {
            if (components.Any(x => x.GetType() == component.GetType()))
            {
                string err = String.Format(ExceptionMessages.ExistingComponent, component, GetType().Name, Id);
                throw new ArgumentException(err);
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripherals.Any(x => x.GetType() == peripheral.GetType()))
            {
                string err = String.Format(ExceptionMessages.ExistingPeripheral, peripheral, GetType().Name, Id);
                throw new ArgumentException(err);
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!components.Any(x => x.GetType().Name == componentType))
            {
                string err = String.Format(ExceptionMessages.NotExistingComponent, componentType, GetType().Name, Id);
                throw new ArgumentException(err);
            }

            var componentToRemove = components.FirstOrDefault(x => x.GetType().Name == componentType);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (!peripherals.Any(x => x.GetType().Name == peripheralType))
            {
                string err = String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, GetType().Name, Id);
                throw new ArgumentException(err);
            }

            var peripheralToRemove = peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            return peripheralToRemove;
        }

        public override double OverallPerformance
            => CalculateOeverallPerformance();

        public override decimal Price 
            => Components.Sum(x => x.Price) + Peripherals.Sum(y => y.Price) + base.Price;

        private double CalculateOeverallPerformance()
        {
            if (Components.Count == 0)
            {
                return base.OverallPerformance;
            }

            var result =  base.OverallPerformance + Components.Average(x => x.OverallPerformance);
            return result;
        }

        public override string ToString()
        {
            StringBuilder bb = new StringBuilder();
            bb.AppendLine($"Overall Performance: {OverallPerformance:f2}. Price: {Price:f2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})");
            bb.AppendLine($" Components ({Components.Count}):");
            foreach (var component in components)
            {
                bb.AppendLine($"  {component}");
            }

            string averageResult = Peripherals.Count == 0 ? "0.00" : Peripherals.Average(x => x.OverallPerformance).ToString("f2");

            bb.AppendLine($" Peripherals ({Peripherals.Count}); Average Overall Performance ({averageResult:f2}):");
            
            foreach (var peripheral in peripherals)
            {
                bb.AppendLine($"  {peripheral}");
            }

            return bb.ToString().TrimEnd();
        }
    }
}
