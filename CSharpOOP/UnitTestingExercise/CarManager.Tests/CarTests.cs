using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private const string Make = "Mercedes";
        private const string Model = "C180";
        private const double FuelConsumption = 10;
        private const double FuelCapacity = 50;

        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car(Make, Model, FuelConsumption, FuelCapacity);
        }

        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            var car = new Car(Make, Model, FuelConsumption,FuelCapacity);
            Assert.IsNotNull(car);
        }

        [TestCase("")]
        [TestCase(null)]
        public void InvalidMakeShouldThorwArgumentException(string value)
        {
            Assert.Throws<ArgumentException>(()=> new Car(value, Model, FuelConsumption, FuelCapacity));
        }

        

        [TestCase("")]
        [TestCase(null)]
        public void InvalidModelShouldThorwArgumentException(string value)
        {
            Assert.Throws<ArgumentException>(() => new Car(Make, value, FuelConsumption, FuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void InvalidFuelConsumptionShouldThorwArgumentException(double value)
        {
            Assert.Throws<ArgumentException>(() => new Car(Make, Model, value, FuelCapacity));
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void InvalidFuelCapacityShouldThorwArgumentException(double value)
        {
            Assert.Throws<ArgumentException>(() => new Car(Make, Model, FuelConsumption, value));
        }

        [Test]
        public void ValidMakeShouldBeSetCorrectly()
        {
            Assert.AreEqual(Make, car.Make);
        }

        [Test]
        public void ValidModelShouldBeSetCorrectly()
        {
            Assert.AreEqual(Model, car.Model);
        }

        [Test]
        public void ValidFuelConsumptionShouldBeSetCorrectly()
        {
            Assert.AreEqual(FuelConsumption, car.FuelConsumption);
        }

        [Test]
        public void ValidFuelCapacityShouldBeSetCorrectly()
        {
            Assert.AreEqual(FuelCapacity, car.FuelCapacity);
        }

        [TestCase(0)]
        [TestCase(-2)]
        public void InvalidRefuelShouldThorwArgumentException(double value)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(value));
        }

        [TestCase(2)]
        [TestCase(3)]
        public void RefuelShouldWorksCorrectly(double value)
        {
            car.Refuel(value);

            var expected = value;

            Assert.AreEqual(expected,car.FuelAmount);
        }

        [TestCase(69)]
        [TestCase(420)]
        public void RefuelShouldBeSetToMaxWhenOverRefueling(double value)
        {
            car.Refuel(value);

            var expected = FuelCapacity;

            Assert.AreEqual(expected, car.FuelAmount);
        }

        [Test]
        public void DriveShouldWorksCorrectly()
        {
            car.Refuel(50);
            car.Drive(100);

            var expected = 40;

            Assert.AreEqual(expected, car.FuelAmount);
        }

        [Test]
        public void DriveShouldThrowExceptionIfNotEnoughFuel()
        {
            car.Refuel(5);

            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }
    }
}