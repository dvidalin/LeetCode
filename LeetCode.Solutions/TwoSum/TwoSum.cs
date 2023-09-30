namespace LeetCode.Solutions.TwoSum;

/// <summary>
/// https://leetcode.com/problems/two-sum/
/// </summary>
public static class TwoSum
{
    public static int[] Execute(int[] nums, int target)
    {
        // keep track of visited items and their indexes
        var dict = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var r = target - nums[i];

            // check if difference between target and visited number matches previous number
            if (dict.TryGetValue(r, out var value))
                // if matches, that's it we have result
                return new[] { value, i };
            
            // if not, add visited number to dictionary
            dict.TryAdd(nums[i], i);
        }

        return null;
    }
}