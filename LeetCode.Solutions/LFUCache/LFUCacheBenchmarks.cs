using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace LeetCode.Solutions.LFUCache;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[RankColumn()]
public class LFUCacheBenchmarks
{
    [Benchmark(Baseline = true)]
    public void Baseline()
    {
        var svc = new LFUCache(10000);
    
        for (var i = 0; i < 10000; i++)
        {
            svc.Put(i,i);
        }

        for (var i = 0; i < 10000; i++)
        {
            svc.Get(i);
        }
    }

    [Benchmark]
    public void CornerSolution()
    {
        var svc = new LfuCorner(10000);
        
        for (var i = 0; i < 10000; i++)
        {
            svc.Put(i,i);
        }

        for (var i = 0; i < 10000; i++)
        {
            svc.Get(i);
        }
    }
}