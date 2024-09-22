public class Solution {
    public int FindKthNumber(int n, int k) {
        int current = 1; // Start with 1 since we consider numbers starting from 1
        k--; // Decrement k because the first element (1) is already considered

        while (k > 0)
        {
            // Count the steps between current prefix and the next prefix
            long steps = CountSteps(n, current, current + 1);
            
            if (steps <= k)
            {
                // Move to the next sibling
                current++;
                k -= (int)steps;
            }
            else
            {
                // Move down to the next level
                current *= 10;
                k--;
            }
        }

        return current;
    }

    // Helper function to count the number of steps between two prefixes
    private long CountSteps(int n, long current, long next)
    {
        long steps = 0;

        // Calculate the steps between current and next prefixes up to n
        while (current <= n)
        {
            steps += Math.Min(n + 1, next) - current;
            current *= 10;
            next *= 10;
        }

        return steps;
    }
}