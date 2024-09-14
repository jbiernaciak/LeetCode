public class Solution {
    public int LongestSubarray(int[] nums) {
        int maxVal = 0;
        
        // Step 1: Find the maximum element in the array
        foreach (int num in nums) {
            maxVal = Math.Max(maxVal, num);
        }
        
        // Step 2: Find the longest contiguous subarray with maxVal
        int maxLength = 0;
        int currentLength = 0;
        
        foreach (int num in nums) {
            if (num == maxVal) {
                currentLength++;
                maxLength = Math.Max(maxLength, currentLength);
            } else {
                currentLength = 0;
            }
        }
        
        return maxLength;
    }
}