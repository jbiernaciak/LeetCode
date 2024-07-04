public class Solution {
    public ListNode MergeNodes(ListNode head) {
        if (head == null || head.next == null) {
            return null;
        }

        ListNode dummy = new ListNode(0);
        ListNode currentNewList = dummy;
        ListNode current = head.next; // Start after the first 0
        int sum = 0;

        while (current != null) {
            if (current.val == 0) {
                // We've reached the end of a segment
                currentNewList.next = new ListNode(sum);
                currentNewList = currentNewList.next;
                sum = 0; // Reset sum for the next segment
            } 
            
            else {
                sum += current.val;
            }

            current = current.next;
        }

        return dummy.next;
    }
}
