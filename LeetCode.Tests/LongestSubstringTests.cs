using LeetCode.Solutions.LongestSubstringWithoutRepeating;

namespace TestProject1;

public class LongestSubstringTests
{
    private LongestSubstring _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new LongestSubstring();
    }

    [TestCase("abcabcbb", 3)]
    [TestCase("pwwkew", 3)]
    [TestCase("bbbbb", 1)]
    public void LongestSubstring_OrdinaryCase_ShouldReturnExpected(string s, int expected)
    {
        // Act
        var result = _sut.LengthOfLongestSubstring(s);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [TestCase("abcabcbb", 3)]
    [TestCase("pwwkew", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("", 0)]
    public void LongestSubstring2_OrdinaryCase_ShouldReturnExpected(string s, int expected)
    {
        // Arrange
        var sut = new LongestSubstring2();
        
        // Act
        var result = sut.LengthOfLongestSubstring(s);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [TestCase("abcabcbb", 3)]
    [TestCase("pwwkew", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("", 0)]
    public void LongestSubstringStringBuilder_OrdinaryCase_ShouldReturnExpected(string s, int expected)
    {
        // Arrange
        var sut = new LongestSubstringStringBuilder();
        
        // Act
        var result = sut.LengthOfLongestSubstring(s);
        
        // Assert
        result.Should().Be(expected);
    }
}