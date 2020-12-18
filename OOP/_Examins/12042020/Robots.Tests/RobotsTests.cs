namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        public void ConstructorShouldWorkProperly()
        {
            //var robot = new Robot("Acho", 100);

            var robotManager = new RobotManager(100);

            Assert.AreEqual(100, robotManager.Capacity);
        }

        [Test]
        public void CapacityShouldThrowEceptionWhenIsInvalid()
        {
            Assert.Throws<ArgumentException>(()
                => new RobotManager(-100));
        }

        [Test]
        public void RobotsCountShouldCountProperlyy()
        {
            var robotManager = new RobotManager(100);
            var robot = new Robot("Acho", 100);
            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void AddindRobotWithSameNameShouldThrowException()
        {
            var robot = new Robot("Acho", 4);
            var robotManager = new RobotManager(100);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot("Acho", 5)));

        }

        [Test]
        public void RobotManagerShouldThrowExceptionForInvalidCapacity()
        {
            var robot = new Robot("Acho", 4);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot("Acho", 5)));

        }

        [Test]
        public void RobotManagerRemoveMethodShouldWorkProperly()
        {
            var robot = new Robot("Acho", 4);
            var robotManager = new RobotManager(1);

            robotManager.Add(robot);
            robotManager.Remove("Acho");

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManagerRemoveMethodShouldThrowExceptionForInvRobotName()
        {
            var robot = new Robot("Acho", 4);
            var robotManager = new RobotManager(1);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() 
                => robotManager.Remove("Ocha"));
        }

        [Test]
        public void WorkShouldDecreaseRobotBattery()
        {
            var robot = new Robot("Acho", 20);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            robotManager.Work("Acho", "Cleaning", 15);

            Assert.AreEqual(5, robot.Battery);

        }

        [Test]
        public void WorkShouldThrowExceptionForInvalidRobot()
        {
            var robot = new Robot("Acho", 20);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() 
                => robotManager.Work("Ely", "Cleaning", 15));

        }

        [Test]
        public void WorkShouldThrowExceptionWhenBatteryIsNotEnough()
        {
            var robot = new Robot("Acho", 10);
            var robotManager = new RobotManager(2);
            robotManager.Add(robot);
            

            Assert.Throws<InvalidOperationException>(() 
                => robotManager.Work("Acho", "Cleaning", 15));

        }

        [Test]
        public void ChargeShouldThrowExceptionForInvalidRobot()
        {
            var robot = new Robot("Acho", 20);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Charge("Ely"));

        }

        [Test]
        public void ChargeShouldSetToMaximum()
        {
            var robot = new Robot("Acho", 20);
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            robotManager.Work("Acho", "Cleaning", 15);
            robotManager.Charge("Acho");

            Assert.AreEqual(20, robot.Battery);

        }
    }
}
