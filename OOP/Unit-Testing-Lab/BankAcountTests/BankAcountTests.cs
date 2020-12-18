using BankAccountTests;
using NUnit.Framework;

namespace BankAcountTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatingInitialAmount()
        {
            const decimal amount = 2000m;
            var bankAccount = new BankAccount(2000);
            //Assert.That(bankAccount.Amount, Is.EqualTo(amount));
            //Assert.AreEqual(amount, bankAccount);
            Assert.  That(amount == bankAccount.Amount);
        }
    }
}