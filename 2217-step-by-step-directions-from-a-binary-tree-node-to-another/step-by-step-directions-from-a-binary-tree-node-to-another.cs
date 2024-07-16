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
    public string GetDirections(TreeNode root, int startValue, int destValue) {
        List<char> pathToStart = new List<char>();
        List<char> pathToDest = new List<char>();

        FindPath(root, startValue, pathToStart);
        FindPath(root, destValue, pathToDest);

        // Find the first point of divergence in the paths
        int i = 0;
        while (i < pathToStart.Count && i < pathToDest.Count && pathToStart[i] == pathToDest[i]) {
            i++;
        }

        // Directions to move up to the common ancestor
        string upMoves = new string('U', pathToStart.Count - i);

        // Directions to move from the common ancestor to the destination
        string downMoves = new string(pathToDest.ToArray(), i, pathToDest.Count - i);

        return upMoves + downMoves;
    }

    private bool FindPath(TreeNode root, int value, List<char> path) {
        if (root == null) return false;
        if (root.val == value) return true;

        // Traverse the left subtree
        path.Add('L');
        if (FindPath(root.left, value, path)) {
            return true;
        }
        path.RemoveAt(path.Count - 1);

        // Traverse the right subtree
        path.Add('R');
        if (FindPath(root.right, value, path)) {
            return true;
        }
        path.RemoveAt(path.Count - 1);

        return false;
    }
}