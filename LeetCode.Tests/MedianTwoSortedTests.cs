using LeetCode.Solutions.MedianOfTwoSortedArrays;

namespace TestProject1;

public class MedianTwoSortedTests
{
    private MedianTwoSorted _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new MedianTwoSorted();
    }

    [TestCase(new int[] { 1, 2, 3 }, 2)]
    [TestCase(new int[] { 1, 2, 3, 4 }, 2.5)]
    [TestCase(new int[] { 1, 3 }, 2)]
    public void GetMedian_OrdinaryCase_ShouldCalculateCorrectly(int[] input, double expected)
    {
        // Act
        var result = MedianTwoSorted.GetMedian(input);
        
        // Assert
        result.Should().Be(expected);
    }

    [TestCase(new int[] {1,3}, new int[] {2}, new int[] {1,2,3})]
    [TestCase(new int[] {1,2}, new int[] {3,4}, new int[] {1,2,3,4})]
    [TestCase(new int[] {1,2}, new int[] {3}, new int[] {1,2,3})]
    [TestCase(new int[] {1}, new int[] {3,4}, new int[] {1,3,4})]
    [TestCase(new int[] {}, new int[] {}, new int[] {})]
    [TestCase(new int[] {1,2}, new int[] {}, new int[] {1,2})]
    [TestCase(new int[] {}, new int[] {3,4}, new int[] {3,4})]
    public void MergeArrays_OrdinaryCase_ShouldMergeAndKeepSort(int[] arr1, int[] arr2, int[] expected)
    {
        // Act
        var result = MedianTwoSorted.MergeArrays(arr1, arr2);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestCase(new int[] {1,3}, new int[] {2}, 2)]
    [TestCase(new int[] {1,2}, new int[] {3,4}, 2.5)]
    public void FindMedianSortedArrays_OrdinaryCase_ShouldCalculateCorrectly(int[] arr1, int[] arr2, double expected)
    {
        // Act
        var result = _sut.FindMedianSortedArrays(arr1, arr2);
        
        // Assert
        result.Should().Be(expected);
    }

}