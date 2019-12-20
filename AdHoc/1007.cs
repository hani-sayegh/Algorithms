using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.AdHoc
{
    class _1007
    {
        public int MinDominoRotations(int[] A, int[] B)
        {

            var res = Min(A[0]);

            if (res != -1 || A[0] == B[0]) return res;

            return Min(B[0]);

            int Min(int target)
            {
                var ar = 0;
                var br = 0;
                for (int i = 0; i != A.Length; ++i)
                {
                    if (A[i] != target && B[i] != target)
                        return -1;

                    if (A[i] != target)
                        ++ar;
                    if (B[i] != target)
                        ++br;
                }
                return Math.Min(ar, br);
            }
        }
    }
}
