public class Solution {
    public int CountSubIslands(int[][] grid1, int[][] grid2) {
                int m = grid2.Length;
        int n = grid2[0].Length;
        int subIslandsCount = 0;

        // Directions array for moving up, down, left, and right
        int[][] directions = new int[][] {
            new int[] {0, 1},   // Right
            new int[] {1, 0},   // Down
            new int[] {0, -1},  // Left
            new int[] {-1, 0}   // Up
        };

        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                // If the current cell in grid2 is land, check if it forms a sub-island
                if (grid2[i][j] == 1) {
                    if (BFS(grid1, grid2, i, j, directions)) {
                        subIslandsCount++;
                    }
                }
            }
        }

        return subIslandsCount;
    }

    private bool BFS(int[][] grid1, int[][] grid2, int startX, int startY, int[][] directions) {
        int m = grid2.Length;
        int n = grid2[0].Length;
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(new int[] { startX, startY });

        // Assume the current island is a sub-island unless proven otherwise
        bool isSubIsland = true;
        
        // Mark the starting cell as visited
        grid2[startX][startY] = 0;

        while (queue.Count > 0) {
            int[] cell = queue.Dequeue();
            int x = cell[0], y = cell[1];

            // If the corresponding cell in grid1 is not land, this island is not a sub-island
            if (grid1[x][y] == 0) {
                isSubIsland = false;
            }

            // Explore the 4 possible directions
            foreach (var dir in directions) {
                int newX = x + dir[0];
                int newY = y + dir[1];

                // If the new cell is within bounds and is land in grid2, explore it
                if (newX >= 0 && newX < m && newY >= 0 && newY < n && grid2[newX][newY] == 1) {
                    queue.Enqueue(new int[] { newX, newY });
                    grid2[newX][newY] = 0; // Mark the cell as visited
                }
            }
        }

        return isSubIsland;
    }
}