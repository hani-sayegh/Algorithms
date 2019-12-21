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

                if (root == null)
                    return result;

                if (root.val > p.val)
                {
                    var left = InorderSuccessor(root.left, p);
                    return (left != null) ? left : root;
                }
                return InorderSuccessor(root.right, p);
            }
        }
    }
}