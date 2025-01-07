namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;
        private Warrior enemy;

        [SetUp]
        public void SetUp()
        {
            warrior = new("Pesho", 25, 100);
            enemy = new("Gosho", 20, 100);
            arena = new();
            arena.Enroll(warrior);
            arena.Enroll(enemy);
        }

        [Test]
        public void ArenaShouldBeInitializedCorrectly()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void WarriorsCollectionShouldNotBeNull()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void WarriorsCollectionShouldReturnTheCorrectCount()
        {
            int expectedCount = 2;
            int actualCount = arena.Warriors.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CountPropertyShouldReturnTheCorrectValue()
        {
            int expectedCount = 2;
            int actualCount = arena.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollMethodShouldAddWarriorsProperly()
        {
            Warrior wrestler = new("Donovan", 20, 110);
            arena.Enroll(wrestler);
            int expectedCount = 3;
            int actualCount = arena.Warriors.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollMethodShouldThrowIfWarriorWithTheSameNameAdded()
        {
            Warrior wrestler = new("Gosho", 25, 50);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(wrestler), "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldWorkAsExpected()
        {
            arena.Fight("Pesho", "Gosho");
            int expectedPeshoHP = 80;
            int actualPeshoHP = warrior.HP;
            int expectedGoshoHP = 75;
            int actualGoshoHP = enemy.HP;
            Assert.AreEqual(expectedPeshoHP, actualPeshoHP);
            Assert.AreEqual(expectedGoshoHP, actualGoshoHP);
        }

        [Test]
        public void FightMethodShouldThrowIfDefenderIsNull()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Pesho", "Dimitrichko"), "There is no fighter with name Dimitrichko enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldThrowIfAttackerIsNull()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Fight("Rodriguez", "Gosho"), "There is no fighter with name Rodriguez enrolled for the fights!");
        }
    }
}
