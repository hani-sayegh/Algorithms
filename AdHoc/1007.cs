using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.AdHoc
{
    class _1007
    {
        public int MinDominoRotations(int[] A, int[] B)
        {
            var set = new HashSet<int>();

            set.Add(A[0]);
            set.Add(B[0]);

            for (int i = 1; i != A.Length; ++i)
            {
                set.IntersectWith(new HashSet<int> { A[i], B[i] });
                if (set.Count == 0)
                    return -1;
            }

            var result = int.MaxValue;
            foreach (var common in set)
            {
                var toSwap = 0;
                var toSwap2 = 0;
                foreach (var val in A)
                {
                    if (val != common)
                        ++toSwap;
                }
                foreach (var val in B)
                {
                    if (val != common)
                        ++toSwap2;
                }

                result = Math.Min(result, Math.Min(toSwap, toSwap2));
            }
            return result;
        }
    }
}
