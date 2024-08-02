public class Solution {
    public int MinSwaps(int[] nums) {
        int n = nums.Length;
        
        // Step 1: Calculate total number of 1's
        int totalOnes = 0;
        foreach (int num in nums) {
            if (num == 1) {
                totalOnes++;
            }
        }
        
        // Edge case: if there are no 1's or only one 1, no swaps needed
        if (totalOnes <= 1) {
            return 0;
        }
        
        // Step 2: Compute the prefix sum array
        int[] prefixSum = new int[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSum[i + 1] = prefixSum[i] + nums[i];
        }
        
        // Step 3: Find the minimum number of swaps required
        int minSwaps = int.MaxValue;
        
        // Check all possible windows of size totalOnes
        for (int i = 0; i < n; i++) {
            int end = i + totalOnes - 1;
            int currentOnes;
            
            if (end < n) {
                currentOnes = prefixSum[end + 1] - prefixSum[i];
            } else {
                currentOnes = (prefixSum[n] - prefixSum[i]) + (prefixSum[end - n + 1]);
            }
            
            minSwaps = Math.Min(minSwaps, totalOnes - currentOnes);
        }
        
        return minSwaps;
    }
}