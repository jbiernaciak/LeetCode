public class Solution {
    public int MaxDistance(IList<IList<int>> arrays) {
        int n = arrays.Count;

        // Initialize to extreme opposite values
        int minGlobal = int.MaxValue;
        int maxGlobal = int.MinValue;

        int result = 0;

        // Loop to find global min and max excluding current array
        for (int i = 0; i < n; i++) {
            int currentMin = arrays[i][0];
            int currentMax = arrays[i][arrays[i].Count - 1];

            // Calculate maximum distance for this array
            if (i > 0) {
                result = Math.Max(result, Math.Abs(currentMax - minGlobal));
                result = Math.Max(result, Math.Abs(maxGlobal - currentMin));
            }

            // Update global min and max
            minGlobal = Math.Min(minGlobal, currentMin);
            maxGlobal = Math.Max(maxGlobal, currentMax);
        }

        return result;
    }
}