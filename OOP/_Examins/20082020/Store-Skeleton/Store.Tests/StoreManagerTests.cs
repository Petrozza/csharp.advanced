using NUnit.Framework;
using System;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void StoreManagerShouldInitializeProperly()
        {
            StoreManager manager = new StoreManager();

            Assert.AreEqual(0, manager.Count);
        }


        [Test]
        public void AddingProductIncreaseCount()
        {
            StoreManager manager = new StoreManager();
            Product product = new Product("Test", 10, 10);
            manager.AddProduct(product);
            var managerValue = manager.Products.Count;
            var actualValue = manager.Count;

            Assert.AreEqual(1, managerValue);
            Assert.AreEqual(1, actualValue);
        }

        [Test]
        public void AddNullProductShouldThrowException()
        {
            StoreManager manager = new StoreManager();

            Assert.Throws<ArgumentNullException>(()
                => manager.AddProduct(null));

        }

        [Test]
        public void AddBelowZeroQuantityProductShouldThrowException()
        {
            StoreManager manager = new StoreManager();
            Product product = new Product("Test", -20, 10);
               
            Assert.Throws<ArgumentException>(()
                => manager.AddProduct(product));

        }

        [Test]
        public void BuyingNullProductShouldThrowException()
        {
            StoreManager manager = new StoreManager();
            Product product = new Product("Test", 20, 10);
            manager.AddProduct(product);

            Assert.Throws<ArgumentNullException>(()
                => manager.BuyProduct(null, 20));

        }


        [Test]

        public void BuyingMoreThanExistingProductsShouldThrowException()
        {
            StoreManager manager = new StoreManager();
            Product product = new Product("Test", 20, 10);

            manager.AddProduct(product);
            manager.BuyProduct("Test", 20);

            Assert.Throws<ArgumentException>(()
                => manager.BuyProduct("Test", 20));
        }

        [Test]

        public void BuyingShouldCalculateProperly()
        {
            StoreManager manager = new StoreManager();
            Product product = new Product("Test", 20, 10);
            Product product1 = new Product("Test1", 30, 20);

            manager.AddProduct(product);
            manager.AddProduct(product1);

            manager.BuyProduct("Test", 20);

            var expectedTotalQuantity = 0;
            var expectedFinalPrice = 0;
            
            Assert.AreEqual(expectedTotalQuantity, product.Quantity);
            Assert.AreEqual(expectedFinalPrice, product.Quantity * product.Price);
        }

        [Test]

        public void ReturnMostExpensiveProduct()
        {
            StoreManager manager = new StoreManager();
            Product product = new Product("Test", 20, 10);
            Product product1 = new Product("Test1", 30, 20);

            manager.AddProduct(product);
            manager.AddProduct(product1);

            var topProduct = manager.GetTheMostExpensiveProduct();

            Assert.AreSame(product1, topProduct);
        }
    }
}