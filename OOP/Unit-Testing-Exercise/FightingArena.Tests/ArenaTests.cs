using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeDependentValues()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        //warriors.Add(warrior) -> count;
        [Test]
        public void EnrollShouldThrowExeptionIfWarriorExist()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Acho", 10, 10);
            
        }

        

        [Test]
        public void EnrollShouldAddWarriorToCollection()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Acho", 10, 10);
            arena.Enroll(warrior);

            var expectedCount = 1;
            var isAny = arena.Warriors.Any(w => w.Name == "Acho");
            int counter = arena.Warriors.Count;
            Assert.AreEqual(expectedCount, arena.Count);
            Assert.IsTrue(isAny);
            Assert.AreEqual(1, counter);
        }

        [Test]
        [TestCase("Gosho", "Stoyan")]
        public void FightShouldThrowExeptionIfWarriorDeosntExist(string fighter, string defender)
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(fighter, defender));

            Warrior warrior = new Warrior(fighter, 10, 10);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(()
                => arena.Fight(fighter, defender));
        }

        [Test]
        public void FightShouldWorkAsExpected()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("Acho", 10, 50);
            Warrior defender = new Warrior("Mikto", 10, 50);
            arena.Enroll(warrior);
            arena.Enroll(defender);

            arena.Fight("Acho", "Mikto");

            var AchoHp = arena.Warriors.FirstOrDefault(w => w.Name == "Acho").HP;
            var MiktoHp = arena.Warriors.FirstOrDefault(w => w.Name == "Mikto").HP;

            Assert.AreEqual(AchoHp, 40);
            Assert.AreEqual(MiktoHp, 40);
        }
    }
}
