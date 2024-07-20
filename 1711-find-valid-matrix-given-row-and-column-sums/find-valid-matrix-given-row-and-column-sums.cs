public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int m = rowSum.Length;
        int n = colSum.Length;
        int[][] result = new int[m][];
        
        for (int i = 0; i < m; i++) {
            result[i] = new int[n];
        }
        
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                int value = Math.Min(rowSum[i], colSum[j]);
                result[i][j] = value;
                rowSum[i] -= value;
                colSum[j] -= value;
            }
        }
        
        return result;
    }
}