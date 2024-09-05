public class Solution {
    public int[] MissingRolls(int[] rolls, int mean, int n) {
        // Step 1: Calculate the total sum for n + m rolls
        int m = rolls.Length;
        int totalSum = mean * (n + m);
        
        // Step 2: Calculate the sum of the known rolls
        int observedSum = 0;
        foreach (int roll in rolls) {
            observedSum += roll;
        }
        
        // Step 3: Calculate the missing sum for the n missing rolls
        int missingSum = totalSum - observedSum;
        
        // Step 4: Check if it's feasible to distribute the missing sum among n rolls
        if (missingSum < n || missingSum > 6 * n) {
            return new int[0]; // Impossible to distribute
        }
        
        // Step 5: Compute the base value for each missing roll
        int baseValue = missingSum / n;
        int remainder = missingSum % n;
        
        // Step 6: Prepare the result array
        int[] result = new int[n];
        
        // Step 7: Distribute base values and the remainder
        for (int i = 0; i < n; i++) {
            // Give each roll the base value, and distribute the remainder across the first few rolls
            result[i] = baseValue + (i < remainder ? 1 : 0);
        }
        
        return result;
    }
}