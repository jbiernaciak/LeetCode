public class Solution {
    public double AverageWaitingTime(int[][] customers) {
        int n = customers.Length;
        int currentTime = 0;
        long totalWaitingTime = 0;

        for (int i = 0; i < n; i++) {
            int arrivalTime = customers[i][0];
            int prepTime = customers[i][1];

            if (currentTime < arrivalTime) {
                currentTime = arrivalTime;
            }

            currentTime += prepTime;
            totalWaitingTime += currentTime - arrivalTime;
        }

        return (double)totalWaitingTime / n;
    }
}