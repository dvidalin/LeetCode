namespace LeetCode.Solutions.ReverseInteger;

/// <summary>
/// https://leetcode.com/problems/reverse-integer/
/// <para>
/// Given a signed 32-bit integer x, return x with its digits reversed.
/// If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.
/// </para>
/// </summary>
public class ReverseInteger
{
    public int Reverse(int x)
    {
        var digits = new List<int>();

        var isNegative = x < 0;

        if (x == int.MinValue)
            return 0;
        
        x = Math.Abs(x);
        
        do
        {
            var digit = x % 10;
            digits.Add(digit);
            x /= 10;
        } while (x > 0);

        var res = digits
            .Select((t, i) => t * Math.Pow(10, digits.Count - i - 1))
            .Sum();
        
        if (isNegative)
            res *= -1;
        
        if (res >= int.MaxValue || res <= int.MinValue)
            return 0;

        return (int)res;
    }
}