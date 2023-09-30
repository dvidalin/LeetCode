namespace LeetCode.Solutions.LongestSubstringWithoutRepeating;

/// <summary>
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
public class LongestSubstring2
{
    class Substring
    {
        public string Value;
        public int LastIndex;

        public int Length => Value.Length;

        public Substring(string val, int index)
        {
            Value = val;
            LastIndex = index;
        }
  
        public override string ToString()
            => Value;

        public void AddValue(char c, int index)
        {
            Value += c.ToString();
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
            substrings.Add(new(s[i].ToString(), i));
            foreach (var subs in substrings)
            {
                if (!subs.Value.Contains(s[i]))
                {
                    subs.AddValue(s[i], i);
                
                    if (subs.Length > maxLen)
                        maxLen = subs.Length;
                }
            }

            substrings
                .RemoveAll(x => x.LastIndex != i);
        }

        return maxLen;
    }
}