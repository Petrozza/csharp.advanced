using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<ProcedureType, IProcedure> procedures;

        public Controller()
        {
            garage = new Garage();
            procedures = new Dictionary<ProcedureType, IProcedure>();
            SeedProcedures();
        }

        public string Charge(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);

            string message = DoService(robotName, procedureTime, ProcedureType.Charge, OutputMessages.ChargeProcedure);
            return message;
        }

        public string Chip(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);

            string message = DoService(robotName, procedureTime, ProcedureType.Chip, OutputMessages.ChipProcedure);
            return message;
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);
            IProcedure procedure = procedures[procedureTypeEnum];
            return procedure.History().Trim();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (robotType != nameof(PetRobot) && robotType != nameof(HouseholdRobot) && robotType != nameof(WalkerRobot))
            {
                string msg = String.Format(ExceptionMessages.InvalidRobotType, robotType);
                throw new ArgumentException(msg);
            }

            IRobot robot = null;

            switch (robotType)
            {
                case nameof(PetRobot):
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case nameof(HouseholdRobot):
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case nameof(WalkerRobot):
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
            }

            garage.Manufacture(robot);
            string message = String.Format(OutputMessages.RobotManufactured, name);
            return message;
        }

        public string Polish(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);

            string message = DoService(robotName, procedureTime, ProcedureType.Polish, OutputMessages.PolishProcedure);
            return message;
        }

        public string Rest(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);

            string message = DoService(robotName, procedureTime, ProcedureType.Rest, OutputMessages.RestProcedure);
            return message;
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = GetRobotByName(robotName);
            garage.Sell(robotName, ownerName);

            string result = string.Empty;

            if (robot.IsChipped)
            {
                result = string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                result = string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
            return result;
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);

            string message = DoService(robotName, procedureTime, ProcedureType.TechCheck, OutputMessages.TechCheckProcedure);
            return message;
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedures[ProcedureType.Work];
            procedure.DoService(robot, procedureTime);
            
            string message = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return message;
        }

        private string DoService(string robotName, int procedureTime, ProcedureType procedureType, string autotemplate)
        {
            IRobot robot = GetRobotByName(robotName);
            IProcedure procedure = procedures[procedureType];
            procedure.DoService(robot, procedureTime);
            string message = String.Format(autotemplate, robotName);
            return message;
        }
        private IRobot GetRobotByName(string name)
        {
            if (!garage.Robots.ContainsKey(name))
            {
                string msg = String.Format(ExceptionMessages.InexistingRobot, name);
                throw new ArgumentException(msg);
            }
            return garage.Robots[name];
        }

        private void SeedProcedures()
        {
            procedures.Add(ProcedureType.Charge, new Charge());
            procedures.Add(ProcedureType.Chip, new Chip());
            procedures.Add(ProcedureType.Polish, new Polish());
            procedures.Add(ProcedureType.Rest, new Rest());
            procedures.Add(ProcedureType.TechCheck, new TechCheck());
            procedures.Add(ProcedureType.Work, new Work());
        }
    }
}
