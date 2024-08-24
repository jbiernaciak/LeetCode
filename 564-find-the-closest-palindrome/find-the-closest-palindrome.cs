public class Solution {
    public string NearestPalindromic(string n) {
        int length = n.Length;

        // Handle simple edge cases directly
        if (length == 1) {
            return (char)(n[0] - 1) + "";
        }

        // Initialize possible candidates
        var candidates = new List<long>();
        
        // Add edge cases
        candidates.Add((long)Math.Pow(10, length) + 1); // 1000...0001
        candidates.Add((long)Math.Pow(10, length - 1) - 1); // 999...999
        
        // Middle position index
        int middle = (length + 1) / 2;
        
        // Extract the prefix and create three variations
        long prefix = long.Parse(n.Substring(0, middle));
        for (long i = -1; i <= 1; i++) {
            long newPrefix = prefix + i;
            string palin = CreatePalindrome(newPrefix.ToString(), length % 2 == 0);
            candidates.Add(long.Parse(palin));
        }

        // Convert the input string n to a long
        long originalNumber = long.Parse(n);

        // Find the nearest palindrome
        long closestPalindrome = -1;
        foreach (long candidate in candidates) {
            if (candidate == originalNumber) continue;

            if (closestPalindrome == -1 || 
                Math.Abs(candidate - originalNumber) < Math.Abs(closestPalindrome - originalNumber) ||
                (Math.Abs(candidate - originalNumber) == Math.Abs(closestPalindrome - originalNumber) && candidate < closestPalindrome)) {
                closestPalindrome = candidate;
            }
        }

        return closestPalindrome.ToString();
    }

    // Helper method to create a palindrome based on a given prefix
    private string CreatePalindrome(string prefix, bool isEvenLength) {
        var sb = new StringBuilder(prefix);
        for (int i = prefix.Length - (isEvenLength ? 1 : 2); i >= 0; i--) {
            sb.Append(prefix[i]);
        }
        return sb.ToString();
    }
}