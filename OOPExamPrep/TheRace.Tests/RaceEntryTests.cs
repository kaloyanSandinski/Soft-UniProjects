using System;
using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;
using NUnit.Framework;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitDriver driver;
        private UnitCar car;
        private string name;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void When_RaceEntityCtorIsCalled_ShoudSetDictionary()
        {
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }

        [Test]
        public void When_AddDriverMethodIsCalledWithNullDriver_ShouldThrow()
        {
            driver = null;
            Assert.That(() => raceEntry.AddDriver(driver), Throws.InvalidOperationException.With.Message.EqualTo(string.Format("Driver cannot be null.")));
        }

        [Test]
        public void When_AddDriverMethodIsCalledWithExistingDriverName_ShouldThrow()
        {
            driver = new UnitDriver("Pesho", new UnitCar("model", 250, 500.34));
            raceEntry.AddDriver(driver);
            Assert.That(() => raceEntry.AddDriver(driver), Throws.InvalidOperationException.With.Message.EqualTo(String.Format("Driver {0} is already added.", driver.Name)));
        }

        [Test]
        public void When_AddDriverMethodIsCalledWithCorrectDriver_ShouldAddItToRepoAndReturnString()
        {
            driver = new UnitDriver("Pesho", new UnitCar("model", 250, 500.34));
            string output = String.Empty;
            output = raceEntry.AddDriver(driver);
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
            Assert.That(output, Is.EqualTo(String.Format("Driver {0} added in race.", driver.Name)));
        }

        [Test]
        public void When_CalculateAverageHorsePowerMethodIsCalledWithCounterLessThanMinParticipants_ShouldThrow()
        {
            Assert.That(()=>raceEntry.CalculateAverageHorsePower(), Throws.InvalidOperationException.With.Message.EqualTo(String.Format("The race cannot start with less than {0} participants.", 2)));
        }

        [Test]
        public void When_CalculateAverageHorsePowerMethodIsCalled_ShouldReturn()
        {
            driver = new UnitDriver("Pesho", new UnitCar("model", 250, 500.34));
            UnitDriver driver2 = new UnitDriver("Misho", new UnitCar("model", 250, 500.34));
            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver2);
            Assert.That(() => raceEntry.CalculateAverageHorsePower(),Is.EqualTo(250));
        }
    }
}