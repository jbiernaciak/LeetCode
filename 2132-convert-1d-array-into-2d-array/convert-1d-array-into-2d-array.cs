public class Solution {
    public int[][] Construct2DArray(int[] original, int m, int n) {
        
        if (m * n != original.Length) {
            return new int[0][]; 
        }

        int[][] result = new int[m][];
        
      
        for (int i = 0; i < m; i++) {
            result[i] = new int[n];
            Array.Copy(original, i * n, result[i], 0, n);
        }

        return result;
    }
}
