public class Solution {
    public string KthDistinct(string[] arr, int k) {
        Dictionary<string, int> frequencyMap = new Dictionary<string, int>();
        List<string> distinctStrings = new List<string>();
        
        // Count frequencies and track distinct strings
        foreach (string str in arr) {
            if (!frequencyMap.ContainsKey(str)) {
                frequencyMap[str] = 0; // Initialize frequency count
                distinctStrings.Add(str); // Track distinct strings in order
            }
            frequencyMap[str]++; // Increment frequency count
        }
        
        // Find the kth distinct string
        foreach (string str in distinctStrings) {
            if (frequencyMap[str] == 1) {
                k--;
                if (k == 0) {
                    return str; // Found the kth distinct string
                }
            }
        }
        
        return ""; // If fewer than k distinct strings are found
    }
}