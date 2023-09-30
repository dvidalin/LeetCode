using AutoFixture;
using LeetCode.Solutions.DataStreamDisjointIntervals;

namespace TestProject1;

public class SummaryRangesTests
{
    private SummaryRanges _sut;
    private readonly Fixture _fixture = new();

    [SetUp]
    public void SetUp()
    {
        _sut = new SummaryRanges();
    }

    [Test]
    public void Constructor_OrdinaryCase_ShouldReturnNewObject()
    {
        // Assert
        _sut.Should().NotBeNull();
        _sut.Stream.Should().BeEmpty();
    }

    [Test]
    public void AddNum_OrdinaryCase_ShouldInsertToList()
    {
        // Arrange
        var num = _fixture.Create<int>();
        
        // Act
        _sut.AddNum(num);
        
        // Assert
        _sut.Stream.Should().Contain(num);
    }

    [TestCase(new int[] { 1 }, 1, new int[] { 1, 1 })]
    [TestCase(new int[] { 1, 3 }, 1, new int[] { 1, 1 })]
    [TestCase(new int[] { 1, 2, 4 }, 1, new int[] { 1, 2 })]
    [TestCase(new int[] { 1, 3 }, 3, new int[] { 3, 3 })]
    public void GenerateInterval_OrdinaryCase_ShouldGenerateExpected(int [] input, int startNum, int[] expected)
    {
        // Arrange
        foreach (var inp in input)
        {
            _sut.AddNum(inp);
        }
        
        // Assert
        var result = _sut.GenerateInterval(startNum);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }


    public static IEnumerable<TestCaseData> GetIntervalTestCases()
    {
        yield return new TestCaseData(new int[] { 1 }, new int[][] { new int[] { 1, 1 } });
        yield return new TestCaseData(new int[] { 1, 3 }, new int[][] { new int[] { 1, 1 }, new int[]{3,3} });
        yield return new TestCaseData(new int[] { 1, 3, 7, 2, 6 }, new int[][] { new int[] { 1, 3 },  new int[] { 6, 7 }});
    }

    [Test]
    [TestCaseSource(nameof(GetIntervalTestCases))]
    public void GetIntervals_OrdinaryCase_ShouldGenerateExpected(int[] input, int[][] expected)
    {
        // Arrange
        foreach (var inp in input)
        {
            _sut.AddNum(inp);
        }
        
        // Act
        var result = _sut.GetIntervals();
        
        // Assert
        result.Should().BeEquivalentTo(expected);

    }

}