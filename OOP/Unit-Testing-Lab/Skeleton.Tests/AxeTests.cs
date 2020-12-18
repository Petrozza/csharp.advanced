using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 100, 100, 99)]
    public void AxeLooseDurabillityAfterAttack(
        int health,
        int exp,
        int attack,
        int durability,
        int expResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.AreEqual(axe.DurabilityPoints, expResult, "Axe Durability Doesn't Change After Attack");
    }
    [Test]
    public void AttackShouldThrownExceptionWhenDurabilityIsBelowZero()
    {
        //Arrange
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(20, 0);
        //Act - Assert
        Assert.Throws<InvalidOperationException>(()
            => axe.Attack(dummy));
        

    }
}