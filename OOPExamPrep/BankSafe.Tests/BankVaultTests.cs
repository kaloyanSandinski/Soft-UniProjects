using NUnit.Framework;
using System;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;
        private string cell;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Pesho", "123123");
        }

        [Test]
        public void When_CtorIsCalled_ShouldMakeDictionary()
        {
            Assert.That(bankVault.VaultCells.Count, Is.EqualTo(12), "Dictionary should be with: 12 cells");
        }

        [Test]
        public void When_AddItemMethodIsCalled_WithNotExistingCell_ShouldThrow()
        {
            cell = "D5";
            Assert.That(() => bankVault.AddItem(cell, item), Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void When_AddItemMethodIsCalled_WithTakenCell_ShouldThrow()
        {
            bankVault.AddItem("A1", item);
            Assert.That(() => bankVault.AddItem("A1", item), Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));
        }

        [Test]
        public void When_AddItemMethodIsCalled_WithInsertedItem_ShouldThrow()
        {

            bankVault.AddItem("A1", item);
            Assert.That(() => bankVault.AddItem("B2", item), Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));
        }

        [Test]
        public void When_AddItemMethodIsCalled_ShouldSetCellValueAndReturnStr()
        {
            string returned = bankVault.AddItem("A1", item);
            Assert.That(returned, Is.EqualTo($"Item:{item.ItemId} saved successfully!"));
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(item));
        }

        [Test]
        public void When_RemoveItemIsCalled_WithNotExistingCell_ShouldThrow()
        {
            Assert.That(() => bankVault.RemoveItem("D5", item), Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void When_RemoveItemIsCalled_WithNotExistingItem_ShouldThrow()
        {
            bankVault.AddItem("A1", item);
            item = null;
            Assert.That(() => bankVault.RemoveItem("A1", item), Throws.ArgumentException.With.Message.EqualTo("Item in that cell doesn't exists!"));
        }

        [Test]
        public void When_RemoveItemIsCalled_ShouldReturnStrAndRemoveItem()
        {
            bankVault.AddItem("A1", item);
            string returned = bankVault.RemoveItem("A1", item);
            Assert.That(returned, Is.EqualTo($"Remove item:{item.ItemId} successfully!"));
            Assert.That(bankVault.VaultCells["A1"], Is.EqualTo(null));
        }
    }
}