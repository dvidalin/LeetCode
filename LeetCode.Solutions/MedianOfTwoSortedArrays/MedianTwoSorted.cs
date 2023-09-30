namespace LeetCode.Solutions.MedianOfTwoSortedArrays;

/// <summary>
/// https://leetcode.com/problems/median-of-two-sorted-arrays/
/// </summary>
public class MedianTwoSorted
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var newArr = MergeArrays(nums1, nums2);
        return GetMedian(newArr);
    }
    
    public static double GetMedian(int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return 0;

        var mid = arr.Length / 2;
        if (arr.Length % 2 != 0)
            return arr[mid];

        var val1 = (double)arr[mid];
        var val2 = (double)arr[mid - 1];
        return (val1 + val2) / 2;
    }

    public static int[] MergeArrays(int[] arr1, int[] arr2)
    {
        var firstIndex = 0;
        var secondIndex = 0;
        var resIndex = 0;
        var res = new int[arr1.Length + arr2.Length];
        
        //Go through both arrays while they contain elements
        while (firstIndex < arr1.Length && secondIndex < arr2.Length)
        {
            if (arr1[firstIndex] < arr2[secondIndex])
            {
                res[resIndex] = arr1[firstIndex];
                firstIndex++;
            }
            else
            {
                res[resIndex] = arr2[secondIndex];
                secondIndex++;
            }

            resIndex++;
        }
        
        //Go through first array and add elements if any left
        while (firstIndex < arr1.Length)
        {
            res[resIndex] = arr1[firstIndex];
            resIndex++;
            firstIndex++;
        }
        
        //Go through second array and add elements if any left
        while(secondIndex < arr2.Length)
        {
            res[resIndex] = arr2[secondIndex];
            secondIndex++;
            resIndex++;
        }
        return res;
    }

}