public class Solution {
    // Arrays for direction vectors: up, down, left, right
    private int[] xDir = {0, 0, -1, 1};
    private int[] yDir = {-1, 1, 0, 0};

    // Checks if the cell (i, j) is within bounds, unvisited, and is land (1)
    public bool IsSafe(int[][] grid, int i, int j, bool[][] visited)
    {
        return (i >= 0 && j >= 0 && i < grid.Length && j < grid[0].Length && !visited[i][j] && grid[i][j] == 1);
    }

    // Recursive DFS function to mark all connected parts of land as visited
    public void IslandCount(int[][] grid, int i, int j, bool[][] visited)
    {
        // Mark the current cell as visited
        visited[i][j] = true;
        
        // Traverse all four possible directions
        for (int k = 0; k < 4; k++)
        {
            int newRow = i + xDir[k];
            int newCol = j + yDir[k];
            // If the new cell is safe, continue the DFS
            if (IsSafe(grid, newRow, newCol, visited))
            {
                IslandCount(grid, newRow, newCol, visited);
            }
        }
    }

    // Function to count the number of connected land components in the grid
    public int CountLand(int[][] grid, bool[][] visited)
    {
        int count = 0;
        // Iterate through all cells in the grid
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                // If we find unvisited land, start a new DFS
                if (grid[i][j] == 1 && !visited[i][j])
                {
                    IslandCount(grid, i, j, visited);
                    count++;
                }
            }
        }
        return count;
    }

    // Main function to solve the problem
    public int MinDays(int[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        
        // Initialize a visited array to track visited cells
        bool[][] visited = new bool[rows][];
        for (int i = 0; i < rows; i++)
        {
            visited[i] = new bool[cols];
        }

        // Check how many connected land components exist initially
        int count = CountLand(grid, visited);
        
        // If more than one island or no land, no days are needed
        if (count > 1 || count == 0) return 0;

        // Simulate the removal of each land cell and check if it splits the island
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1)
                {
                    // Temporarily remove the land cell
                    grid[i][j] = 0;
                    
                    // Check the number of components after removal
                    bool[][] mat = new bool[rows][];
                    for (int k = 0; k < rows; k++)
                    {
                        mat[k] = new bool[cols];
                    }

                    int count2 = CountLand(grid, mat);
                    
                    // Restore the removed cell
                    grid[i][j] = 1;
                    
                    // If the island is now split or there is no land, only one day is needed
                    if (count2 > 1 || count2 == 0)
                    {
                        return 1;   
                    }
                }
            }
        }

        // If removing one cell does not split the island, two days are needed
        return 2;
    }
}
