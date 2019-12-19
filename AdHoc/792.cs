using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Leetcode.AdHoc
{
    class _792
    {
        public int ShortestPath(int[][] grid, int k)
        {
            var q = new Queue<(int, int, int)>();
            var seen = new bool[grid.Length, grid[0].Length, k + 1];

            q.Enqueue((0, 0, k));

            seen[0, 0, k] = true;
            int res = 0;
            while (q.Count != 0)
            {

                var count = q.Count;

                while (count-- != 0)
                {
                    var (x, y, left) = q.Dequeue();
                    if (x == grid.Length - 1 && y == grid[0].Length - 1)
                        return res;
                    var newPos = new (int, int)[]{ (x, y - 1),
                (x, y + 1),
                (x + 1,y),
                (x - 1, y)};

                    foreach (var tuple in newPos)
                    {
                        var currentLeft = left;
                        var (newX, newY) = tuple;
                        if (newX < 0 || newY < 0 || newX == grid.Length || newY == grid[0].Length)
                            continue;

                        if (grid[newX][newY] == 1)
                        {
                            if (currentLeft == 0)
                                continue;
                            --currentLeft;
                        }

                        if (seen[newX,newY, currentLeft])
                            continue;

                        q.Enqueue((newX, newY, currentLeft));
                        seen[newX, newY, currentLeft] = true;
                    }
                }
                ++res;
            }
            return -1;
        }

        //public int GetDecimalValue(ListNode head)
        //{
        //    return GetDec(head).Item1;

        //    public (int, int) GetDec(ListNode head)
        //    {
        //    if (head == null)
        //        return (1, 0);

        //        var (count, val) = GetDec(head.next);

        //        return (count * 2, val + count * head.val);
        //    }
        //}

        public IList<int> SequentialDigits(int low, int high)
        {
            var res = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; ++j)
                {
                    var num = 0;
                    for (int w = 0; w != i; ++w)
                    {

                        num = num * 10 + j;
                    }
                    if(num >= low && num <= high)
                    res.Add(num);
                }
            }
            return res;
        }

        public int NumMatchingSubseq(string S, string[] words)
        {
            var groups = new List<(string, int)>[26];

            for (int i = 0; i < groups.Length; ++i)
            {
                groups[i] = new List<(string, int)>();
            }

            var result = 0;
            foreach (var word in words)
            {
                if (word.Length == 0)
                    ++result;
                else
                    groups[word[0] - 'a'].Add((word, 0));
            }

            foreach (var c in S)
            {
                var charIdx = c - 'a';
                var currentList = groups[charIdx];
                groups[charIdx] = new List<(string, int)>();

                foreach (var tuple in currentList)
                {
                    var (word, idx) = tuple;
                    var newIdx = idx + 1;

                    if (newIdx == word.Length)
                        ++result;
                    else
                        groups[word[newIdx] - 'a'].Add((word, newIdx));
                }
            }
            return result;
        }
    }
}
