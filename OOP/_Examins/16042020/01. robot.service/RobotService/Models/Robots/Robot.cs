﻿using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    
    public abstract class Robot : IRobot
    {
        private const string DefaultOwnerName = "Service";

        private int happiness;
        private int energy;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;
            Owner = DefaultOwnerName;
        }

        public string Name { get; }

        public int Happiness 
        {
            get
            {
                return happiness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                happiness = value;
            } 
        }

        public int Energy
        {
            get
            {
                return energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return $" Robot type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}
