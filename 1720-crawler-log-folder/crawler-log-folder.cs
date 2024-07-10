public class Solution {
    public int MinOperations(string[] logs) {
        int depth = 0;

        foreach (string log in logs) {
            if (log.Equals("../")) {
                if (depth > 0) {
                    depth --;
                }
            }

            else if (!log.Equals("./")) {
                depth ++;
            }
        }

        return depth;
    }
}