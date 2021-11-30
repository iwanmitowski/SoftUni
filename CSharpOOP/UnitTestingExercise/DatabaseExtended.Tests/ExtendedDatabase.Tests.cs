using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase database;
        Person[] people;
        Person person;

        [SetUp]
        public void Setup()
        {
            person = new Person(3, "Tosho");

            people = new Person[]
            {
                new Person(1, "Ivan"),
                new Person(2, "Gosho"),
            };

            database = new ExtendedDatabase(people);
        }

        [Test]
        public void EmptyDatabaseConstructorShouldWorkCorrectly()
        {
            var db = new ExtendedDatabase();
            Assert.IsNotNull(db);
        }

        [Test]
        public void ParamsDatabaseConstructorShouldWorkCorrectly()
        {
            var db = new ExtendedDatabase(people);
            Assert.IsNotNull(db);
        }

        [Test]
        public void CountShouldReturnCorrectValue()
        {
            int expected = 2;
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void AddShouldAddCorrectly()
        {
            database.Add(person);

            int expected = 3;

            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenAddingMoreThanCapacity()
        {

            for (int i = 0; i < 14; i++)
            {
                database.Add(new Person(i + 10, $"Ivan{i}"));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [TestCase("Tosho")]
        [TestCase("Ivan")]
        [TestCase("Gosho")]
        public void AddShouldThrowExceptionWhenAddingSameUserName(string name)
        {
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(5, name)));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void AddShouldThrowExceptionWhenAddingSameId(long id)
        {
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(id, "Pavlin")));
        }

        [Test]

        public void AddRangeMethodShoudlThrowExceptionWhenProvidedDataLengthIsOutOfRange()
        {
            var ppl = new List<Person>();

            for (int i = 0; i < 18; i++)
            {
                ppl.Add(new Person(i + 10, $"Ivan{i}"));
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(ppl.ToArray()));
        }

        [Test]
        public void RemoveShouldRemoveCorrectly()
        {
            database.Remove();

            int expected = 1;

            Assert.AreEqual(expected,database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            for (int i = 0; i < 2; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase("Ivan")]
        [TestCase("Gosho")]
        [TestCase("Tosho")]
        public void FindByUsernameShouldReturnUser(string username)
        {
            database.Add(person);

            var expected = database.FindByUsername(username);

            Assert.IsNotNull(expected);
        }

        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShouldThrowExceptionIfUsernameIsNullOrEmpty(string username)
        {
            Assert.Throws<ArgumentNullException>(()=> database.FindByUsername(username));
        }

        [TestCase("Viki")]
        [TestCase("Pavlin")]
        public void FindByUsernameShouldThrowExceptionIfUsernameIsNotPresent(string username)
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));
        }

        [TestCase("Ivan")]
        [TestCase("Gosho")]
        [TestCase("Tosho")]
        public void FindByUsernameShouldReturnValidUser(string username)
        {
            database.Add(person);

            var expected = database.FindByUsername(username);

            Assert.IsNotNull(expected);
        }

        [TestCase(-1)]
        [TestCase(-2)]
        public void FindByIdShouldThrowExceptionIfIdIsNegative(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        public void FindByIdShouldThrowExceptionIfUserIsNotPresent(long id)
        {
            database.Add(person);

            Assert.Throws<InvalidOperationException>(() => database.FindById(id));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void FindByIdShouldReturnValidUser(long id)
        {
            database.Add(person);

            var expected = database.FindById(id);

            Assert.IsNotNull(expected);
        }
    }
}