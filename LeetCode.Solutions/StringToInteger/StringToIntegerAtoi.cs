using System.Text;

namespace LeetCode.Solutions.StringToInteger;

/// <summary>
/// https://leetcode.com/problems/string-to-integer-atoi/
/// </summary>
public class StringToIntegerAtoi
{
    public int MyAtoi(string s)
    {
        s = s.TrimStart();
        var isNegative = false;

        var sb = new StringBuilder();
        
        switch (s[0])
        {
            case '-':
                isNegative = true;
                s = s[1..];
                break;
            case '+':
                s = s[1..];
                break;
        }

        foreach (var c in s.TakeWhile(c => int.TryParse(c.ToString(), out _)))
        {
            sb.Append(c);
        }

        var isDouble = double.TryParse(sb.ToString(), out var result);

        if (isNegative)
            result *= -1;

        try
        {
        }

        return 0;
    }
}