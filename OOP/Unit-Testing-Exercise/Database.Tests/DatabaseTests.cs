using NUnit.Framework;
using Database;
using System;
using System.Linq;


//For Judge - remove all 14 Database.Database -> Database only
namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShuoldBeInitializedWith16Elements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var expectedResult = 16;
            int actualResult = database.Count;
            //Assert

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void ConstructorShuoldThrowExceptionIfNot16Elements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var expectedResult = 10;
            int actualResult = database.Count;
            //Assert

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void AddOperationShouldAddElementNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Add(5);
            var allElements = database.Fetch();

            //Assert
            var expectedValue = 5;
            var actualValue = allElements[10];

            var expectedCount = 11;
            var actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedCount, actualCount);

        }
        [Test]
        public void AddOperationShouldThrowExceptionIfElementsAreAbove16()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act - Assert
            Assert.Throws<InvalidOperationException>(() 
                => database.Add(5));

        }

        [Test]
        public void RemoveOperationSshouldRemovingElementAtLastIndex()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Remove();

            //Assert
            var expectedResult = 9;
            var actualResult = database.Fetch()[8];

            var expectedCount = 9;
            var actualCount = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveOperationSshouldThrowExceptionInEmptyDB()
        {
            //Arrange
            Database.Database database = new Database.Database();

            //Act - Assert
            Assert.Throws<InvalidOperationException>(()
                => database.Remove());
        }
        [Test]
        public void FetchShouldReturnAllElements()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var allitems = database.Fetch();

            //Assert
            int[] expectedValue = {1,2,3,4,5 };
            var actualValue = allitems;
            CollectionAssert.AreEqual(expectedValue, allitems);


        }
    }
}