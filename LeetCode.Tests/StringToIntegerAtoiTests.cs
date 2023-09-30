using System.Diagnostics.CodeAnalysis;
using LeetCode.Solutions.StringToInteger;

namespace TestProject1;

[Parallelizable]
[ExcludeFromCodeCoverage]
public class StringToIntegerAtoiTests
{
    [TestCase("42", 42)]
    public void TestCases_ShouldReturnExpectedOutput(string input, int expected)
    {
        // Arrange
        var svc = new StringToIntegerAtoi();
        
        // Act
        var result = svc.MyAtoi(input);
        
        // Arrange
        result.Should().Be(expected);
    }
}