using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWorkingProperlyAndCounterToo()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer1 = new Computer("HP", "Nov", 1000m);
            Computer computer2 = new Computer("Acer", "Star", 600m);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);


            Assert.AreEqual(manager.Count, 2);
            Assert.AreEqual(manager.Computers.Count, 2);
        }

        [Test]
        public void AddingExistingComputerShouldThrowException()
        {
            var manager = new ComputerManager();
            var computer = new Computer("HP", "HP", 10);

            Assert.Throws<ArgumentNullException>(()
                => manager.AddComputer(null));
            
            manager.AddComputer(computer);
            Assert.Throws<ArgumentException>(()
                => manager.AddComputer(computer));
        }

        [Test]
        public void GetComputerShouldThrowExceptionOnInvalidData()
        {
            ComputerManager manager = new ComputerManager();

            Assert.Throws<ArgumentNullException>(() => manager.GetComputer("HP", null));
            Assert.Throws<ArgumentNullException>(() => manager.GetComputer(null, "HP"));
            Assert.Throws<ArgumentException>(() => manager.GetComputer("HP", "HP"));

        }

        [Test]
        public void GetComputerShouldWorkAsExpected()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer1 = new Computer("HP", "HP", 1000);
            manager.AddComputer(computer1);
            var computerFromComputerManager = manager.GetComputer("HP", "HP");

            Assert.AreEqual(computer1, computerFromComputerManager);
        }

        [Test]
        public void REMOVEComputerShouldWorkAsExpected()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer1 = new Computer("HP", "HP", 1000);
            Computer computer2 = new Computer("Acer", "Acer", 100);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);

            var computertoremove = manager.RemoveComputer("Acer", "Acer");

            Assert.AreEqual(computer2, computertoremove);
            Assert.AreEqual(1, manager.Computers.Count);
        }

        [Test]
        public void RemoveComputerShouldThrowException()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer1 = new Computer("HP", "HP", 1000);

            manager.AddComputer(computer1);


            Assert.Throws<ArgumentNullException>(()
                => manager.RemoveComputer("HP", null));

            Assert.Throws<ArgumentNullException>(()
                => manager.RemoveComputer(null, "HP"));

            Assert.Throws<ArgumentException>(()
                => manager.RemoveComputer("Acer", "Acer"));
        }

        [Test]
        public void GetComputersByManufacturerShouldWorkAsExpected()
        {
            ComputerManager manager = new ComputerManager();
            Computer computer1 = new Computer("HP", "HP", 1000);
            Computer computer2 = new Computer("HP", "Acer", 100);
            Computer computer3 = new Computer("Dell", "Dell", 100);
            manager.AddComputer(computer1);
            manager.AddComputer(computer2);
            manager.AddComputer(computer3);

            var computersFrom1Manufacturer = manager.GetComputersByManufacturer("HP");

            CollectionAssert.Contains(computersFrom1Manufacturer, computer1);
            CollectionAssert.Contains(computersFrom1Manufacturer, computer2);
            CollectionAssert.DoesNotContain(computersFrom1Manufacturer, computer3);
        }


    }
}