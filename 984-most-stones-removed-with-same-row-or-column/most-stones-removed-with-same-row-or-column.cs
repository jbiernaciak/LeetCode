public class Solution {
    public int RemoveStones(int[][] stones) {
        int n = stones.Length;
        var visited = new HashSet<(int, int)>();
        var graph = new Dictionary<int, List<int>>(); // To map row and column to their corresponding stone indices
        
        // Build the graph: each stone connects via its row and column
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]) {
                    if (!graph.ContainsKey(i)) graph[i] = new List<int>();
                    graph[i].Add(j);
                }
            }
        }
        
        int components = 0;
        
        // Use DFS to count the number of connected components
        for (int i = 0; i < n; i++) {
            if (!visited.Contains((stones[i][0], stones[i][1]))) {
                DFS(i, visited, graph, stones);
                components++;
            }
        }
        
        // The maximum number of stones that can be removed
        return n - components;
    }

    private void DFS(int node, HashSet<(int, int)> visited, Dictionary<int, List<int>> graph, int[][] stones) {
        visited.Add((stones[node][0], stones[node][1]));
        
        foreach (var neighbor in graph[node]) {
            if (!visited.Contains((stones[neighbor][0], stones[neighbor][1]))) {
                DFS(neighbor, visited, graph, stones);
            }
        }
    }
}