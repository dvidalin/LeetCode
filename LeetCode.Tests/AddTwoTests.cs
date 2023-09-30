using LeetCode.Solutions.AddTwoNumbers;


namespace TestProject1;

public class AddTwoTests
{
    [TestCase(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 8 })]
    [TestCase(new int[] { 9,9,9,9,9,9,9 }, new int[] { 9,9,9,9}, new int[] { 8,9,9,9,0,0,0,1 })]
    [TestCase(new int[] { 0 }, new int[] { 0}, new int[] { 0 })]
    public void OrdinaryCase(int[] first, int[] second, int[] expected)
    {
        // Arrange
        var l1 = AddTwo.BuildNode(first);
        var l2 = AddTwo.BuildNode(second);
        var l3 = AddTwo.BuildNode(expected);
        var svc = new AddTwo();
        
        // Act
        var res = svc.AddTwoNumbers(l1, l2);
        
        // Assert
        res.Should().BeEquivalentTo(l3);
    }
    
    [TestCase(new int[] { 2, 4, 3 }, new int[] { 5, 6, 4 }, new int[] { 7, 0, 8 })]
    [TestCase(new int[] { 9,9,9,9,9,9,9 }, new int[] { 9,9,9,9}, new int[] { 8,9,9,9,0,0,0,1 })]
    [TestCase(new int[] { 0 }, new int[] { 0}, new int[] { 0 })]
    public void ImprovedCase(int[] first, int[] second, int[] expected)
    {
        // Arrange
        var l1 = AddTwo.BuildNode(first);
        var l2 = AddTwo.BuildNode(second);
        var l3 = AddTwo.BuildNode(expected);
        var svc = new Improved();
        
        // Act
        var res = svc.AddTwoNumbers(l1, l2);
        
        // Assert
        res.Should().BeEquivalentTo(l3);
    }
    
}