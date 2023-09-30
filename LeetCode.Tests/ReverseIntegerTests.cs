using System.Diagnostics.CodeAnalysis;
using LeetCode.Solutions.ReverseInteger;

namespace TestProject1;

[Parallelizable]
[ExcludeFromCodeCoverage]
public class ReverseIntegerTests
{
    [TestCase(123, 321)]
    [TestCase(-123, -321)]
    [TestCase(120, 21)]
    [TestCase(1534236469, 0)]
    public void ReverseInteger_TestCases_ShouldReturnExpectedOutput(int input, int expected)
    {
        // Arrange
        var svc = new ReverseInteger();
        
        // Act
        var res = svc.Reverse(input);
        
        // Assert
        res.Should().Be(expected);
    }

    [TestCase(-2147483648, 0)]
    public void ReverseInteger_FailedTests_ShouldReturnExpectedOutput(int input, int expected)
    {
        // Arrange
        var svc = new ReverseInteger();
        
        // Act
        var res = svc.Reverse(input);
        
        // Assert
        res.Should().Be(expected);
    }
    

}