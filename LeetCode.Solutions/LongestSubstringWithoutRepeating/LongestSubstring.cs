namespace LeetCode.Solutions.LongestSubstringWithoutRepeating;

/// <summary>
/// https://leetcode.com/problems/longest-substring-without-repeating-characters/
/// </summary>
public class LongestSubstring
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
    }

    public int LengthOfLongestSubstring(string s)
    {
        if (string.IsNullOrEmpty(s))
            return 0;
        
        var substrings = new List<Substring>();

        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            
            substrings.Add(new(letter.ToString(), i));
            
            var applicable = substrings.
                Where(x => x.LastIndex == (i - 1));

            foreach (var app in applicable)
            {
                if(app.Value.Contains(letter))
                    continue;

                app.Value += letter;
                app.LastIndex = i;
            }
        }

        var maxLen = substrings
            .Select(x => x.Length)
            .Max();
        
        return maxLen;
    }
}