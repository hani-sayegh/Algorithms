using System;
using System.Collections.Generic;

namespace Leetcode.DataStructures
{

    public class MedianFinder
    {
        Heap minHeap = new Heap(Comparer<int>.Create((x, y) => x - y));
        Heap maxHeap = new Heap(Comparer<int>.Create((x, y) => y-x));

        /** initialize your data structure here. */
        public MedianFinder()
        {
        }

        public void AddNum(int num)
        {
            if (minHeap.Count > 0 && num > minHeap.Top)
            {
                minHeap.Insert(num);
                if (maxHeap.Count < minHeap.Count)
                {
                    maxHeap.Insert(minHeap.Remove());
                    Console.WriteLine(maxHeap.Top);
                }
            }
            else
            {
                maxHeap.Insert(num);
                if (maxHeap.Count > minHeap.Count + 1)
                {
                    minHeap.Insert(maxHeap.Remove());
                }
            }
        }

        public double FindMedian()
        {
            var count = minHeap.Count + maxHeap.Count;

            if(count %2 == 0)
            {
                return (minHeap.Top + maxHeap.Top) / 2f;
            }
            return maxHeap.Top;
        }
    }
}
