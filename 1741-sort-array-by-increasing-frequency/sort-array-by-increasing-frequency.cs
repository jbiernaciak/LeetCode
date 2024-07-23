public class Solution
{
    public int[] FrequencySort(int[] nums)
    {
        // Step 1: Count the frequency of each value
        var frequencyMap = nums.GroupBy(num => num)
                               .ToDictionary(group => group.Key, group => group.Count());

        // Step 2: Sort the values first by frequency in ascending order, then by value in descending order
        var sorted = nums.OrderBy(num => frequencyMap[num])
                         .ThenByDescending(num => num)
                         .ToArray();

        return sorted;
    }
}