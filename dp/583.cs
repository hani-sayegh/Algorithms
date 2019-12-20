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
            var dp = new int[n + 1, m + 1];

            for (int col = 0; col != m; ++col)
                dp[0, col] = col;
            for (int row = 0; row != n; ++row)
                dp[row, 0] = row;

            for (int row = 1; row <= n; ++row)
            for (int col = 1; col <= m; ++col)
                {
                    var prow = row - 1;
                    var pcol = col - 1;
                    if (word1[prow] == word2[pcol])
                        dp[row, col] = dp[prow, pcol];

                    else
                        dp[row, col] = Math.Min(dp[prow, col], dp[row, pcol]) + 1;
                }
            return dp[n , m ];
        }
    }
}
