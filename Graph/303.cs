using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Graph
{
    class _303
    {
        public class NumArray
        {
            int[] prefixSum;
            public NumArray(int[] nums)
            {
                prefixSum = new int[nums.Length + 1];
                for (int i = 0; i != nums.Length; ++i)
                {
                    prefixSum[i + 1] = prefixSum[i] + nums[i];
                }
            }

            public int SumRange(int i, int j)
            {
                return prefixSum[j + 1] - prefixSum[i];
            }
        }

        /**
         * Your NumArray object will be instantiated and called as such:
         * NumArray obj = new NumArray(nums);
         * int param_1 = obj.SumRange(i,j);
         */

    }
}
