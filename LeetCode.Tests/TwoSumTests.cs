using LeetCode.Solutions.TwoSum;

namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase(new int[] {2,7,11,15}, 9, new int[] {0,1})]
    [TestCase(new int[] {3,2,4}, 6, new int[] {1,2})]
    [TestCase(new int[] {3,3}, 6, new int[] {0,1})]
    [TestCase(new int[] {1,1,1,1,1,4,1,1,1,1,1,7,1,1,1,1,1}, 11, new int[] {5,11})]
    public void Test1(int[] arr, int target, int[] expected)
    {
        // Act
        var result = TwoSum.Execute(arr, target);
        
        // Arrange
        result.Should().HaveCount(2);
        result.Should().Contain(expected);
    }
}