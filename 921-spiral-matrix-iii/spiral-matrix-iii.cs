public class Solution {
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart) {
        // Direction vectors: right, down, left, up
        int[][] directions = new int[][] {
            new int[] {0, 1},   // Right
            new int[] {1, 0},   // Down
            new int[] {0, -1},  // Left
            new int[] {-1, 0}   // Up
        };
        
        int totalCells = rows * cols;
        int[][] result = new int[totalCells][];
        int x = rStart, y = cStart;
        int direction = 0; // Start by moving right
        int steps = 1; // Initial steps in the current direction
        int index = 0;
        
        result[index++] = new int[] {x, y};
        
        while (index < totalCells) {
            for (int i = 0; i < 2; i++) { // Two moves in each step increase cycle
                for (int j = 0; j < steps; j++) {
                    x += directions[direction][0];
                    y += directions[direction][1];
                    if (x >= 0 && x < rows && y >= 0 && y < cols) {
                        result[index++] = new int[] {x, y};
                    }
                }
                direction = (direction + 1) % 4; // Change direction
            }
            steps++; // Increase steps after completing two direction moves
        }
        
        return result;
    }
}