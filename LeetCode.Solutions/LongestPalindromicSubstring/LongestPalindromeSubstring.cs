namespace LeetCode.Solutions.LongestPalindromicSubstring;

/// <summary>
/// https://leetcode.com/problems/longest-palindromic-substring/
/// </summary>
public class LongestPalindromeSubstring
{
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;

        var substrings = new List<string>();

        foreach (var t in s)
        {
            substrings.Add((substrings.LastOrDefault() ?? "") + t);
        }

        var max = substrings
            .Where(IsPalindrome)
            .MaxBy(x => x.Length);

        return max;
    }

    public bool IsPalindrome(string value)
    {
        for (int i = 0; i < value.Length / 2; i ++)
        {
            if (value[i] != value[^(i+1)])
                return false;
        }

        return true;
    }

}