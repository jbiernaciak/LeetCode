public class Solution {
    public int[] SortJumbled(int[] mapping, int[] nums) {
        // Helper function to get the mapped value of a number
        int GetMappedValue(int num)
        {
            string strNum = num.ToString();
            char[] mappedChars = new char[strNum.Length];
            for (int i = 0; i < strNum.Length; i++)
            {
                int digit = strNum[i] - '0';
                mappedChars[i] = (char)(mapping[digit] + '0');
            }
            return int.Parse(new string(mappedChars));
        }

        // Create an array of tuples where each tuple is (original number, mapped value)
        var mappedNums = nums.Select(num => (num, GetMappedValue(num))).ToArray();

        // Sort the tuples based on the mapped values, maintaining the original relative order
        Array.Sort(mappedNums, (x, y) => x.Item2.CompareTo(y.Item2));

        // Extract the sorted original numbers from the sorted tuples
        return mappedNums.Select(tuple => tuple.num).ToArray();
    }
}
