namespace Computers.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class ComputerTests
    {
        [SetUp]
        

        [Test]
        public void CtorShouldSetProperlyName()
        {
            //Arrange
            Computer computer = new Computer("Antistat");

            //Act - Assert
            Assert.AreEqual("Antistat", computer.Name);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void CtorShouldThrowExceptionWhenEmptyOrNullIputIsGiven(string input)
        {
            //Act-Assert
            Assert.Throws<ArgumentNullException>(() => new Computer(input));
        }

        //[Test]
        //public void CtorPartsCollectionIsInitiallyEmpty()
        //{
        //    //Arrange
        //    Computer computer = new Computer("Antistat");
        //    Assert.IsEmpty(computer.Parts);
        //}

        [Test]
        public void MethodTotalPriceProperly()
        {
            //Arrange
            Computer computer = new Computer("Antistat");
            
            //Act
            Part part = new Part("Screen", 2.50m);
            Part part1 = new Part("Key", 3.50m);

            //Assert
            computer.AddPart(part);
            computer.AddPart(part1);
            
            Assert.AreEqual(6, computer.TotalPrice);
        }

        [Test]
        public void MethodAddPartCountProperly()
        {
            //Arrange
            Computer computer = new Computer("Antistat");

            //Act
            Part part = new Part("Screen", 2.15m);
            Part part1 = new Part("Key", 2.75m);

            //Assert
            computer.AddPart(part);
            computer.AddPart(part1);
            Assert.AreEqual(2, computer.Parts.Count);
        }

        [Test]
        public void MethodAddPartShouldAddPartWithCorrectName()
        {
            //Arrange
            Computer computer = new Computer("Antistat");

            //Act
            Part part = new Part("Screen", 2.15m);
            Part part1 = new Part("Key", 2.75m);
            
            computer.AddPart(part);
            computer.AddPart(part1);
            Part actualpart = computer.Parts.FirstOrDefault(p => p.Name == "Screen");
            //Assert
            Assert.IsNotNull(actualpart);
            Assert.AreEqual("Screen", actualpart.Name);
        }

        [Test]
        public void MethodAddPartShouldThrowExceptionForNulltInput()
        {
            //Arrange
            Computer computer = new Computer("Antistat");
            Part part12 = null;

            //Assert - Act
            Assert.Throws<InvalidOperationException>(() 
                => computer.AddPart(part12), "Cannot add null!");
        }

        [Test]
        public void MethodRemovePartShouldWorkProperly()
        {
            //Arrange
            Computer computer = new Computer("Antistat");

            //Act
            Part part = new Part("Screen", 2.15m);
            Part part1 = new Part("Key", 2.75m);

            //Act
            computer.AddPart(part);
            computer.AddPart(part1);

            computer.RemovePart(part);
            //Assert
            
            Assert.AreEqual(1, computer.Parts.Count);
        }

        

        [Test]
        public void MethodRemovePartShouldReturnProperlyBool()
        {
            //Arrange
            Computer computer = new Computer("Antistat");

            //Act
            Part part = new Part("Screen", 2.15m);
            Part part1 = new Part("Key", 2.75m);

            //Act
            computer.AddPart(part);
            

            bool actualRes = computer.RemovePart(part1);
            //Assert
            Assert.IsFalse(actualRes);
            
        }
        //[Test]
        //public void MethodRemovePartShouldReturnProperlyBoolTrue()
        //{
        //    //Arrange
        //    Computer computer = new Computer("Antistat");

        //    //Act
        //    Part part = new Part("Screen", 2.15m);
        //    Part part1 = new Part("Key", 2.75m);

        //    //Act
        //    computer.AddPart(part);


        //    bool actualRes = computer.RemovePart(part);
        //    //Assert
        //    Assert.IsTrue(actualRes);
        //}

        //[Test]
        //public void MethodRemovePartShouldReomoveCorrectPart()
        //{
        //    //Arrange
        //    Computer computer = new Computer("Antistat");

        //    //Act
        //    Part part = new Part("Screen", 2.15m);
        //    Part part1 = new Part("Key", 2.75m);

        //    //Act
        //    computer.AddPart(part);

        //    computer.RemovePart(part);
        //    Part actualRes = computer.Parts.FirstOrDefault(p => p.Name == "Screen");
        //    //Assert
        //    Assert.IsNull(actualRes);
        //}

        [Test]
        public void MethodGetPartReceiveCorrectPartName()
        {
            //Arrange
            Computer computer = new Computer("Antistat");

            //Act
            Part part = new Part("Screen", 2.15m);
            Part part1 = new Part("Key", 2.75m);

            //Act
            computer.AddPart(part);
            computer.AddPart(part1);

            Part actualpart = computer.GetPart("Screen");
            //Assert
            Assert.AreEqual("Screen", actualpart.Name);
        }

        [Test]
        public void MethodGetPartRturnCorrectNotNullPartName()
        {
            //Arrange
            Computer computer = new Computer("Antistat");

            //Act
            Part part = new Part("Screen", 2.15m);
            Part part1 = new Part("Key", 2.75m);

            //Act
            computer.AddPart(part);
            computer.AddPart(part1);

            Part actualpart = computer.GetPart("Screen");
            //Assert
            Assert.AreEqual("Screen", actualpart.Name);
            Assert.AreEqual(2.15m, actualpart.Price);
        }

        //[Test]
        //public void MethodGetPartReceiveCorrectPartNameNotNull()
        //{
        //    //Arrange
        //    Computer computer = new Computer("Antistat");

        //    //Act
        //    Part part = new Part("Screen", 2.15m);
        //    Part part1 = new Part("Key", 2.75m);

        //    //Act
        //    computer.AddPart(part);
        //    computer.AddPart(part1);

        //    Part actualpart = computer.GetPart("Button");
        //    //Assert
        //    Assert.IsNull(actualpart);
        //}
    }
}