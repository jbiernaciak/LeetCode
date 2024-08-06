public class Solution {
    public int MinimumPushes(string word) {
        // Step 1: Calculate character frequencies
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char ch in word) {
            if (!freq.ContainsKey(ch)) {
                freq[ch] = 0;
            }
            freq[ch]++;
        }
        
        // Step 2: Sort characters by frequency in descending order
        var sortedFreq = freq.Values.OrderByDescending(f => f).ToArray();
        
        // Step 3: Calculate the minimum number of pushes
        int totalPresses = 0;
        int keyPressCount = 1;
        int keysUsed = 0;
        
        for (int i = 0; i < sortedFreq.Length; i++) {
            totalPresses += sortedFreq[i] * keyPressCount;
            keysUsed++;
            if (keysUsed == 8) {  // there are only 8 keys from 2 to 9
                keyPressCount++;
                keysUsed = 0;
            }
        }
        
        return totalPresses;
    }
}