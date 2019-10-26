﻿using System;
using NUnit.Framework;
using DSA.DataStructures.Queues;

namespace DSAUnitTests.DataStructures.Queues
{
    [TestFixture]
    public class ArrayQueueTests
    {
        [Test]
        public void EnqueuingItemsOneByOne()
        {
            var queue = new ArrayQueue<int>();

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            int trueCount = 0;
            int lastItem = int.MinValue;

            foreach (var item in queue)
            {
                if (lastItem > item) Assert.Fail();
                lastItem = item;
                trueCount++;
            }

            Assert.IsTrue(queue.Count == itemCount
                            && queue.Count == trueCount);
        }

        [Test]
        public void InitializingArrayQueueWithCollection()
        {
            var queue = new ArrayQueue<int>();

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            var queue2 = new ArrayQueue<int>(queue);

            int trueCount = 0;
            int lastItem = int.MinValue;
            foreach (var item in queue2)
            {
                if (lastItem > item) Assert.Fail();
                lastItem = item;
                trueCount++;
            }

            Assert.IsTrue(queue.Count == itemCount
                            && queue2.Count == itemCount
                            && queue2.Count == trueCount);
        }

        [Test]
        public void DequeuingAllExceptOne()
        {
            var queue = new ArrayQueue<int>();

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            int lastItem = int.MinValue;
            for (int i = 0; i < itemCount - 1; i++)
            {
                if (lastItem > queue.Dequeue()) Assert.Fail();
            }

            int trueCount = 0;


            foreach (var item in queue)
            {
                trueCount++;
            }

            Assert.IsTrue(queue.Count == 1
                            && trueCount == 1);
        }

        [Test]
        public void InitializationWithZeroCapacityAndEnqueuingItemsAfterwards()
        {
            var queue = new ArrayQueue<int>(0);

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            int trueCount = 0;
            int lastItem = int.MinValue;
            foreach (var item in queue)
            {
                if (lastItem > item) Assert.Fail();
                lastItem = item;
                trueCount++;
            }

            Assert.IsTrue(queue.Count == itemCount
                            && queue.Count == trueCount);
        }

        [Test]
        public void DequeuingAllItemsAndEnqueuingAgain()
        {
            var queue = new ArrayQueue<int>();

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            int lastItem = int.MinValue;
            for (int i = 0; i < itemCount; i++)
            {
                if (lastItem > queue.Dequeue()) Assert.Fail();
            }

            bool countWasZero = queue.Count == 0;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            int trueCount = 0;
            lastItem = int.MinValue;

            foreach (var item in queue)
            {
                if (lastItem > item) Assert.Fail();
                lastItem = item;
                trueCount++;
            }

            Assert.IsTrue(queue.Count == itemCount
                            && queue.Count == trueCount
                            && countWasZero);
        }

        [Test]
        public void CheckIfContainedBeforeAndAfterDequeuing()
        {
            var queue = new ArrayQueue<int>();

            int itemCount = 10000;

            for (int i = 0; i < itemCount; i++)
            {
                if (queue.Contains(i)) Assert.Fail();
                queue.Enqueue(i);
                if (!queue.Contains(i)) Assert.Fail();
            }

            int lastItem = int.MinValue;
            for (int i = 0; i < itemCount; i++)
            {
                var first = queue.Peek();
                if (!queue.Contains(i)) Assert.Fail();
                var dequeued = queue.Dequeue();
                if (dequeued != first) Assert.Fail();
                if (lastItem > dequeued) Assert.Fail();
                if (queue.Contains(i)) Assert.Fail();
                lastItem = first;
            }

            Assert.IsTrue(queue.Count == 0);
        }

        [Test]
        public void EnqueuingAfterClearingCollection()
        {
            var stack = new ArrayQueue<int>();

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                stack.Enqueue(i);
            }

            stack.Clear();

            for (int i = 0; i < itemCount; i++)
            {
                stack.Enqueue(i);
            }

            int trueCount = 0;
            int lastItem = int.MinValue;
            foreach (var item in stack)
            {
                if (lastItem > item) Assert.Fail();
                lastItem = item;
                trueCount++;
            }

            Assert.IsTrue(stack.Count == itemCount
                            && stack.Count == trueCount);
        }

        [Test]
        public void EnqueuingItemsAndCheckingIfIteratedInCorrectly()
        {
            var queue = new ArrayQueue<int>();

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            int trueCount = 0;
            int itemNum = 0;
            foreach (var item in queue)
            {
                if (itemNum++ != item) Assert.Fail();
                trueCount++;
            }

            Assert.IsTrue(queue.Count == itemCount
                            && queue.Count == trueCount);
        }

        [Test]
        public void ConvertingQueueToArray()
        {
            var queue = new ArrayQueue<int>();

            int itemCount = 500000;

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            var array = queue.ToArray();

            int trueCount = 0;
            for (int i = 0; i < itemCount; i++)
            {
                if (array[i] != i) Assert.Fail();
                trueCount++;
            }

            Assert.IsTrue(queue.Count == itemCount
                            && queue.Count == trueCount);
        }

        [Test]
        public void DequeuingHalfTheItemsAndEnquingTwiceAsMuch()
        {
            int itemCount = 500000;

            var queue = new ArrayQueue<int>(itemCount);

            for (int i = 0; i < itemCount; i++)
            {
                queue.Enqueue(i);
            }

            int lastItem = int.MinValue;
            for (int i = 0; i < itemCount >> 1; i++)
            {
                if (lastItem > queue.Dequeue()) Assert.Fail();
            }

            int maxItem = itemCount + itemCount * 2;

            for (int i = itemCount; i < maxItem; i++)
            {
                queue.Enqueue(i);
            }

            itemCount = maxItem - itemCount + itemCount / 2;

            int trueCount = 0;
            lastItem = int.MinValue;
            foreach (var item in queue)
            {
                if (lastItem > item) Assert.Fail();
                lastItem = item;
                trueCount++;
            }

            Assert.IsTrue(queue.Count == trueCount
                            && itemCount == trueCount);
        }
    }
}
