using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Dummy dummy = new(0, 5);

            Assert.That(0 == dummy.Health);
            Assert.That(5 == dummy.GiveExperience());
        }

        [Test]
        public void TakeAttackShouldDecreaseHealth()
        {
            Dummy dummy = new(8, 5);
            dummy.TakeAttack(3);
            Assert.AreEqual(5, dummy.Health);
        }

        [Test]
        public void TakeAttackShouldThrowIfDummyIsDead()
        {
            Dummy dummy = new(5, 5);
            dummy.TakeAttack(5);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5), "Dummy is dead.");
        }

        [Test]
        public void TakeAttackShouldKillIfBiggerThanHealth()
        {
            Dummy dummy = new(5, 5);
            dummy.TakeAttack(7);

            Assert.IsTrue(dummy.IsDead());
        }

        [Test]
        public void GiveExperienceShouldThrowIfDummyIsNotDead()
        {
            Dummy dummy = new(5, 5);
            dummy.TakeAttack(2);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }

        [Test]
        [TestCase(7, 7)]
        [TestCase(1, 1)]
        public void GiveExperienceShouldReturnResultIfDead(int expected, int actual)
        {
            Dummy dummy = new(10, actual);
            dummy.TakeAttack(5);
            dummy.TakeAttack(6);

            Assert.That(expected.Equals(actual));
        }

        [Test]
        public void IsDeadShouldReturnTrueIfDead()
        {
            Dummy dummy = new(10, 5);
            dummy.TakeAttack(10);

            Assert.IsTrue(dummy.IsDead());
        }

        [Test]
        public void IsDeadShouldReturnFalseIfNotDead()
        {
            Dummy dummy = new(10, 10);

            Assert.IsFalse(dummy.IsDead());
        }
    }
}
