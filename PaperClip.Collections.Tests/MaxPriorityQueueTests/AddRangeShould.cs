using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaperClip.Collections.Tests.MaxPriorityQueueTests
{
    [TestClass]
    public class AddRangeShould
    {
        [TestMethod]
        public void MaintainMaxHeap()
        {
            var sut = new MaxPriorityQueue<int, int>();

            var random = new Random();
            var sortedResults = new List<int>();

            for (var i = 0; i < 50000; i++)
            {
                sortedResults.Add(random.Next(1000));
            }

            sut.AddRange(sortedResults, x => x);

            sortedResults = sortedResults.OrderByDescending(x => x).ToList();

            for (var i = 0; i < 50000; i++)
            {
                Assert.AreEqual(sut.Dequeue(), sortedResults[i]);
            }
        }
    }
}
