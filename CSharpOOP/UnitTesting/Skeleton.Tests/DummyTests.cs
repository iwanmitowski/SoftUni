using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        const int axeDmg = 1;
        const int axeDurability = 11;
        const int dummyHealth = 10;
        const int dummyExp = 10;

        Axe axe;
        Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(axeDmg, axeDurability);
            dummy = new Dummy(dummyHealth, dummyExp);
        }

        [Test]
        public void DummyLosesHpWhenAttacked()
        {
            axe.Attack(dummy);

            int expected = 9;

            Assert.AreEqual(expected, dummy.Health);
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            for (int i = 0; i < 10; i++)
            {
                axe.Attack(dummy);
            }

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));
        }

        [Test]
        public void DeadDummyGivesExp()
        {
            for (int i = 0; i < 10; i++)
            {
                axe.Attack(dummy);
            }

            var expected = 10;
            var expectedExp = dummy.GiveExperience();

            Assert.AreEqual(expected, expectedExp);
        }

        [Test]
        public void AliveDummyCantGiveExp()
        {
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}