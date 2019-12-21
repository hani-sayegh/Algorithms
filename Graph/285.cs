using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode.Graph
{
    class _285
    {
        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        public class Solution
        {
            public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
            {
                TreeNode result = null;
                while (root != null)
                {
                    if (root.val > p.val)
                    {
                        result = root;
                        root = root.left;
                    }
                    else if (root.val <= p.val)
                    {
                        root = root.right;
                    }
                }
                return result;
            }
        }
    }
}