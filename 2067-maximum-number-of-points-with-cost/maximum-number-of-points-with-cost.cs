public class Solution {
    public long MaxPoints(int[][] points) {
        int m = points.Length;
        int n = points[0].Length;
        
        // DP array to store the max points up to the current row
        long[] dp = new long[n];
        
        // Initialize the dp array with the first row
        for (int c = 0; c < n; c++) {
            dp[c] = points[0][c];
        }
        
        // Iterate over each row starting from the second one
        for (int r = 1; r < m; r++) {
            long[] newDp = new long[n];
            
            // Forward pass to accumulate left maximums
            long leftMax = dp[0];
            for (int c = 0; c < n; c++) {
                leftMax = Math.Max(leftMax, dp[c] + c);
                newDp[c] = leftMax + points[r][c] - c;
            }
            
            // Backward pass to accumulate right maximums
            long rightMax = dp[n - 1] - (n - 1);
            for (int c = n - 1; c >= 0; c--) {
                rightMax = Math.Max(rightMax, dp[c] - c);
                newDp[c] = Math.Max(newDp[c], rightMax + points[r][c] + c);
            }
            
            // Update dp array with the newDp values for the current row
            dp = newDp;
        }
        
        // The result will be the maximum value in the last dp array
        long maxPoints = 0;
        for (int c = 0; c < n; c++) {
            maxPoints = Math.Max(maxPoints, dp[c]);
        }
        
        return maxPoints;
    }
}