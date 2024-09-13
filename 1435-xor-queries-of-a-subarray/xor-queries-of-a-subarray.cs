public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        for (int i = 1; i < arr.Length; i++) {
            arr[i] ^= arr[i - 1];
        }
        
        return queries.Select(q => {
            int start = q[0], end = q[1];
            return start > 0 ? arr[end] ^ arr[start - 1] : arr[end];
        }).ToArray();
    }
}