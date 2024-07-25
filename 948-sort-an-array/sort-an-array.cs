public class Solution
{
    public int[] SortArray(int[] nums)
    {
        quickSort(nums, 0, nums.Length);
        return nums;
    }
    IVec2 Partition(int[] arr, int low, int high)
    {
        int blueRight = low;
        int redLeft = high;
        int grayLeft = high;
        int pivot = arr[(blueRight + grayLeft) / 2];
        while (blueRight != grayLeft - 1)
        {
            if (arr[blueRight] < pivot)
            {
                blueRight++;
            }
            else if (arr[blueRight] > pivot)
            {
                // move entire gray area left
                Swap(ref arr[--redLeft], ref arr[--grayLeft]);
                // move this element in the red area
                Swap(ref arr[blueRight], ref arr[redLeft]);
            }
            else
            {
                // move this element to the gray area
                Swap(ref arr[blueRight], ref arr[--grayLeft]);
            }
        }
        if (arr[blueRight] < pivot)
        {
            blueRight++;
        }
        else if (arr[blueRight] > pivot)
        {
            Swap(ref arr[--redLeft], ref arr[--grayLeft]);
        }
        else
        {
            Swap(ref arr[blueRight], ref arr[--grayLeft]);
        }
        return new IVec2() {x = blueRight, y = redLeft};
    }
    void quickSort(int[] arr, int low, int high)
    {
        if (low < high - 1)
        {
            IVec2 Border = Partition(arr, low, high);
            quickSort(arr, low, Border.x);
            quickSort(arr, Border.y, high);
        }
    }
    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}
struct IVec2
{
    public int x;
    public int y;
}