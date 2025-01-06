namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        Person person;
        Person person2;
        Database database;

        [SetUp]
        public void Setup()
        {
            person = new(144511333444, "Dimitrichko");
            person2 = new(144511345999, "Goshko");
            database = new(person, person2);
        }

        [Test]
        public void PersonConstructorShouldInitializeCorrectly()
        {
            Assert.IsNotNull(person);

            long expectedPersonId = 144511333444;
            string expectedPersonUserName = "Dimitrichko";

            Assert.AreEqual(expectedPersonId, person.Id);
            Assert.AreEqual(expectedPersonUserName, person.UserName);
        }

        [Test]
        public void PersonUserNameShouldBeCorrect()
        {
            string expectedUserName = "Dimitrichko";

            Assert.AreEqual(expectedUserName, person.UserName);
        }

        [Test]
        public void PersonIdShouldBeCorrect()
        {
            long expectedId = 144511333444;

            Assert.AreEqual(expectedId, person.Id);
        }

        [Test]
        public void DatabaseShouldInitializeCorrectly()
        {
            Assert.IsNotNull(database);

            int expectedCount = 2;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void CountGetterShouldWorkCorrectly()
        {
            database.Add(new Person(144511333898, "Peter"));

            int expectedCount = 3;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CreatingDatabaseShouldAddPeopleCorrectly()
        {
            Person person3 = new(144511333898, "Peter");
            Person person4 = new(155144333999, "Ivan");
            Person person5 = new(145122555612, "Ani");

            Database database = new(person3, person4, person5);

            int expectedCount = 3;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void CreatingDatabaseShouldThrowIfPeopleOver16()
        {
            Person[] people =
            {
                new Person(144555989100, "Ivan"),
                new Person(144555989101, "Peter"),
                new Person(144555989102, "Andrei"),
                new Person(144555989103, "Sasho"),
                new Person(144555989104, "Cecka"),
                new Person(144555989105, "Ivanka"),
                new Person(144555989201, "Cvetanka"),
                new Person(144555989110, "Nasko"),
                new Person(144555989133, "Dimi"),
                new Person(144555989116, "Dzhimi"),
                new Person(144555989166, "Borat"),
                new Person(144555989177, "Albena"),
                new Person(144566339177, "Boian"),
                new Person(144555989189, "Petkan"),
                new Person(144555989161, "Mitko"),
                new Person(144555989444, "Vesko"),
                new Person(144555989334, "Ivo"),
            };

            ArgumentException ex = Assert.Throws<ArgumentException>(() => database = new Database(people), "Provided data length should be in range [0..16]!");
        }

        [Test]
        public void AddMethodShouldIncreaseTheCounter()
        {
            database.Add(new Person(155144555666, "Jovcho"));

            int expectedCount = 3;
            int actualCount = database.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddMethodShouldThrowIfCountIs16()
        {
            Person[] people =
            {
                new Person(144555989100, "Ivan"),
                new Person(144555989101, "Peter"),
                new Person(144555989102, "Andrei"),
                new Person(144555989103, "Sasho"),
                new Person(144555989104, "Cecka"),
                new Person(144555989105, "Ivanka"),
                new Person(144555989201, "Cvetanka"),
                new Person(144555989110, "Nasko"),
                new Person(144555989133, "Dimi"),
                new Person(144555989116, "Dzhimi"),
                new Person(144555989166, "Borat"),
                new Person(144555989177, "Albena"),
                new Person(144566339177, "Boian"),
                new Person(144555989189, "Petkan"),
                new Person(144555989161, "Mitko"),
                new Person(144555989444, "Vesko"),
            };

            Database database = new(people);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1441229899999, "Simeon")), "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void AddMethodShouldThrowIfNameExists()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(144555444141, "Dimitrichko")), "There is already user with this username!");
        }

        [Test]
        public void AddMethodShouldThrowIfIdExists()
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(144511333444, "Ivancho")), "There is already user with this Id!");
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            database.Remove();

            int expected = 1;
            int actual = database.Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RemoveMethodShouldThrowIfCountIsZero()
        {
            database.Remove();
            database.Remove();

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameShouldReturntheCorrectPerson()
        {
            Assert.AreEqual(person, database.FindByUsername("Dimitrichko"));
            Assert.AreEqual(person2, database.FindByUsername("Goshko"));
        }

        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShouldThrowIfUsernameIsNullOrEmpty(string name)
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name), "Username parameter is null!");
        }

        [TestCase("Ivcho")]
        [TestCase("Penka")]
        public void FindByUsernameShouldThrowIfUsernameIsNonExisting(string name)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindByUsername(name), "No user is present by this username!");
        }

        [Test]
        public void FindByIdMethodShouldReturnTheCorrectObject()
        {
            Assert.AreEqual(person, database.FindById(144511333444));
        }

        [TestCase(-144511333444)]
        [TestCase(-10)]
        public void FindByIdMethodShouldThrowIfIdIsNegative(long id)
        {
            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id), "Id should be a positive number!");
        }

        [TestCase(133414555566)]
        [TestCase(144511333445)]
        public void FindByIdMethodShouldThrowIfIdIsNonExisting(long id)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindById(id), "No user is present by this ID!");
        }
    }
}
