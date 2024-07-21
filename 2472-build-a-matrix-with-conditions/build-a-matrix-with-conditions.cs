public class Solution {
    public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) {
        var rowOrder = TopologicalSort(k, rowConditions);
        var colOrder = TopologicalSort(k, colConditions);

        if (rowOrder == null || colOrder == null) return new int[0][];

        var matrix = new int[k][];
        for (int i = 0; i < k; i++) {
            matrix[i] = new int[k];
        }

        var position = new Dictionary<int, (int row, int col)>();

        for (int i = 0; i < k; i++) {
            position[rowOrder[i]] = (i, 0);
        }

        for (int i = 0; i < k; i++) {
            var (row, _) = position[colOrder[i]];
            position[colOrder[i]] = (row, i);
        }

        foreach (var kvp in position) {
            matrix[kvp.Value.row][kvp.Value.col] = kvp.Key;
        }

        return matrix;
    }

    private List<int> TopologicalSort(int k, int[][] conditions) {
        var graph = new Dictionary<int, List<int>>();
        var inDegree = new Dictionary<int, int>();

        for (int i = 1; i <= k; i++) {
            graph[i] = new List<int>();
            inDegree[i] = 0;
        }

        foreach (var condition in conditions) {
            int u = condition[0], v = condition[1];
            graph[u].Add(v);
            inDegree[v]++;
        }

        var queue = new Queue<int>();
        foreach (var node in inDegree.Keys) {
            if (inDegree[node] == 0) queue.Enqueue(node);
        }

        var order = new List<int>();
        while (queue.Count > 0) {
            var node = queue.Dequeue();
            order.Add(node);
            foreach (var neighbor in graph[node]) {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
            }
        }

        return order.Count == k ? order : null;
    }
}