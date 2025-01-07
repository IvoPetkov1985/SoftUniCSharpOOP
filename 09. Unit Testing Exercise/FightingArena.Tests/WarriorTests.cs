namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void SetUp()
        {
            warrior = new("Peter", 10, 100);
        }

        [Test]
        public void WarriorShouldNotBeNull()
        {
            Assert.IsNotNull(warrior);
        }

        [Test]
        public void WarriorConstructorShouldInitializeCorrectly()
        {
            string expectedName = "Peter";
            int expectedDamage = 10;
            int expectedHP = 100;
            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void NamePropertyShouldWorkCorrectly()
        {
            string expectedName = "Peter";
            string actualName = warrior.Name;
            Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(null)]
        [TestCase("    ")]
        [TestCase(" ")]
        [TestCase("")]
        public void NameShouldThrowIfEmptyOrNull(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Warrior(name, 20, 30), "Name should not be empty or whitespace!");
        }

        [Test]
        public void DamageShouldWorkCorrectly()
        {
            int expectedDamage = 10;
            int actualDamage = warrior.Damage;
            Assert.AreEqual(expectedDamage, actualDamage);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void DamageShouldThrowIfZeroOrNegative(int damage)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Warrior("Dimitrichko", damage, 110), "Damage value should be positive!");
        }

        [Test]
        public void HPShouldWorkCorrectly()
        {
            int expectedHP = 100;
            int actualHP = warrior.HP;
            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase(-1)]
        [TestCase(-70)]
        public void HPShouldThrowIfNegative(int hp)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Warrior("Mitko", 25, hp), "HP should not be negative!");
        }

        [Test]
        public void AttackMethodShouldDecreaseEnemyHP()
        {
            Warrior enemy = new("Gosho", 12, 100);
            warrior.Attack(enemy);
            int expectedEnemyHP = 90;
            int actualEnemyHP = enemy.HP;
            Assert.AreEqual(expectedEnemyHP, actualEnemyHP);
        }

        [Test]
        public void AttackMethodShouldMakeEnemyHPZeroIfDamageIsBigger()
        {
            Warrior warrior = new("Misho", 40, 50);
            Warrior enemy = new("Gosho", 18, 38);
            warrior.Attack(enemy);
            int expectedEnemyHP = 0;
            int actualEnemyHP = enemy.HP;
            Assert.AreEqual(expectedEnemyHP, actualEnemyHP);
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(10)]
        public void AttackMethodShouldThrowIfEnemyHPIsBigger(int hp)
        {
            Warrior warrior = new("Misho", 20, hp);
            Warrior enemy = new("Gosho", 30, 40);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy), "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30)]
        [TestCase(29)]
        [TestCase(3)]
        public void AttackMethodShouldThrowIfEnemyHPIsTooLow(int hp)
        {
            Warrior warrior = new("Stamat", 15, 45);
            Warrior enemy = new("Gesha", 15, hp);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy), "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void AttackMethodShouldThrowIfHPSmallerThanEnemyDamage()
        {
            Warrior warrior = new("Stamat", 15, 45);
            Warrior enemy = new("Dimi", 50, 50);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => warrior.Attack(enemy), "You are trying to attack too strong enemy");
        }
    }
}
