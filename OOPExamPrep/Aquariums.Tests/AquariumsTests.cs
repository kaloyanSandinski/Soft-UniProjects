using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private string name = "NaPeshoaAkvariumcheto";
        private int capacity = 23;
        private Aquarium akvariumche;
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void When_CtorIsCalled_ShouldSetListOfFishes()
        {
            akvariumche = new Aquarium(name, capacity);
            Assert.That(akvariumche.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_TryToSetNullOrEmptyName_ShouldThrow()
        {
            name = String.Empty;
            Assert.That(() => akvariumche = new Aquarium(name, capacity), Throws.ArgumentNullException);
            string name2 = null;
            Aquarium akvariumche2;
            Assert.That(() => akvariumche2 = new Aquarium(name2, capacity), Throws.ArgumentNullException);
        }

        [Test]
        public void When_TryToSetNegativeCapacity_ShouldThrow()
        {
            capacity = -5;
            Assert.That(() => akvariumche = new Aquarium(name, capacity), Throws.ArgumentException.With.Message.EqualTo("Invalid aquarium capacity!"));
        }


        [Test]
        public void When_AddMethodIsCalledAndTankIsFull_ShouldThrow()
        {
            akvariumche = new Aquarium(name, 1);
            akvariumche.Add(new Fish("MishoRibeto"));
            Assert.That(() => akvariumche.Add(new Fish("Petio")), Throws.InvalidOperationException.With.Message.EqualTo("Aquarium is full!"));
        }

        [Test]
        public void When_AddMethodIsCalled_ShouldSet()
        {
            akvariumche = new Aquarium(name, capacity);
            akvariumche.Add(new Fish("Misho"));
            Assert.That(akvariumche.Count, Is.EqualTo(1));
        }

        [Test]
        public void When_RemoveMethodIsCalledWithNotExistingName_ShouldThrow()
        {
            akvariumche = new Aquarium(name, capacity);
            akvariumche.Add(new Fish("Micho"));
            Assert.That(() => akvariumche.RemoveFish("Peshi"), Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name Peshi doesn't exist!"));
        }

        [Test]
        public void When_RemoveMethodIsCalled_ShouldRemoveFish()
        {
            akvariumche = new Aquarium(name, capacity);
            akvariumche.Add(new Fish("Micho"));
            akvariumche.RemoveFish("Micho");
            Assert.That(akvariumche.Count, Is.EqualTo(0));
        }

        [Test]
        public void When_SellMethodIsCalledWithNotExistingName_ShouldThrow()
        {
            akvariumche = new Aquarium(name, capacity);
            akvariumche.Add(new Fish("Micho"));
            Assert.That(() => akvariumche.SellFish("Peshi"), Throws.InvalidOperationException.With.Message.EqualTo($"Fish with the name Peshi doesn't exist!"));
        }

        [Test]
        public void When_SellMethodIsCalled_ShouldReturnFish()
        {
            akvariumche = new Aquarium(name, capacity);
            akvariumche.Add(new Fish("Micho"));
            Fish fish = akvariumche.SellFish("Micho");
            Assert.That(fish.Available,Is.EqualTo(false));
        }

        [Test]
        public void When_ReportMethodIsCalled_ShouldReturnStr()
        {
            akvariumche = new Aquarium(name, capacity);
            akvariumche.Add(new Fish("Micho"));
            akvariumche.Add(new Fish("Pesho"));
            Assert.That(akvariumche.Report(),Is.EqualTo($"Fish available at {akvariumche.Name}: Micho, Pesho"));
        }
    }
}
