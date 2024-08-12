public class KthLargest {
    private List<int> numsList;
    private int k;
    public KthLargest(int k, int[] nums) {
        this.k = k;
        numsList = new List<int>(nums);
        numsList.Sort();
    }
    
    public int Add(int val) {
        // Insert the value into the sorted list
        int index = numsList.BinarySearch(val);
        if (index < 0) index = ~index;
        numsList.Insert(index, val);
        
        // Return the kth largest element
        return numsList[numsList.Count - k];
    }
}