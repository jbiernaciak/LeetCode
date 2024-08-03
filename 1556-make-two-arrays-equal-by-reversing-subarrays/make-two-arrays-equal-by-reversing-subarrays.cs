public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        // Check if both arrays have the same length
        if (target.Length != arr.Length)
            return false;
        
        // Frequency counters
        Dictionary<int, int> targetFreq = new Dictionary<int, int>();
        Dictionary<int, int> arrFreq = new Dictionary<int, int>();
        
        // Populate frequency counters for target
        foreach (int num in target) {
            if (targetFreq.ContainsKey(num)) {
                targetFreq[num]++;
            } else {
                targetFreq[num] = 1;
            }
        }
        
        // Populate frequency counters for arr
        foreach (int num in arr) {
            if (arrFreq.ContainsKey(num)) {
                arrFreq[num]++;
            } else {
                arrFreq[num] = 1;
            }
        }
        
        // Compare frequency counters
        foreach (var kvp in targetFreq) {
            int num = kvp.Key;
            int countTarget = kvp.Value;
            
            if (!arrFreq.ContainsKey(num) || arrFreq[num] != countTarget) {
                return false;
            }
        }
        
        return true;
    }
}