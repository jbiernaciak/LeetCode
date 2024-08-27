public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
        // Step 1: Initialize the probability array
        double[] prob = new double[n];
        prob[start_node] = 1.0;

        // Step 2: Apply Bellman-Ford Algorithm for n-1 iterations
        for (int i = 0; i < n - 1; i++) {
            bool updated = false;

            // Iterate over all edges
            for (int j = 0; j < edges.Length; j++) {
                int a = edges[j][0];
                int b = edges[j][1];
                double p = succProb[j];

                // Relaxation: check if we can improve the probability for node `b` via `a` and vice versa
                if (prob[a] * p > prob[b]) {
                    prob[b] = prob[a] * p;
                    updated = true;
                }
                if (prob[b] * p > prob[a]) {
                    prob[a] = prob[b] * p;
                    updated = true;
                }
            }

            // Early stopping if no update is made
            if (!updated) break;
        }

        // Step 3: Return the probability to reach the end node
        return prob[end_node];
    }
}