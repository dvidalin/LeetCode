using System.Text;

namespace LeetCode.Solutions.LongestSubstringWithoutRepeating;

/// <summary>
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
public class LongestSubstringStringBuilder
{
    class Substring
    {
        public int LastIndex;
        public StringBuilder Value = new StringBuilder();

        public int Length => Value.Length;

        public Substring(char val, int index)
        {
            Value.Append(val);
            LastIndex = index;
        }
  
        public override string ToString()
            => Value.ToString();

        public void AddValue(char c, int index)
        {
            Value.Append(c);
            LastIndex = index;
        }
    }

    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;

        var maxLen = 1;
        var substrings = new List<Substring>();

        for (var i = 0; i < s.Length; i++)
        {
            substrings.Add(new(s[i], i));
            foreach (var subs in substrings.Where(subs => !subs.Value.ToString().Contains(s[i])))
            {
                subs.AddValue(s[i], i);
                
                if (subs.Length > maxLen)
                    maxLen = subs.Length;
            }

            substrings
                .RemoveAll(x => x.LastIndex != i);
        }

        return maxLen;
    }
}