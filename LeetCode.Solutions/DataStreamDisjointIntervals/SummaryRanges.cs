namespace LeetCode.Solutions.DataStreamDisjointIntervals;

/// <summary>
/// https://leetcode.com/problems/data-stream-as-disjoint-intervals/description/
/// </summary>
public class SummaryRanges
{
    public readonly HashSet<int> Stream = new HashSet<int>();

    public SummaryRanges() {
        
    }
    
    public void AddNum(int value) {
        Stream.Add(value);
    }
    
    public int[][] GetIntervals()
    {
        if(Stream.Count == 0)
            return Array.Empty<int[]>();

        var min = Stream.Min();

        var ret = new List<int[]>();
        
        do
        {
            var interval = GenerateInterval(min);
            ret.Add(interval);

            min = Stream
                .Where(x => x > interval.Max())
                .DefaultIfEmpty()
                .Min();

        } while (min != default);

        return ret.ToArray();
    }

    public int[] GenerateInterval(int start)
    {
        var max = start;

        while (Stream.TryGetValue(max + 1, out var next))
        {
            max = next;
        }

        return new[] { start, max };
    }
}