public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int totalDrunk = 0;
        int emptyBottles = 0;

        while (numBottles > 0) {
            // Drink the full bottles
            totalDrunk += numBottles;
            emptyBottles += numBottles;
            numBottles = 0;

            // Exchange empty bottles for full bottles
            if (emptyBottles >= numExchange) {
                numBottles = emptyBottles / numExchange;
                emptyBottles = emptyBottles % numExchange;
            }
        }
        
        return totalDrunk;
    }
}