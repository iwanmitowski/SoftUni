using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        const int axeDmg = 5;
        const int axeDurability = 1;
        const int dummyHealth = 10;
        const int dummyExp = 10;

        Axe axe;
        Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(axeDmg, axeDurability);
            dummy = new Dummy( dummyHealth, dummyExp);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            int expected = 0;

            Assert.AreEqual(expected, axe.DurabilityPoints);
        }

        [Test]
        public void AxeShouldThrowIOEWhenAttacking()
        {
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}