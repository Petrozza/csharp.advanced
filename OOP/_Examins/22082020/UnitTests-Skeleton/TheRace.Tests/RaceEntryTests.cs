using NUnit.Framework;
using System;
using System.Collections.Generic;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        UnitCar alfaCar;
        UnitDriver achoDriver;


        [SetUp]
        public void Setup()
        {
            alfaCar = new UnitCar("ALFAROMEO", 115, 1900.00);
            achoDriver = new UnitDriver("Acho", alfaCar);
        }

        [Test]
        public void ConstructorShoulCreateAmptyCollection()
        {
            RaceEntry race = new RaceEntry();

            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        public void AddingDriverShouldIncreseCounter()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(achoDriver);
            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void AdingDriverShouldThrowExceptionForNullDriver()
        {
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(()
                => race.AddDriver(null), "Driver cannot be null.");
        }

        [Test]
        public void AddingExistingDriverShouldThrowException()
        {
            RaceEntry race = new RaceEntry();
            race.AddDriver(achoDriver);

            Assert.Throws<InvalidOperationException>(()
                => race.AddDriver(achoDriver));
        }

        [Test]
        public void CalculateMethodShouldWorkCorrectly()
        {
            RaceEntry race = new RaceEntry();
            var car2 = new UnitCar("Aveo", 101, 1100.00);
            var driver1 = new UnitDriver("Ely", car2);
            
            race.AddDriver(driver1);
            race.AddDriver(achoDriver);

            double expectedValue = (car2.HorsePower + alfaCar.HorsePower) / 2;
            Assert.AreEqual(expectedValue, race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateMethodShouldThrowEcxeptionWhenCarsAreLessThanTwo()
        {
            RaceEntry race = new RaceEntry();
           
            race.AddDriver(achoDriver);

            double expectedValue = alfaCar.HorsePower;
            Assert.Throws<InvalidOperationException>(() 
                => race.CalculateAverageHorsePower());
        }


    }
}