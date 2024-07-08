public class Solution {
    public int FindTheWinner(int n, int k) {
       
        // Initialize a list of friends
        List<int> friends = new List<int>();
        for (int i = 1; i <= n; i++) {
            friends.Add(i);
        }
        
        int index = 0; // Starting at the first friend

        // Continua untill only one friend remains
        while (friends.Count > 1) {
            // Find the index of the friend to remove
            index = (index + k - 1) % friends.Count;
            friends.RemoveAt(index);
        }

        // The last remaining friend is a winner
        return friends[0];
    }
}