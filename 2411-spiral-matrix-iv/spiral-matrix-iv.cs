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
public class Solution {
    public int[][] SpiralMatrix(int m, int n, ListNode head) {
        // Initialize the matrix with -1 (as default value for empty spaces)
        int[][] matrix = new int[m][];
        for (int i = 0; i < m; i++) {
            matrix[i] = new int[n];
            for (int j = 0; j < n; j++) {
                matrix[i][j] = -1;
            }
        }

        int top = 0, bottom = m - 1, left = 0, right = n - 1;
        ListNode current = head;

        // Continue filling until either the matrix is filled or the list runs out of values
        while (top <= bottom && left <= right && current != null) {
            // Fill the top row (left to right)
            for (int i = left; i <= right && current != null; i++) {
                matrix[top][i] = current.val;
                current = current.next;
            }
            top++; // Move the top boundary down

            // Fill the right column (top to bottom)
            for (int i = top; i <= bottom && current != null; i++) {
                matrix[i][right] = current.val;
                current = current.next;
            }
            right--; // Move the right boundary left

            // Fill the bottom row (right to left)
            for (int i = right; i >= left && current != null; i--) {
                matrix[bottom][i] = current.val;
                current = current.next;
            }
            bottom--; // Move the bottom boundary up

            // Fill the left column (bottom to top)
            for (int i = bottom; i >= top && current != null; i--) {
                matrix[i][left] = current.val;
                current = current.next;
            }
            left++; // Move the left boundary right
        }

        return matrix;
    }
}