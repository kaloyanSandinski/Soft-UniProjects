using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;
        [SetUp]
        public void Setup()
        {
            database = new Database.Database();
        }

        [Test]
        public void When_AddMoreThanCorectSize_ShouldThrow()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }
            Assert.That(()=> database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void When_CtorIsCalled_ShouldMakeArrWithCorrectSize()
        {
            var input = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            database = new Database.Database(input);
            Assert.That(database.Count,Is.EqualTo(input.Length),$"Should be with lenght: {input.Length}!");
            Assert.That(database.Fetch(), Is.EquivalentTo(input),"Should be the same arr");
        }

        [Test]
        public void When_Add_ShouldIncreaseCountOfData()
        {
            database.Add(123);
            Assert.That(database.Count,Is.EqualTo(1),"Database shoud increase it's value");
        }

        [Test]
        public void When_Add_ShouldAddOnTheNextFreeCell()
        {
            Stack<int> integerStack = new Stack<int>();
            integerStack.Push(2);
            database.Add(2);
            var output = database.Fetch();
            Assert.That(output[output.Length-1],Is.EqualTo(integerStack.Peek()), "Should add to the next free cell!");
        }

        [Test]
        public void When_RemoveMethodIsCalled_ShouldDecreseCountValue()
        {
            for (int i = 0; i < 3; i++)
            {
                database.Add(i);
            }
            int count = database.Count;
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(count-1));
        }

        [Test]
        public void When_RemoveMethodIsCalled_ShoudRemoveTheLastElement()
        {
            for (int i = 0; i < 3; i++)
            {
                database.Add(i);
            }
            database.Remove();
            var output = database.Fetch();
            Assert.That(output[output.Length-1],Is.EqualTo(1),"Shoud remove the last item!");
        }

        [Test]
        public void When_RemoveMethodIsCalled_WithZeroCount_ShouldThrow()
        {
            Assert.That(()=>database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [Test]
        public void When_FetchMethodIsCalled_ShoudReturnCorrectArr()
        {
            int[] checker = new int[3];
            for (int i = 0; i < 3; i++)
            {
                checker[i] = i;
                database.Add(i);
            }
            Assert.That(database.Fetch(),Is.EqualTo(checker), "Not the same arrays!");
        }
    }
}