using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Gym gym;
        private Athlete athlete1;
        private Athlete athlete2;
        private Athlete athlete3;
        
        [SetUp]
        public void Setup()
        {
            gym = new Gym("Gym", 4);

            athlete1 = new Athlete("Ivan");
            athlete2 = new Athlete("Pesho");
            athlete3 = new Athlete("Gosho");

            gym.AddAthlete(athlete1);
            gym.AddAthlete(athlete2);
        }

        [Test]
        public void ConstructorShouldTestCorrectly()
        {
            var gym = new Gym("ime", 10);

            Assert.IsNotNull(gym);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, 10));
        }

        [TestCase(-1)]
        [TestCase(-2)]
        public void ShouldThrowExceptionIfCapacityIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Gym("ime", capacity));
        }

        [Test]
        public void CountReturnsCorrectly()
        {
            int expected = 2;

            Assert.AreEqual(expected, gym.Count);
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            int expected = 3;
            gym.AddAthlete(athlete3);

            Assert.AreEqual(expected, gym.Count);
        }

        [Test]
        public void AddAtheleteShouldThrowExceptionIfIsMoreThanCapacity()
        {
            for (int i = 0; i < 2; i++)
            {
                gym.AddAthlete(new Athlete("ime" + i));
            }

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete3));
        }

        [TestCase("Ivan")]
        [TestCase("Pesho")]
        [TestCase("Gosho")]
        public void RemoveShouldRemoveCorrectly(string name)
        {
            gym.AddAthlete(athlete3);

            gym.RemoveAthlete(name);

            int expected = 2;

            Assert.AreEqual(expected, gym.Count);
        }

        [TestCase("asd")]
        [TestCase("as12312321")]
        [TestCase("Vasko")]
        public void GymShouldThrowExceptionIfAthleteDoesntExist(string name)
        {
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete(name));
        }

        [Test]
        public void InjureAthleteWorksCorrectly()
        {
            gym.InjureAthlete("Pesho");

            Assert.IsTrue(athlete2.IsInjured);
        }

        [Test]
        public void InjureAthleteShouldReturnCorrectAthlete()
        {
            gym.InjureAthlete("Pesho");

            Assert.AreEqual(athlete2, gym.InjureAthlete("Pesho"));
        }

        [TestCase("asd")]
        [TestCase("as12312321")]
        [TestCase("Vasko")]
        public void InjureShouldThrowExceptionIfAthleteDoesntExist(string name)
        {
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(name));
        }

        [Test]
        public void ActiveAthletesShouldReturnCorrectReport()
        {
            string report = $"Active athletes at {gym.Name}: {athlete1.FullName}, {athlete2.FullName}";

            Assert.AreEqual(report, gym.Report());
        }

        [Test]
        public void ActiveAthletesShouldReturnCorrectReportWithInjuredAthlete()
        {
            gym.InjureAthlete("Pesho");

            string report = $"Active athletes at {gym.Name}: {athlete1.FullName}";

            Assert.AreEqual(report, gym.Report());
        }
    }
}
