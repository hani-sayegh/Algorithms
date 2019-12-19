using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Graph
{
    class _200
    {
        public int NumIslands(char[][] grid)
        {
            if (grid.Length == 0)
                return 0;
            var n = grid.Length;
            var m = grid[0].Length;
            var result = 0;

            for (int i = 0; i != n; ++i)
            {
                for (int j = 0; j != m; ++j)
                {
                    if (grid[i][j] == '1')
                    {
                        ++result;
                        BFS(grid, i, j);
                    }
                }
            }
            return result;
        }

        public void BFS(char[][] grid, int row, int col)
        {
            var q = new Queue<(int, int)>();
            q.Enqueue((row, col));
            grid[row][col] = '0';

            while (q.Count != 0)
            {
                var currentPoint = q.Dequeue();
                var (x, y) = currentPoint;

                var left = (x, y - 1);
                var right = (x, y + 1);
                var up = (x - 1, y);
                var down = (x + 1, y);

                var newPoints = new[] { left, right, up, down };
                foreach (var point in newPoints)
                {
                    var (newRow, newCol) = point;
                    if (Valid(newRow, newCol,grid))
                    {
                        grid[newRow][newCol] = '0';
                        q.Enqueue(point);
                    }
                }
            }
        }

        bool Valid(int row, int col, char[][] grid)
        {
            var n = grid.Length;
            var m = grid[0].Length;
            return (row >= 0 && row < n && col >= 0 && col < m && grid[row][col] == '1');
        }
    }
}