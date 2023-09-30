using LeetCode.Solutions.LongestPalindromicSubstring;

namespace TestProject1;

public class LongestPalindromicSubstringTests
{
    private LongestPalindromeSubstring _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new LongestPalindromeSubstring();
    }

    [TestCase("", "")]
    [TestCase("cbbd", "bb")]
    [TestCase("babad", "bab")]
    public void LongestPalindrome_OrdinaryCase_ShouldCalculateCorrectly(string input, string expected)
    {
        // Act
        var result = _sut.LongestPalindrome(input);
        
        // Assert
        result.Should().Be(expected);
    }

    [TestCase("", true)]
    [TestCase("bab", true)]
    [TestCase("bb", true)]
    [TestCase("cbbc", true)]
    [TestCase("cbbd", false)]
    public void IsPalindrome_ShouldReturnCorrectly(string input, bool expected)
    {
        // Act
        var result = _sut.IsPalindrome(input);
        
        // Assert
        result.Should().Be(expected);
    }
}