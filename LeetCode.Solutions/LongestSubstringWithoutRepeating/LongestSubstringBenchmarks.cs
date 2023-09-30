using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace LeetCode.Solutions.LongestSubstringWithoutRepeating;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class LongestSubstringBenchmarks
{
    [Benchmark(Baseline = true)]
    public void Baseline()
    {
        var sut = new LongestSubstring();
        sut.LengthOfLongestSubstring(BenchmarkHelper.GetInput());
    }

    [Benchmark]
    public void WithSubstringRemoval()
    {
        var sut = new LongestSubstring2();
        sut.LengthOfLongestSubstring(BenchmarkHelper.GetInput());
    }
    
    [Benchmark]
    public void WithStringBuilder()
    {
        var sut = new LongestSubstringStringBuilder();
        sut.LengthOfLongestSubstring(BenchmarkHelper.GetInput());
    }
}