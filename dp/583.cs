using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.dp
{
    class _583
    {
        public int MinDistance(string word1, string word2)
        {
            var n = word1.Length;
            var m = word2.Length;
            var dp = new int[m + 1];
            for (int col = 0; col <= m; ++col)
                dp[col] = col;
            for (int row = 1; row <= n; ++row)
            {
                int leftVal = row;
                for (int col = 1; col <= m; ++col)
                {
                    var pcol = col - 1;
                    var tmp = leftVal;

                    if (word1[row - 1] == word2[pcol])
                        leftVal = dp[pcol];
                    else
                        leftVal = Math.Min(leftVal, dp[col]) + 1;

                    dp[pcol] = tmp;
                }
                dp[m] = leftVal;
            }
            return dp[m];
        }
    }
}
