/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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
    public bool IsSubPath(ListNode head, TreeNode root) {
        if (root == null) {
            return false;
        }
        
        // Breadth-First Search (BFS) for tree traversal
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0) {
            TreeNode currentNode = queue.Dequeue();
            
            // If the current node's value matches the head of the list, check for a subpath
            if (currentNode.val == head.val && DfsCheck(currentNode, head)) {
                return true;
            }
            
            // Continue BFS by adding left and right children to the queue
            if (currentNode.left != null) {
                queue.Enqueue(currentNode.left);
            }
            
            if (currentNode.right != null) {
                queue.Enqueue(currentNode.right);
            }
        }
        
        return false;
    }

    // Depth-First Search (DFS) to check the subpath starting at a given tree node
    private bool DfsCheck(TreeNode node, ListNode head) {
        if (head == null) {
            return true; // If we've reached the end of the linked list, it's a valid subpath
        }
        
        if (node == null || node.val != head.val) {
            return false; // If the node is null or the values don't match, return false
        }
        
        // Continue the DFS by checking both left and right children of the tree node
        return DfsCheck(node.left, head.next) || DfsCheck(node.right, head.next);
    }
}