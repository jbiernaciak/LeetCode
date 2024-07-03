public class Solution {
    public int MinDifference(int[] nums) {
        int n = nums.Length;
        if (n <= 4) return 0;

        Array.Sort(nums);

        int minDiff = int.MaxValue;

        minDiff = Math.Min(minDiff, nums[n-4] - nums[0]); // Remove 0 smallest and 3 largest
        minDiff = Math.Min(minDiff, nums[n-3] - nums[1]); // Remove 1 smallest and 2 largest
        minDiff = Math.Min(minDiff, nums[n-2] - nums[2]); // Remove 2 smallest and 1 largest
        minDiff = Math.Min(minDiff, nums[n-1] - nums[3]); // Remove 3 smallest and 0 largest
        
        return minDiff;
    }
}