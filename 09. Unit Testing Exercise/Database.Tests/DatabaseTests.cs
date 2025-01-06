namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new(new int[] { 1, 2, 3, 4, 5 });
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            Assert.IsNotNull(database);
        }

        [Test]
        public void CountPropertyShouldReturnTheCorrectValue()
        {
            int expectedValue = 5;
            int actualValue = database.Count;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void AddMehodShouldAddElementsCorrectly(int[] numbers)
        {
            Database database = new();

            for (int i = 0; i < numbers.Length; i++)
            {
                database.Add(numbers[i]);
            }

            Assert.AreEqual(numbers, database.Fetch());
        }

        [Test]
        public void AddMethodShouldThrowIfCountOver16()
        {
            for (int i = 0; i < 11; i++)
            {
                database.Add(i);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Add(17), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldIncreaseCountCorrectly()
        {
            database.Add(10);
            database.Add(15);

            int expextedCount = 7;
            int actualCount = database.Count;

            Assert.AreEqual(expextedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            database.Remove();
            database.Remove();

            int expectedCount = 3;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveMethodShouldThrowIfCollectionIsEmpty()
        {
            for (int i = 0; i < 5; i++)
            {
                database.Remove();
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => database.Remove(), "The collection is empty!");
        }

        [Test]
        public void FetchMethodShouldReturnTheCorrectArray()
        {
            int[] expectedArray = { 1, 2, 3, 4, 5 };
            int[] actualArray = database.Fetch();

            Assert.AreEqual(expectedArray, actualArray);
        }
    }
}
