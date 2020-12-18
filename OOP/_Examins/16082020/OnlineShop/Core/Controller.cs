using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            DoesComputerExist(computerId);

            if (components.Any(x => x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComponent component = null;

            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            components.Add(component);
            //Computer.AddComponent(component);??
            computers.FirstOrDefault(x => x.Id == computerId).AddComponent(component);
            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";

        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            IComputer computer = null;
            if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            computers.Add(computer);
            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            DoesComputerExist(computerId);

            if (peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            peripherals.Add(peripheral);

            computers.FirstOrDefault(x => x.Id == computerId).AddPeripheral(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            var topComputer = computers.Where(x => x.Price <= budget).OrderByDescending(y => y.OverallPerformance).FirstOrDefault();

            if (topComputer == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            computers.Remove(topComputer);
            return topComputer.ToString();
        }

        public string BuyComputer(int id)
        {
            DoesComputerExist(id);
            var computer = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            DoesComputerExist(id);
            var computer = computers.FirstOrDefault(x => x.Id == id);
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            DoesComputerExist(computerId);
            var component = computers.FirstOrDefault(x => x.Id == computerId).RemoveComponent(componentType);
            components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}."; 
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            DoesComputerExist(computerId);
            var peripheral = computers.FirstOrDefault(x => x.Id == computerId).RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            return $"Successfully removed {peripheralType} with id {peripheral.Id}."; 
        }

        private void DoesComputerExist(int id)
        {
            if (!computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }
    }
}
