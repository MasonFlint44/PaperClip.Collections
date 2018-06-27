using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaperClip.Collections.Tests.MaxPriorityQueueTests
{
    [TestClass]
    public class EnumeratorShould
    {
        [TestMethod]
        public void EnumerateValuesMaxFirst()
        {
            var sut = new MaxPriorityQueue<int, int>();
            var random = new Random();
            var sortedResults = new List<int>();

            for (var i = 0; i < 50000; i++)
            {
                var randomValue = random.Next(1000);
                sortedResults.Add(randomValue);
                sut.Enqueue(randomValue, randomValue);
            }
            sortedResults = sortedResults.OrderByDescending(x => x).ToList();

            var j = 0;
            foreach (var result in sut)
            {
                Assert.AreEqual(sortedResults[j], result);
                j++;
            }
        }
    }
}
