using System;
using NUnit.Framework;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person person;
        private int id = 123123;
        private string name = "Pesho";
        private Person[] persons;
        private ExtendedDatabase database;
        [SetUp]
        public void SetUp()
        {
            person = new Person(id, name);
            persons = new Person[] { new Person(123124, "Pesho"), new Person(124132, "Gosho"), new Person(421231, "Tisho") };
            database = new ExtendedDatabase();
        }

        [Test]
        public void When_PersonCtorIsCalled_ShouldSetCorrectNameId()
        {
            Assert.That(person.UserName,Is.EqualTo(name), "Name should be Pesho!");
            Assert.That(person.Id,Is.EqualTo(id), "User ID should be 123123!");
        }

        [Test]
        public void When_ExtendedDatabaseCtorIsCalled_ShouldMakeCorrectArr()
        {
            database = new ExtendedDatabase(persons);
            Assert.That(database.Count, Is.EqualTo(persons.Length));
        }

        [Test]
        public void When_AddRangeIsCalledAndCountGreatherThan_ShouldThrow()
        {
            persons = new Person[18];
            Assert.That(()=>database = new ExtendedDatabase(persons), Throws.ArgumentException.With.Message.EqualTo("Provided data length should be in range [0..16]!"));
        }

        [Test]
        public void When_AddMethodIsCalledAndCountIsIncorrect_ShouldThrow()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, $"Person{i}"));
            }
            Assert.That(() => database.Add(new Person(16, "Invalid user!")), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_AddMethodIsCalledWithUsedUsername_ShouldThrow()
        {
            database.Add(person);
            Assert.That(()=>database.Add(new Person(123125, "Pesho")),Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void When_AddMethodIsCalledWithUsedId_ShouldThrow()
        {
            database.Add(person);
            Assert.That(() => database.Add(new Person(123123, "Misho")), Throws.InvalidOperationException.With.Message.EqualTo("There is already user with this Id!"));
        }

        [Test]
        public void When_AddMethodIsCalledCorrectly_ShouldIncreaseCounter()
        {

            int counter = database.Count;
            database.Add(person);
            Assert.That(database.Count,Is.EqualTo(counter+1));
        }

        [Test]
        public void When_RemoveMethodIsCalledWithZeroCount_ShoudThrow()
        {
            Assert.That(()=>database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        public void When_RemoveMethodIsCalled_ShouldDecreaseCountAndSetToNull()
        {
            database.Add(person);
            int databaseCount = database.Count;
            database.Remove();
            Assert.That(database.Count,Is.EqualTo(databaseCount-1));
            Assert.That(()=>database.FindById(123123), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_FindByUsernameIsCalledWithEmptyString_ShouldThrow(string username)
        {
            Assert.That(()=>database.FindByUsername(username), Throws.ArgumentNullException);
        }

        [Test]
        public void When_FindByUsernameIsCalledForNotPresentedUser_ShouldThrow()
        {
            Assert.That(()=>database.FindByUsername("Misho"), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void When_FindByUsernameIsCalledCorrectly_ShouldReturnUser()
        {
            database.Add(person);
            Assert.That(database.FindByUsername("Pesho").UserName,Is.EqualTo(person.UserName));
        }

        [Test]
        public void When_FindByNegativeID_ShouldThrow()
        {
            Assert.That(()=>database.FindById(-123), Throws.Exception);
        }

        [Test]
        public void When_FindByIDUserIsNotPresented_ShouldThrow()
        {
            database.Add(person);
            Assert.That(()=>database.FindById(123), Throws.InvalidOperationException.With.Message.EqualTo("No user is present by this ID!"));
        }

        [Test]
        public void When_FindByIdUserIsPresentes_ShouldReturnUser()
        {
            database.Add(person);
            Assert.That(database.FindById(person.Id).UserName, Is.EqualTo(person.UserName));
        }
    }
}