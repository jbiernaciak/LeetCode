public class Solution {
    public int FindTheLongestSubstring(string s) {
        // A map to store the first occurrence of each state
        Dictionary<int, int> map = new Dictionary<int, int>();
        map[0] = -1; // Initial state with no vowels is at index -1
        
        int maxLength = 0;
        int currentMask = 0;  // Mask representing the even/odd state of vowels
        
        // Iterate through the string
        for (int i = 0; i < s.Length; i++) {
            char ch = s[i];
            
            // Update the current mask based on the character (toggle bits for vowels)
            if (ch == 'a') {
                currentMask ^= (1 << 0);  // Toggle bit for 'a'
            } else if (ch == 'e') {
                currentMask ^= (1 << 1);  // Toggle bit for 'e'
            } else if (ch == 'i') {
                currentMask ^= (1 << 2);  // Toggle bit for 'i'
            } else if (ch == 'o') {
                currentMask ^= (1 << 3);  // Toggle bit for 'o'
            } else if (ch == 'u') {
                currentMask ^= (1 << 4);  // Toggle bit for 'u'
            }
            
            // Check if this mask has been seen before
            if (map.ContainsKey(currentMask)) {
                // Calculate the length of the substring
                maxLength = Math.Max(maxLength, i - map[currentMask]);
            } else {
                // Store the first occurrence of this mask
                map[currentMask] = i;
            }
        }
        
        return maxLength;
    }
}