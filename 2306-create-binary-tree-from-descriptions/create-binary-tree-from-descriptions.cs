/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

using System;
using System.Collections.Generic;

public class Solution {
    public TreeNode CreateBinaryTree(int[][] descriptions) {
        Dictionary<int, TreeNode> nodes = new Dictionary<int, TreeNode>();
        HashSet<int> children = new HashSet<int>();

        // Create nodes and set relationships in a single pass
        foreach (var desc in descriptions) {
            int parentVal = desc[0];
            int childVal = desc[1];
            bool isLeft = desc[2] == 1;

            if (!nodes.ContainsKey(parentVal)) {
                nodes[parentVal] = new TreeNode(parentVal);
            }
            if (!nodes.ContainsKey(childVal)) {
                nodes[childVal] = new TreeNode(childVal);
            }

            if (isLeft) {
                nodes[parentVal].left = nodes[childVal];
            } else {
                nodes[parentVal].right = nodes[childVal];
            }

            children.Add(childVal);
        }

        // The root is the node that is not a child of any node
        foreach (var node in nodes.Values) {
            if (!children.Contains(node.val)) {
                return node;
            }
        }

        return null; // In case the input is empty or invalid
    }
}