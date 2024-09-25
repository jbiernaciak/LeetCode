public class Solution {
    public class TrieNode {
        public Dictionary<char, TrieNode> Children;
        public int Count; // keeps track of how many words share this prefix
        
        public TrieNode() {
            Children = new Dictionary<char, TrieNode>();
            Count = 0;
        }
    }

    private void Insert(TrieNode root, string word) {
        TrieNode currentNode = root;
        foreach (char c in word) {
            if (!currentNode.Children.ContainsKey(c)) {
                currentNode.Children[c] = new TrieNode();
            }
            currentNode = currentNode.Children[c];
            currentNode.Count++;  // increase the prefix count
        }
    }

    private int GetScore(TrieNode root, string word) {
        TrieNode currentNode = root;
        int score = 0;
        foreach (char c in word) {
            currentNode = currentNode.Children[c];
            score += currentNode.Count;
        }
        return score;
    }
    public int[] SumPrefixScores(string[] words) {
        TrieNode root = new TrieNode();
        
        // Step 1: Insert all words into the Trie
        foreach (string word in words) {
            Insert(root, word);
        }
        
        // Step 2: Calculate the score for each word
        int[] result = new int[words.Length];
        for (int i = 0; i < words.Length; i++) {
            result[i] = GetScore(root, words[i]);
        }
        
        return result;
    }
}