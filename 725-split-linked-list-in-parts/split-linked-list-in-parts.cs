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
    public ListNode[] SplitListToParts(ListNode head, int k) {
        ListNode[] result = new ListNode[k];
        ListNode current = head;
        
        // Calculate length of list
        int length = 0;
        while (current != null) {
            length++;
            current = current.next;
        }

        // Calculate how many nodes per part
        int nodesPerPart = length / k;
        int remainder = length % k; // Extra nodes to distribute
        
        current = head;
        
        for (int i = 0; i < k && current != null; i++) {
            result[i] = current;
            int currentPartSize = nodesPerPart + (i < remainder ? 1 : 0); // Extra node to the first 'remainder' parts

            // Traverse to the end of this part
            for (int j = 1; j < currentPartSize; j++) {
                if (current != null) current = current.next;
            }

            // Disconnect current part from the rest of the list
            if (current != null) {
                ListNode nextPartHead = current.next;
                current.next = null; // Split the list
                current = nextPartHead; // Move to the next part
            }
        }

        return result;
    }
}