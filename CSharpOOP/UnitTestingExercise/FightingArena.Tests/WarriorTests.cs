using NUnit.Framework;
using System;
namespace Tests
{
    public class WarriorTests
    {
        Warrior warrior;
        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("Ivan", 30, 30);
        }

        [Test]
        public void ConstructorShouldWorkCorectly()
        {
            string name = "Ivan";
            int hp = 30;
            int dmg = 30;
            Assert.That(name, Is.EqualTo(this.warrior.Name));
            Assert.That(dmg, Is.EqualTo(this.warrior.Damage));
            Assert.That(hp, Is.EqualTo(this.warrior.HP));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("     ")]
        public void WarriorsNameCantBeNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 30, 30));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void WarriorDamageCantBeZeroOrLess(int dmg)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", dmg, 30));

        }


        [TestCase(-1)]
        [TestCase(-3)]
        public void WarriorHpCantBeZeroOrLess(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 30, hp));

        }

        [Test]
        public void WarriorAttackWorkingCorectly()
        {
            Warrior attacker = new Warrior("Ivan", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            attacker.Attack(defender);

            int expectedAttackerHP = 95;
            int expectedDefenderHP = 40;

            Assert.That(attacker.HP, Is.EqualTo(expectedAttackerHP));
            Assert.That(defender.HP, Is.EqualTo(expectedDefenderHP));
        }

        [TestCase(30)]
        [TestCase(20)]
        public void AttackerCantAttackWithLessThan30Hp(int hp)
        {
            Warrior attacker = new Warrior("Ivan", 10, hp);
            Warrior defender = new Warrior("Gosho", 5, 50);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [TestCase(30)]
        [TestCase(20)]
        public void DefencerCantBeAttackedWithLessOrEqualTo30Hp(int hp)
        {
            Warrior attacker = new Warrior("Ivan", 10, 50);
            Warrior defender = new Warrior("Gosho", 5, hp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void DefenderCantBeStrongerThanAttacker()
        {
            Warrior attacker = new Warrior("Ivan", 10, 50);
            Warrior defender = new Warrior("Gosho", 60, 30);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void EnemyHpShouldBeSetTo0AfterGreaterAttack()
        {
            Warrior attacker = new Warrior("Ivan", 50, 100);
            Warrior defender = new Warrior("Gosho", 30, 31);

            attacker.Attack(defender);

            int expectedDefenderHP = 0;

            Assert.That(defender.HP, Is.EqualTo(expectedDefenderHP));
        }

    }
}