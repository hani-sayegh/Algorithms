using System;
using System.Collections.Generic;

namespace Leetcode.DataStructures
{

    public class MedianFinder
    {
        Heap minHeap = new Heap(Comparer<int>.Create((x, y) => x - y));
        Heap maxHeap = new Heap(Comparer<int>.Create((x, y) => y - x));

        /** initialize your data structure here. */
        public MedianFinder()
        {
        }

        public void AddNum(int num)
        {
            maxHeap.Insert(num);
            minHeap.Insert(maxHeap.Remove());

            if (maxHeap.Count < minHeap.Count)
            {
                maxHeap.Insert(minHeap.Remove());
            }
        }

        public double FindMedian()
        {
            if (minHeap.Count == maxHeap.Count)
            {
                return (minHeap.Top + maxHeap.Top) / 2f;
            }
            return maxHeap.Top;
        }
    }
}
