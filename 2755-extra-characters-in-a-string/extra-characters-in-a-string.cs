public class Solution {
    public int MinExtraChar(string s, string[] dictionary) {
        // Convert the dictionary into a set for quick lookup
        var dict = new HashSet<string>(dictionary);
        // Use a memoization dictionary to avoid redundant calculations
        var memo = new Dictionary<int, int>();
        // Start the recursive search from index 0
        return MinExtraCharHelper(s, dict, 0, memo);
    }

    private int MinExtraCharHelper(string s, HashSet<string> dict, int start, Dictionary<int, int> memo) {
        // Base case: If we have reached the end of the string
        if (start == s.Length) {
            return 0;
        }

        // Check if we have already computed the result for this starting index
        if (memo.ContainsKey(start)) {
            return memo[start];
        }

        // Initialize the result as the maximum possible extra characters (all characters from 'start' onwards)
        int minExtra = s.Length - start;

        // Try every possible substring starting from 'start'
        for (int end = start + 1; end <= s.Length; end++) {
            string substring = s.Substring(start, end - start);
            if (dict.Contains(substring)) {
                // If the substring is in the dictionary, recursively compute the min extra for the remaining string
                minExtra = Math.Min(minExtra, MinExtraCharHelper(s, dict, end, memo));
            } else {
                // If not in dictionary, count all characters as extra and add to the recursive result
                minExtra = Math.Min(minExtra, (end - start) + MinExtraCharHelper(s, dict, end, memo));
            }
        }

        // Memoize and return the result for the current starting index
        memo[start] = minExtra;
        return minExtra;
    }
}