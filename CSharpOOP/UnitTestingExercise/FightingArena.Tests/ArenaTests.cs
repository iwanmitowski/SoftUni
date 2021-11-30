using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private const string AttackerName = "Ivan";
        private const string DefenderName = "Pesho";
        private const int HP = 100;
        private const int Damage = 30;

        private Arena arena;
        public Warrior attacker;
        public Warrior defender;


        [SetUp]
        public void Setup()
        {
            arena = new Arena();

            attacker = new Warrior(AttackerName, Damage, HP);
            defender = new Warrior(DefenderName, Damage, HP);

            arena.Enroll(attacker);
            arena.Enroll(defender);
        }

        [Test]
        public void ConstructorShouldSetCorrectly()
        {
            var test = new Arena();

            Assert.IsNotNull(test);
        }

        [Test]
        public void EnrollShouldAddCorrectly()
        {
            int expected = 2;

            Assert.AreEqual(expected, arena.Warriors.Count);

        }

        [Test]
        public void CountShouldReturnCorrectly()
        {
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
        }

        [Test]
        public void EnrollShouldThrowExceptionIfWarriorIsContained()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(attacker));
        }

        [TestCase(AttackerName, "Tosho")]
        [TestCase(DefenderName, "Mosho")]
        public void FightShouldThrowExceptionIfAttackerIsContained(string attacker, string defender)
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));
        }

        [TestCase("Tosho", AttackerName)]
        [TestCase("Mosho", DefenderName)]
        public void FightShouldThrowExceptionIfDefenderIsContained(string attacker, string defender)
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));
        }

        [Test]
        public void DefenderShouldTakeDamage()
        {
            arena.Fight(AttackerName, DefenderName);

            int expected = 70;

            Assert.AreEqual(expected, defender.HP);
        }
    }
}
