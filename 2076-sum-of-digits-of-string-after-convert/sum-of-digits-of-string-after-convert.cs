public class Solution {
    public int GetLucky(string s, int k) {
        // Step 1: Convert each character in the string to its position in the alphabet
        int sum = 0;
        foreach (char c in s) {
            int value = c - 'a' + 1;
            sum += SumOfDigits(value);
        }
        
        // Step 2: Perform the transformation k times
        for (int i = 1; i < k; i++) {
            sum = SumOfDigits(sum);
        }
        
        return sum;
    }

    private int SumOfDigits(int num) {
        int sum = 0;
        while (num > 0) {
            sum += num % 10;
            num /= 10;
        }
        return sum;
    }
}