namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void CarSetup()
        {
            car = new("Volvo", "XC90", 4.5, 90);
        }

        [Test]
        public void CarConstructorShouldInitializeCorrectly()
        {
            Assert.IsNotNull(car);
        }

        [Test]
        public void MakeShouldWorkCorrectly()
        {
            string expectedMake = "Volvo";
            string actualMake = car.Make;
            Assert.AreEqual(expectedMake, actualMake);
        }

        [TestCase(null)]
        [TestCase("")]
        public void MakeShouldThrowIfNullOrEmpty(string make)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car(make, "XC90", 5, 90), "Make cannot be null or empty!");
        }

        [Test]
        public void ModelShouldWorkCorrectly()
        {
            string expectedModel = "XC90";
            string actualModel = car.Model;
            Assert.AreEqual(expectedModel, actualModel);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ModelShouldThrowIfNullOrEmpty(string model)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Seat", model, 5, 69), "Model cannot be null or empty!");
        }

        [Test]
        public void FuelConsumptionShouldWorkCorrectly()
        {
            double expectedConsumption = 4.5;
            double actualConsumption = car.FuelConsumption;
            Assert.AreEqual(expectedConsumption, actualConsumption);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-0.2)]
        public void FuelConsumptionShouldThrowIfZeroOrNegative(double consumption)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Seat", "Ibiza", consumption, 55), "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void FuelCapacityShouldWorkCorrectly()
        {
            double expectedAmount = 90;
            double actualAmount = car.FuelCapacity;
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestCase(-80)]
        [TestCase(0)]
        [TestCase(-0.4)]
        public void FuelCapacityShouldThrowIfNegative(double capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => new Car("Trabant", "500", 10, capacity), "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void InitialFuelAmountShouldBeZero()
        {
            double expectedAmount = 0;
            double actualAmount = car.FuelAmount;
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(55)]
        public void RefuelShouldIncreaseFuelAmountCorrectly(double amount)
        {
            car.Refuel(amount);
            double expectedAmount = amount;
            double actualAmount = car.FuelAmount;
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void RefuelShouldThrowIfRefuelAmountIsZeroOrNegative(double amount)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => car.Refuel(amount), "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void FuelAmountShouldNotExceedTheCapacity()
        {
            car.Refuel(100);
            double expectedAmount = 90;
            double actualAmount = car.FuelAmount;
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [TestCase(25.5, 30.3)]
        [TestCase(50, 50)]
        public void DriveMethodShouldDecreaseTheAmount(double distance, double amount)
        {
            car.Refuel(amount);
            car.Drive(distance);

            double fuelNeeded = distance / 100 * car.FuelConsumption;
            double expectedAmount = amount - fuelNeeded;
            double actualAmount = car.FuelAmount;
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        public void DriveMethodShouldThrowIfNotEnoughFuel()
        {
            car.Refuel(10);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => car.Drive(600), "You don't have enough fuel to drive!");
        }
    }
}
