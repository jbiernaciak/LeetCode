public class Solution {
    public int PassThePillow(int n, int time) {
        int position = 1; // Start with the first person
        int direction = 1; // 1 means forward; -1 means backward

        for (int t = 0; t < time; t++) {
            // Move the pillow
            position += direction;
            
            // Check if we have to change direction
            if (position == n) {
                direction = -1; // Change direction to backward
            }

            else if (position == 1) {
                direction = 1; // Change direction to forward
            }
        }
        
        return position;
        
    }
}