using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace LeetCode.Solutions.AddTwoNumbers;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class AddTwoBenchmarks
{
    private readonly Improved _improved = new Improved();
    private readonly AddTwo _addTwo = new AddTwo();
    private readonly ImprovedMemory _improvedMemory= new ();
    private readonly NoRecursion _noRecursion = new();
    
    private readonly ListNode _firstNode = AddTwo.BuildNode(new int[] { 9, 9, 9, 9, 9, 9, 9 });
    private readonly ListNode _secondNode = AddTwo.BuildNode(new int[] { 9,9,9,9});

    [Benchmark]
    public void Improved()
    {
        _improved.AddTwoNumbers(_firstNode, _secondNode);
    }

    [Benchmark]
    public void Initial()
    {
        _addTwo.AddTwoNumbers(_firstNode, _secondNode);
    }

    [Benchmark]
    public void ImprovedMemory()
    {
        _improvedMemory.AddTwoNumbers(_firstNode, _secondNode);
    }

    [Benchmark]
    public void NoRecursion()
    {
        _noRecursion.AddTwoNumbers(_firstNode, _secondNode);
    }
}