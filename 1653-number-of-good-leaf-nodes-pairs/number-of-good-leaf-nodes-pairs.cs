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
    public int CountPairs(TreeNode root, int distance) {
        int count = 0;
        Dfs(root, distance, ref count);
        return count;
    }

    private List<int> Dfs(TreeNode node, int distance, ref int count) {
        if (node == null) {
            return new List<int>();
        }

        if (node.left == null && node.right == null) {
            // Leaf node, return distance 1 (distance to itself is 0, to parent is 1)
            return new List<int> { 1 };
        }

        List<int> leftDistances = Dfs(node.left, distance, ref count);
        List<int> rightDistances = Dfs(node.right, distance, ref count);

        // Count good leaf node pairs between left and right subtrees
        foreach (int l in leftDistances) {
            foreach (int r in rightDistances) {
                if (l + r <= distance) {
                    count++;
                }
            }
        }

        // Increment distances by 1 to account for the current node
        List<int> currentDistances = new List<int>();
        foreach (int l in leftDistances) {
            if (l + 1 <= distance) {
                currentDistances.Add(l + 1);
            }
        }
        foreach (int r in rightDistances) {
            if (r + 1 <= distance) {
                currentDistances.Add(r + 1);
            }
        }

        return currentDistances;
    }
}