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


public class Solution {
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) {
        HashSet<int> toDeleteSet = new HashSet<int>(to_delete);
        List<TreeNode> forest = new List<TreeNode>();

        TreeNode helper(TreeNode node, bool isRoot) {
            if (node == null) return null;

            bool toDelete = toDeleteSet.Contains(node.val);
            if (isRoot && !toDelete) {
                forest.Add(node);
            }

            node.left = helper(node.left, toDelete);
            node.right = helper(node.right, toDelete);

            return toDelete ? null : node;
        }

        helper(root, true);
        return forest;
    }
}