public class Solution {
    public int ChalkReplacer(int[] chalk, int k) {
        long totalChalkNeeded = 0;
        foreach (int studentChalkUse in chalk) {
            totalChalkNeeded += studentChalkUse;
        }
        
        int remainingChalk = (int)(k % totalChalkNeeded);
        
        for (int studentIndex = 0; studentIndex < chalk.Length; studentIndex++) {
            if (remainingChalk < chalk[studentIndex]) {
                return studentIndex;
            }
            remainingChalk -= chalk[studentIndex];
        }
        
        return 0;
    }
}