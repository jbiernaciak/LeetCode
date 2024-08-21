public class Solution {
    public int StrangePrinter(string s) {
        if (string.IsNullOrEmpty(s)) return 0;
        
        // Remove consecutive duplicates
        var filteredChars = new List<char>();
        foreach (var c in s) {
            if (filteredChars.Count == 0 || c != filteredChars[filteredChars.Count - 1]) {
                filteredChars.Add(c);
            }
        }
        
        int m = filteredChars.Count;
        var dp = new int[m, m];
        for (int i = 0; i < m; ++i) {
            dp[i, i] = 1;
        }
        
        // Precompute the next occurrence for each character
        var lastSeen = new Dictionary<char, int>();
        var nextOccurrence = new int[m];
        Array.Fill(nextOccurrence, -1);
        for (int i = m - 1; i >= 0; --i) {
            char c = filteredChars[i];
            if (lastSeen.ContainsKey(c)) {
                nextOccurrence[i] = lastSeen[c];
            }
            lastSeen[c] = i;
        }
        
        // Fill the DP table
        for (int length = 2; length <= m; ++length) {
            for (int start = 0; start <= m - length; ++start) {
                int end = start + length - 1;
                // Initial case: print each character separately
                dp[start, end] = dp[start + 1, end] + 1;
                // Try to find a better solution by matching characters
                char currentChar = filteredChars[start];
                int nextPos = nextOccurrence[start];
                while (nextPos != -1 && nextPos <= end) {
                    dp[start, end] = Math.Min(dp[start, end], dp[start, nextPos - 1] + (nextPos + 1 <= end ? dp[nextPos + 1, end] : 0));
                    nextPos = nextOccurrence[nextPos];
                }
            }
        }
        
        return dp[0, m - 1];
    }
}
