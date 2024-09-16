public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        // If we have more than 1440 time points, there must be duplicates.
        if (timePoints.Count > 1440) {
            return 0;
        }
        
        // Step 1: Create a boolean array to represent each minute of the day
        bool[] timeSeen = new bool[1440];
        
        // Step 2: Convert each time to minutes since midnight and mark in the boolean array
        foreach (var time in timePoints) {
            int minutes = ConvertToMinutes(time);
            // If the same time already exists, return 0 (since duplicate times give min diff of 0)
            if (timeSeen[minutes]) {
                return 0;
            }
            timeSeen[minutes] = true;
        }
        
        // Step 3: Find the minimum difference
        int prevTime = -1; // Variable to keep track of previous time point
        int firstTime = -1; // First time point of the day
        int lastTime = -1; // Last time point of the day
        int minDifference = int.MaxValue;

        for (int i = 0; i < 1440; i++) {
            if (timeSeen[i]) {
                if (prevTime != -1) {
                    // Calculate the difference between consecutive times
                    minDifference = Math.Min(minDifference, i - prevTime);
                }
                prevTime = i;
                
                // Record the first and last time points
                if (firstTime == -1) {
                    firstTime = i;
                }
                lastTime = i;
            }
        }
        
        // Step 4: Handle the circular case (difference between the first and last time of the day)
        minDifference = Math.Min(minDifference, 1440 + firstTime - lastTime);
        
        return minDifference;
    }

    // Helper function to convert "HH:MM" to minutes since midnight
    private int ConvertToMinutes(string time) {
        int hours = int.Parse(time.Substring(0, 2));
        int minutes = int.Parse(time.Substring(3, 2));
        return hours * 60 + minutes;
    }
}