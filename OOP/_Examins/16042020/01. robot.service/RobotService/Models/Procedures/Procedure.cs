using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            Robots = new List<IRobot>();
        }
        protected IList<IRobot> Robots { get;  }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            

            if (robot.ProcedureTime <= procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
        }

        public string History()
        {
            StringBuilder bb = new StringBuilder();
            bb.AppendLine($"{GetType().Name}");
            foreach (IRobot robot in Robots)
            {
                bb.AppendLine(robot.ToString());
            }
            return bb.ToString().TrimEnd();
        }
    }
}
