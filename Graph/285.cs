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

            int target;
            TreeNode result = null;
            bool targetFound = false;
            public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
            {
                target = p.val;
                InorderTraverse(root);
                return result;
            }

            public void UpdateResult(TreeNode t)
            {
                if (t.val < target)
                    return;
                if (result == null)
                {
                    result = t;
                    return;
                }
                if (result.val > t.val)
                    result = t;
            }

            public void InorderTraverse(TreeNode root)
            {
                if (root == null)
                    return;

                InorderTraverse(root.left);
                if (targetFound)
                {
                    UpdateResult(root);
                }
                if (root.val == target)
                    targetFound = true;


                InorderTraverse(root.right);
            }
        }
    }
}
