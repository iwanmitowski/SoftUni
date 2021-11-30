using NUnit.Framework;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2, 3);
        }

        [Test]
        public void ConstructorShouldCreateEmptyDatabaseCorrectly()
        {
            var db = new Database();

            Assert.IsNotNull(db);
        }

        [Test]
        public void ConstructorShouldCreateFilledDatabaseCorrectly()
        {
            var db = new Database(1, 2, 3);

            Assert.IsNotNull(db);
        }

        [Test]
        public void CountShouldWorksCorrectly()
        {
            int expected = 3;

            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void AddShouldWorksCorrectly()
        {
            database.Add(1);

            int expected = 4;

            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void AddShouldThrowIOExceptionWhenOverflowingCapacityCorrectly()
        {
            for (int i = 0; i < 13; i++)
            {
                database.Add(i);

            }

            Assert.Throws<InvalidOperationException>(() => database.Add(1));
        }

        [Test]
        public void FetchShouldReturnCorrectly()
        {
            int[] expected = new int[] { 1, 2, 3 };

            CollectionAssert.AreEqual(expected, database.Fetch());
        }

        [Test]
        public void RemoveShouldRemoveTheLastElement()
        {
            database.Remove();

            int[] expected = new int[] { 1, 2 };

            CollectionAssert.AreEqual(expected, database.Fetch());
        }

        [Test]
        public void RemoveFromEmptyCollectionThrowsIOException()
        {
            for (int i = 0; i < 3; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
    }
}