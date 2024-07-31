public class Solution {
    public int MinHeightShelves(int[][] books, int shelfWidth) {
        var memo = new Dictionary<int, int>();
        return MinHeight(books, shelfWidth, 0, memo);
    }
    private int MinHeight(int[][] books, int shelfWidth, int index, Dictionary<int, int> memo) {
        if (index == books.Length) {
            return 0;
        }
        
        if (memo.ContainsKey(index)) {
            return memo[index];
        }
        
        int totalThickness = 0;
        int maxHeight = 0;
        int minHeight = int.MaxValue;
        
        for (int i = index; i < books.Length; i++) {
            totalThickness += books[i][0];
            if (totalThickness > shelfWidth) {
                break;
            }
            maxHeight = Math.Max(maxHeight, books[i][1]);
            minHeight = Math.Min(minHeight, maxHeight + MinHeight(books, shelfWidth, i + 1, memo));
        }
        
        memo[index] = minHeight;
        return minHeight;
    }
}