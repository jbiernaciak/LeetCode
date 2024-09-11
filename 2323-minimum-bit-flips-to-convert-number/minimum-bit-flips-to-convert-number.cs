public class Solution {
    public int MinBitFlips(int start, int goal) {
        int flips = 0;

        while (!(start == 0) || !(goal == 0))
        {
            if ((start %2) != (goal % 2))
                flips++;

            start /= 2;
            goal /= 2;    
        }

        return flips;
    }
}