using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaperClip.Collections.Tests.MinPriorityQueueTests
{
    [TestClass]
    public class SortShould
    {
        [TestMethod]
        public void SortByDescendingPriority()
        {
            var sut = new MinPriorityQueue<int, int>();
            var random = new Random();
            var sortedResults = new List<int>();

            for (var i = 0; i < 50000; i++)
            {
                var randomValue = random.Next(1000);
                sortedResults.Add(randomValue);
                sut.Enqueue(randomValue, randomValue);
            }
            sortedResults = sortedResults.OrderByDescending(x => x).ToList();

            var results = sut.Sort().ToList();

            CollectionAssert.AreEqual(sortedResults, results);
        }
    }
}
