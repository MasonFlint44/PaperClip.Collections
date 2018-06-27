using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaperClip.Collections.Tests.PrioritySetTests
{
    [TestClass]
    public class ContainsShould
    {
        [TestMethod]
        public void ReturnTrueIfSetContainsValue()
        {
            var sut = new MinPrioritySet<int, int, int>();
            var random = new Random();

            for (var i = 0; i < 50000; i++)
            {
                sut.Enqueue(i, i, i);
            }

            Assert.IsTrue(sut.Contains(random.Next(50000)));
        }

        [TestMethod]
        public void ReturnFalseIfSetDoesNotContainValue()
        {
            var sut = new MinPrioritySet<int, int, int>();

            for (var i = 0; i < 50000; i++)
            {
                sut.Enqueue(i, i, i);
            }

            Assert.IsFalse(sut.Contains(50000));
        }
    }
}
