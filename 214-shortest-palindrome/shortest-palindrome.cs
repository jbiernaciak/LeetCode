public class Solution {
    public string ShortestPalindrome(string s) {
        if (string.IsNullOrEmpty(s)) {
            return s; // Edge case: If the string is empty, return it as is.
        }

        int n = s.Length;
        int end = n - 1; // Pointer to the end of the string
        int j = 0; // Pointer for matching characters

        // Find the longest palindromic prefix by matching from the end
        while (end >= 0) {
            if (s[end] == s[j]) {
                j++; // Move the matching pointer if characters match
            }
            end--; // Move the end pointer leftwards in all cases
        }

        // If the entire string is already a palindrome
        if (j == n) {
            return s;
        }

        // Unmatched suffix
        string suffix = s.Substring(j);
        // Reverse the unmatched suffix
        string revSuffix = Reverse(suffix);
        // Form the shortest palindrome
        return revSuffix + ShortestPalindrome(s.Substring(0, j)) + suffix;
    }

    // Helper function to reverse a string
    private string Reverse(string s) {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}