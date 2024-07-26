public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        int[,] dist = new int[n, n];
        
        // Initialize distance matrix
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i == j) {
                    dist[i, j] = 0;
                } else {
                    dist[i, j] = int.MaxValue / 2; // Use a large number to represent infinity
                }
            }
        }
        
        // Fill the distance matrix with given edges
        foreach (var edge in edges) {
            int from = edge[0];
            int to = edge[1];
            int weight = edge[2];
            dist[from, to] = weight;
            dist[to, from] = weight; // Since the graph is bidirectional
        }
        
        // Floyd-Warshall algorithm to find all pairs shortest paths
        for (int k = 0; k < n; k++) {
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    if (dist[i, j] > dist[i, k] + dist[k, j]) {
                        dist[i, j] = dist[i, k] + dist[k, j];
                    }
                }
            }
        }
        
        // Find the city with the smallest number of reachable cities within the distanceThreshold
        int resultCity = -1;
        int minReachableCities = int.MaxValue;

        for (int i = 0; i < n; i++) {
            int reachableCitiesCount = 0;
            for (int j = 0; j < n; j++) {
                if (i != j && dist[i, j] <= distanceThreshold) {
                    reachableCitiesCount++;
                }
            }
            // Choose the city with the greatest index in case of ties
            if (reachableCitiesCount <= minReachableCities) {
                minReachableCities = reachableCitiesCount;
                resultCity = i;
            }
        }
        
        return resultCity;
    }
}