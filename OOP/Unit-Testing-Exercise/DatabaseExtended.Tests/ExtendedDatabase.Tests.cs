using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldReturnZeroWhenTestWithEmptyDB()
        {
            //Arrange
            var edb = new ExtendedDatabase();
            
            //Act
            var expectedValue = 0;
            var actualValue = edb.Count;
            
            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void CtorShouldReturnOneCountWhenAddOnePerson()
        {
            //Arrange
            var person = new Person(4, "Ely");
            var edb = new ExtendedDatabase(person);

            //Act
            var expectedResult = 1;
            var actualResult = edb.Count;

            //Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void CtorShouldThrowExceptionWithMoreThanCollSizeElements()
        {
            //Arrange
            var personTemp = new Person[17];
            for (int i = 0; i < personTemp.Length; i++)
            {
                personTemp[i] = new Person(i+1, $"Ely{i+1}");
            }

            //Act - Assert

            Assert.Throws<ArgumentException>(()
                => new ExtendedDatabase(personTemp));

        }
        [Test]
        public void AddOnepersonShoulbBeDoneCorectly()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(1, "Nicky"));

            //Act

            edb.Add(new Person(4, "Sasho"));
            var actualResult = edb.FindById(4);
            //Assert

            Assert.That(actualResult.Id, Is.EqualTo(4));
            Assert.That(actualResult.UserName, Is.EqualTo("Sasho"));
        }

        [Test]

        public void ThrowExceptionWhenAddingPersonInFullCollection()
        {
            //Arrange
            var personTemp = new Person[16];
            for (int i = 0; i < personTemp.Length; i++)
            {
                personTemp[i] = new Person(i + 1, $"Ely{i+1}");
            }

            //Act//
            var edb = new ExtendedDatabase(personTemp);

            //Assert
            Assert.Throws<InvalidOperationException>(()
                => edb.Add(new Person(4, "Moi")));
        }

        [Test]

        public void ShouldThrowExceptionWhenAddingpersonWithExistingID()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(4, "Ely"));

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => edb.Add(new Person(4, "Acho")));
        }

        [Test]

        public void ShouldThrowExceptionWhenAddingpersonWithExistingName()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(4, "Ely"));

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => edb.Add(new Person(5, "Ely")));
        }

        [Test]

        public void ShouldIncrementCountWhenAddingPerson()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(3, "Pif"));

            //Act
            edb.Add(new Person(4, "Vanya"));
            var expectedValue = 2;
            var actualValue = edb.Count;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddingTwoPersonsShouldIncrementCounterWith2()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(3, "Pif"));

            //Act
            edb.Add(new Person(4, "Vanya"));
            edb.Add(new Person(5, "Cveti"));
            var expectedValue = 3;
            var actualValue = edb.Count;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]

        public void ShouldDecrementCountWhenRemovingPerson()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(1, "Az"));

            //Act
            edb.Add(new Person(2, "Ti"));
            edb.Add(new Person(3, "Toi"));

            edb.Remove();

            var expectedValue = 2;
            var actualValue = edb.Count;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);

        } 

        [Test]
        public void Rmoving2PersonsShouldDecrementCountWith2()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(1, "Az"));

            //Act
            edb.Add(new Person(2, "Ti"));
            edb.Add(new Person(3, "Toi"));

            edb.Remove();
            edb.Remove();

            var expectedValue = 1;
            var actualValue = edb.Count;

            //Assert
            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]

        public void ShouldThrowExceptionWhenRemovingPersonFromEmptyCollection()
        {
            //Arrange
            var edb = new ExtendedDatabase();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => edb.Remove());
        }

        [TestCase(null)]
        [TestCase("")]

        public void ShouldThrowExceptionWhenFindingUsernameIsEmptyOrNull(string username)
        {
            //Arrange
            var edb = new ExtendedDatabase();

            //Act - Assert
            Assert.Throws<ArgumentNullException>(()
                => edb.FindByUsername(username));
        }

        [Test]

        public void ShouldThrowExceptionIfFindingNonExistingUsername()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(4, "Ely"));

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => edb.FindByUsername("Acho"));
        }

        [Test]

        public void ShouldWorkCorectlyWhenFindingByUsername()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(4, "Ely"));

            //Act
            var actualValue = edb.FindByUsername("Ely");

            //Assert
            Assert.That(actualValue.Id, Is.EqualTo(4));
            Assert.That(actualValue.UserName, Is.EqualTo("Ely"));
        }

        [Test]
        public void FindByIDShouldThrowExceptionWhenNegativeId()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(3, "As"));

            //Act - Assert
            Assert.Throws<ArgumentOutOfRangeException>(()
                => edb.FindById(-11));

        }

        [Test]

        public void FindByIdShouldThrowExceptioWhenNonExistingIdIsUsed()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(3, "As"));

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => edb.FindById(4));
        }

        [Test]
        public void FindByIdShouldRetunCorrectPerson()
        {
            //Arrange
            var edb = new ExtendedDatabase(new Person(4, "Ely"));

            //Act
            var actualValue = edb.FindById(4);

            //Assert
            Assert.That(actualValue.Id, Is.EqualTo(4));
            Assert.That(actualValue.UserName, Is.EqualTo("Ely"));
        }
    }
}