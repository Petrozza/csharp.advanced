using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Garages
{
    
    public class Garage : IGarage
    {
        private const int Capacity = 10;
        private readonly Dictionary<string, IRobot> robots;

        public Garage()
        {
            robots = new Dictionary<string, IRobot>();
        }
        
        public IReadOnlyDictionary<string, IRobot> Robots 
        {
            get
            {
                return robots;
            } 
        }

        public void Manufacture(IRobot robot)
        {
            if (robots.Count == Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (robots.ContainsKey(robot.Name))
            {
                string msg = String.Format(ExceptionMessages.ExistingRobot, robot.Name);
                throw new ArgumentException(msg);
            }

            robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!robots.ContainsKey(robotName))
            {
                string msg = String.Format(ExceptionMessages.InexistingRobot, robotName);
                throw new ArgumentException(msg);
            }

            IRobot neededRobot = robots[robotName];
            neededRobot.Owner = ownerName;
            neededRobot.IsBought = true;
            robots.Remove(robotName);
        }
    }
}
