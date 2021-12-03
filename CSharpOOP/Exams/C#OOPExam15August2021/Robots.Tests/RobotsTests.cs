namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;
        private Robot robot1;
        private Robot robot2;

        [SetUp]
        public void SetUp()
        {
            this.robotManager = new RobotManager(5);
            robot1 = new Robot("Ivan", 5);
            robot2 = new Robot("Pesho", 10);
            robotManager.Add(robot1);
            robotManager.Add(robot2);
        }

        [Test]
        public void ConstructorShouldBeSetCorrectly()
        {
            var robotMngr = new RobotManager(10);

            Assert.IsNotNull(robotMngr);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ConstructorShouldBeSetCorrectlyWithCorrectCapacity(int capacity)
        {
            var robotMngr = new RobotManager(capacity);

            Assert.AreEqual(capacity, robotMngr.Capacity);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(-3)]
        public void ConstructorShouldThrowExceptionIfCapacityIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(capacity));
        }

        [Test]
        public void CountReturnsCorrectly()
        {
            int expected = 2;

            Assert.AreEqual(expected, robotManager.Count);
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            var robot3 = new Robot("Misho", 15);

            robotManager.Add(robot3);

            int expected = 3;

            Assert.AreEqual(expected, robotManager.Count);
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        public void AddShouldThrowExceptionIfRobotNameExists(string name)
        {
            var robot = new Robot(name, 15);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void AddShouldThrowExceptionIfRobotCapacityIsOverflown()
        {
            for (int i = 0; i < 3; i++)
            {
                robotManager.Add(new Robot(i + "", 10));
            }

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(new Robot("Vasko", 15)));
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        public void RemoveShouldRemoveRobotCorrectly(string name)
        {
            robotManager.Remove(name);

            int expected = 1;

            Assert.AreEqual(expected, robotManager.Count);
        }

        [TestCase("Ivan1")]
        [TestCase("Pesh1o")]
        [TestCase("")]
        [TestCase(null)]
        public void RemoveShouldThrowExceptionIfNameIsInvalid(string name)
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(name));
        }

        [TestCase("Ivan1")]
        [TestCase("Pesh1o")]
        [TestCase("")]
        [TestCase(null)]
        public void WorkShouldThrowExceptionIfRobotDoesntExist(string name)
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(name, "job", 1));
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        public void WorkShouldThrowExceptionIfBatteryUsageIsMoreThanBattery(string name)
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(name, "job", 1000));
        }

        [TestCase("Ivan")]
        public void RobotBatteryShouldBeDecreasedAfterWork(string name)
        {
            robotManager.Work(name, "job", 1);

            var expected = 4;

            Assert.AreEqual(expected, robot1.Battery);
        }

        [TestCase("Ivan1")]
        [TestCase("Pesh1o")]
        [TestCase("")]
        [TestCase(null)]
        public void ChargeShouldThrowExceptionIfRobotDoesntExist(string name)
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(name));
        }

        [Test]
        public void ChargeShouldRechargeBatteryToTheMax()
        {
            for (int i = 0; i < 5; i++)
            {
                robotManager.Work(robot1.Name, "job", 1);
            }

            robotManager.Charge(robot1.Name);

            Assert.AreEqual(robot1.MaximumBattery, robot1.Battery);

        }
    }
}
