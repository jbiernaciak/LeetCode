public class Solution {
    public int CountSeniors(string[] details) {
        return details.Count(detail => int.Parse(detail.Substring(11, 2)) > 60);
    }
}