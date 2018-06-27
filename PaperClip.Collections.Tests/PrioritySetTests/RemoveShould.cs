using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaperClip.Collections.Tests.PrioritySetTests
{
    [TestClass]
    public class RemoveShould
    {
        [TestMethod]
        public void ReturnTrueIfSetContainsKey()
        {
            var sut = new MinPrioritySet<int, int, int>();
            var random = new Random();

            for (var i = 0; i < 50000; i++)
            {
                sut.Enqueue(i, i, i);
            }

            Assert.IsTrue(sut.Remove(random.Next(50000)));
        }

        [TestMethod]
        public void ReturnFalseIfSetDoesNotContainValue()
        {
            var sut = new MinPrioritySet<int, int, int>();

            for (var i = 0; i < 50000; i++)
            {
                sut.Enqueue(i, i, i);
            }

            Assert.IsFalse(sut.Remove(50000));
        }

        [TestMethod]
        public void DecrementCountOfSet()
        {
            var sut = new MinPrioritySet<int, int, int>();
            var random = new Random();

            for (var i = 0; i < 50000; i++)
            {
                sut.Enqueue(i, i, i);
            }

            sut.Remove(random.Next(50000));

            Assert.AreEqual(49999, sut.Count);
        }

        [TestMethod]
        public void RemoveKeyFromSet()
        {
            var sut = new MinPrioritySet<int, int, int>();
            var random = new Random();

            for (var i = 0; i < 50000; i++)
            {
                sut.Enqueue(i, i, i);
            }

            var index = random.Next(50000);
            sut.Remove(index);

            Assert.IsFalse(sut.Contains(index));
        }
    }
}
