//using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Acho", 10, 10)]
        [TestCase("Ely", 20, 30)]
        [TestCase("Moni", 20, 0)]
        public void WarriorConstructorShouldSetDataProperly(string name, 
            int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act - Assert
            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);

        }

        [Test]
        [TestCase("", 10, 20)]
        [TestCase(" ", 50, 60)]
        [TestCase(null, 80, 90)]
        public void 
            ConstructorShouldThrowExceptionIfInvalidNameIsProvided(string name,
            int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Acho", 0, 20)]
        [TestCase("Ely", -10, 60)]
        public void
            ConstructorShouldThrowExceptionIfInvalidDamageIsProvided(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp));
        }

        [Test]
        [TestCase("Acho", 10, -5)]
        public void
            ConstructorShouldThrowExceptionIfInvalidHPIsProvided(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(()
                => new Warrior(name, damage, hp));
        }
        
        [Test]
        [TestCase("Acho", 10, 10, "Sasho", 10, 10)]
        [TestCase("Acho", 10, 100, "Sasho", 10, 10)]
        [TestCase("Acho", 10, 50, "Sasho", 100, 50)]
        public void AttackShouldThrowExceptionWhenHPIsInvalid(string fighterName, 
            int fighterDamage, int fighterHp, string defName, int defDamage, int defHp)
        {
            var fighter = new Warrior(fighterName, fighterDamage, fighterHp);
            var defender = new Warrior(defName, defDamage, defHp);

            Assert.Throws<InvalidOperationException>(()
                => fighter.Attack(defender));
        }

        [Test]
        [TestCase("Acho", 10, 50, 40, "Sasho", 10, 50, 40)]
        [TestCase("Acho", 20, 100, 90, "Sasho", 10, 70, 50)]
        [TestCase("Acho", 50, 100, 90, "Sasho", 10, 40, 0)]
        public void WarriorAttackOperationShouldDecreaseHp(string fighterName,
            int fighterDamage, int fighterHp, int fighterHpLeft, string defName, int defDamage, int defHp, int defHpLeft)
        {
            //Arrange
            var fighter = new Warrior(fighterName, fighterDamage, fighterHp);
            var defender = new Warrior(defName, defDamage, defHp);

            //Act
            fighter.Attack(defender);

            //Assert
            var expectedFighterHp = fighterHpLeft;
            var expectedDefenderHp = defHpLeft;

            Assert.AreEqual(expectedFighterHp, fighter.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);

        }
    }
}