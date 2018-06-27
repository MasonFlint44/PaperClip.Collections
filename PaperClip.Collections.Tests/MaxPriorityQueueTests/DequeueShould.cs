using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaperClip.Collections.Enums;

namespace PaperClip.Collections.Tests.MaxPriorityQueueTests
{
    [TestClass]
    public class DequeueShould
    {
        [TestMethod]
        public void DequeueMaxValue()
        {
            var sut = new MaxPriorityQueue<int, int>();

            for (var i = 0; i < 50000; i++)
            {
                sut.Enqueue(i, i);
            }

            for (var i = 49999; i >= 0; i--)
            {
                Assert.AreEqual(i, sut.Dequeue());
            }
        }

        [TestMethod]
        public void PrioritizeInALifoManner()
        {
            var sut = new MaxPriorityQueue<int, int>(Stability.Lifo);

            for (var i = 0; i < 10000; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    sut.Enqueue(i, i * 5 + j);
                }
            }

            for (var i = 9999; i >= 0; i--)
            {
                for (var j = 4; j >= 0; j--)
                {
                    Assert.AreEqual(i * 5 + j, sut.Dequeue());
                }
            }
        }

        [TestMethod]
        public void PrioritizeInAFifoManner()
        {
            var sut = new MaxPriorityQueue<int, int>(Stability.Fifo);

            for (var i = 0; i < 10000; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    sut.Enqueue(i, i * 5 + j);
                }
            }

            for (var i = 9999; i >= 0; i--)
            {
                for (var j = 0; j < 5; j++)
                {
                    Assert.AreEqual(i * 5 + j, sut.Dequeue());
                }
            }
        }

        [TestMethod]
        public void HandleUnsortedInput()
        {
            var sut = new MaxPriorityQueue<int, int>();
            var random = new Random();

            for (var i = 0; i < 50000; i++)
            {
                var randomValue = random.Next(1000);
                sut.Enqueue(randomValue, randomValue);
            }

            var results = new List<int>();
            for (var i = 0; i < 50000; i++)
            {
                results.Add(sut.Dequeue());
            }
            var sortedResults = new List<int>(results).OrderByDescending(x => x).ToList();

            CollectionAssert.AreEqual(sortedResults, results);
        }
    }
}
