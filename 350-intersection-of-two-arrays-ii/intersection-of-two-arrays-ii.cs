using System;
using System.Collections.Generic;

public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        List<int> result = new List<int>();
        
        Array.Sort(nums1);
        Array.Sort(nums2);
        
        int i = 0, j = 0;
        
        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] < nums2[j]) {
                i++;
            } else if (nums1[i] > nums2[j]) {
                j++;
            } else {
                result.Add(nums1[i]);
                i++;
                j++;
            }
        }
        
        return result.ToArray();
    }
}