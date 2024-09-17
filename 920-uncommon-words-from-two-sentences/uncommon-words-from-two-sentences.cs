public class Solution {
    public string[] UncommonFromSentences(string s1, string s2) {
        // Concatenate both sentences with a space in between
        string combined = s1 + " " + s2;

        // Split the combined sentence into words
        string[] words = combined.Split(' ');

        // Group the words and count their occurrences using LINQ
        var wordGroups = words.GroupBy(w => w)
                              .Where(g => g.Count() == 1) // Only select words that appear exactly once
                              .Select(g => g.Key);        // Select the word itself

        // Convert the result to an array and return
        return wordGroups.ToArray();
    }
}