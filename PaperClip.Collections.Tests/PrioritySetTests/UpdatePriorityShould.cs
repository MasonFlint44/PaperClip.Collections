using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaperClip.Collections.Tests.PrioritySetTests
{
    [TestClass]
    public class UpdatePriorityShould
    {
        [TestMethod]
        public void UpdatePriorityInQueue()
        {
            var sut = new MinPrioritySet<int, int, int>();
            var random = new Random();

            for (var i = 1; i < 50000; i++)
            {
                sut.Enqueue(i, i, i);
            }

            var index = random.Next(50000);
            sut.UpdatePriority(index, 0);

            Assert.AreEqual(index, sut.Dequeue());
        }
    }
}
