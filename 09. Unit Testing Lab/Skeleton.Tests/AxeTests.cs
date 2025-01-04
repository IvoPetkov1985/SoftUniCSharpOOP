using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Axe axe = new(15, 10);

            Assert.AreEqual(15, axe.AttackPoints);
            Assert.AreEqual(10, axe.DurabilityPoints);
        }

        [Test]
        public void DurabilityPointsShouldDecreaseWhenAxeUsed()
        {
            Axe axe = new(5, 7);
            Dummy dummy = new(15, 10);

            axe.Attack(dummy);
            Assert.That(6 == axe.DurabilityPoints);
        }

        [Test]
        public void DurabilityShouldThrowIfEqualOrBelowZero()
        {
            Axe axe = new(10, 2);
            Dummy dummy = new(100, 10);
            axe.Attack(dummy);
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken.");
        }
    }
}
