using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.DataStructures
{
    class Heap
    {
        public Heap(IComparer<int> comparer)
        {
            Comparer = comparer;
        }

        public int Count => _items.Count;

        List<int> _items = new List<int>();

        public IComparer<int> Comparer { get; }

        int LeftChildIdx(int parentIdx) => parentIdx * 2 + 1;
        int RightChildIdx(int parentIdx) => parentIdx * 2 + 2;
        int ParentIdx(int childIdx) => (childIdx / 2) - ((childIdx % 2 == 0) ? 1 : 0);
        public int Top => _items[0];

        public void Insert(int value)
        {
            _items.Add(value);

            var childIdx = _items.Count - 1;
            var parentIdx = ParentIdx(childIdx);

            while (childIdx != 0 && ShouldChangeOrder(_items[parentIdx], value))
            {
                Swap(_items, childIdx, parentIdx);
                childIdx = parentIdx;
                parentIdx = ParentIdx(childIdx);
            }
        }

        bool ShouldChangeOrder(int x, int y) => Comparer.Compare(x, y) > 0;

        public int Remove()
        {
            var childIdx = _items.Count - 1;
            var result = _items[0];
            Swap(_items, 0, childIdx);

            _items.RemoveAt(_items.Count - 1);

            var parentIdx = 0;

            while (Valid(parentIdx))
            {
                var tmpIdx = parentIdx;
                var leftChildIdx = LeftChildIdx(parentIdx);
                var rightChildIdx = RightChildIdx(parentIdx);
                if (Valid(leftChildIdx) && ShouldChangeOrder(_items[tmpIdx], _items[leftChildIdx]))
                    tmpIdx = leftChildIdx;

                if (Valid(rightChildIdx) && ShouldChangeOrder(_items[tmpIdx], _items[rightChildIdx]))
                    tmpIdx = rightChildIdx;

                if (tmpIdx == parentIdx)
                    break;
                else
                {
                    Swap(_items, tmpIdx, parentIdx);
                    parentIdx = tmpIdx;
                }
            }
            return result;
        }

        bool Valid(int idx) => idx < _items.Count;
        void Swap(List<int> l, int idx1, int idx2)
        {
            var tmp = l[idx1];
            _items[idx1] = _items[idx2];
            _items[idx2] = tmp;
        }
    }
}
