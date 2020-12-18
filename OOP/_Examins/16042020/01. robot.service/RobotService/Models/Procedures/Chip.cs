﻿using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);

            if (robot.IsChipped)
            {
                string msg = String.Format(ExceptionMessages.AlreadyChipped, robot.Name);
                throw new ArgumentException(msg);
            }
            robot.ProcedureTime -= procedureTime;
            robot.Happiness -= 5;
            robot.IsChipped = true;
            Robots.Add(robot);
        }
    }
}
