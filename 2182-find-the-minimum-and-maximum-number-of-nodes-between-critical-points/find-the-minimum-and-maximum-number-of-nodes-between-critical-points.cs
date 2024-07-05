public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        if (head == null || head.next == null || head.next.next == null) {
            return new int[] { -1, -1 };
        }
        
        List<int> criticalPoints = new List<int>();
        int index = 1;
        ListNode prev = head;
        ListNode curr = head.next;
        ListNode next = head.next.next;
        
        while (next != null) {
            if ((curr.val > prev.val && curr.val > next.val) || 
                (curr.val < prev.val && curr.val < next.val)) {
                criticalPoints.Add(index);
            }
            
            prev = curr;
            curr = next;
            next = next.next;
            index++;
        }
        
        if (criticalPoints.Count < 2) {
            return new int[] { -1, -1 };
        }
        
        int minDistance = int.MaxValue;
        int maxDistance = criticalPoints[criticalPoints.Count - 1] - criticalPoints[0];
        
        for (int i = 1; i < criticalPoints.Count; i++) {
            minDistance = Math.Min(minDistance, criticalPoints[i] - criticalPoints[i - 1]);
        }
        
        return new int[] { minDistance, maxDistance };
    }
}