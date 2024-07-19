public class Solution {
    public IList<int> LuckyNumbers (int[][] matrix) {
        List<int> luckyNumbers = new List<int>();
        int m = matrix.Length;
        int n = matrix[0].Length;
        
        // Step 1: Find the minimum element in each row
        int[] minInRow = new int[m];
        int[] minInRowColIndex = new int[m];
        
        for (int i = 0; i < m; i++) {
            int minValue = matrix[i][0];
            int minColIndex = 0;
            for (int j = 1; j < n; j++) {
                if (matrix[i][j] < minValue) {
                    minValue = matrix[i][j];
                    minColIndex = j;
                }
            }
            minInRow[i] = minValue;
            minInRowColIndex[i] = minColIndex;
        }
        
        // Step 2: Check if the minimum elements are also the maximum in their columns
        for (int i = 0; i < m; i++) {
            int minValue = minInRow[i];
            int col = minInRowColIndex[i];
            bool isMaxInCol = true;
            for (int k = 0; k < m; k++) {
                if (matrix[k][col] > minValue) {
                    isMaxInCol = false;
                    break;
                }
            }
            if (isMaxInCol) {
                luckyNumbers.Add(minValue);
            }
        }
        
        return luckyNumbers;
    }
}