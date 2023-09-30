using AutoFixture;
using LeetCode.Solutions.LFUCache;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TestProject1;

public class LFUCornerTests
{
    private Fixture _fixture = new();
    private LfuCorner _sut;
    private int _capacity;
    
    [SetUp]
    public void SetUp()
    {
        _capacity = _fixture.Create<int>();
        _sut = new LfuCorner(_capacity);
    }

    
    [Test]
    public void LFUCahce_ProvidedTestCase_ShouldMatchExpectedOutput()
    {
        // cnt(x) = the use counter for key x
        // cache=[] will show the last used order for tiebreakers (leftmost element is  most recent)
        
        var lfu = new LfuCorner(2);
        lfu.Put(1, 1);      // cache=[1,_], cnt(1)=1
        lfu.Put(2, 2);      // cache=[2,1], cnt(2)=1, cnt(1)=1
        lfu.Get(1)
            .Should().Be(1);      // return 1
                            // cache=[1,2], cnt(2)=1, cnt(1)=2
        lfu.Put(3, 3);      // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
                            // cache=[3,1], cnt(3)=1, cnt(1)=2
        lfu.Get(2)
            .Should().Be(-1);      // return -1 (not found)
        lfu.Get(3)
            .Should().Be(3);      // return 3
                            // cache=[3,1], cnt(3)=2, cnt(1)=2
        lfu.Put(4, 4);      // Both 1 and 3 have the same cnt, but 1 is LRU, invalidate 1.
                            // cache=[4,3], cnt(4)=1, cnt(3)=2
        lfu.Get(1)
            .Should().Be(-1);      // return -1 (not found)
        lfu.Get(3)
            .Should().Be(3);      // return 3
                            // cache=[3,4], cnt(4)=1, cnt(3)=3
        lfu.Get(4)
            .Should().Be(4);      // return 4
                            // cache=[4,3], cnt(4)=2, cnt(3)=3

    }

    [Test]
    public void LFUCache_FailedTestCase_EmptyCapacity_ShouldPass()
    {
        var lfu = new LfuCorner(0);
        lfu.Put(0, 0);
        lfu.Get(0).Should().Be(-1);
    }

    [Test]
    public void LFUCache_FailedTestCase_Test17_ShouldPass()
    {
        var lfu = new LfuCorner(2);

        lfu.Get(2).Should().Be(-1);
        lfu.Put(2,6);
        lfu.Get(1).Should().Be(-1);
        lfu.Put(1,5);
        lfu.Put(1,2);
        lfu.Get(1).Should().Be(2);
        lfu.Get(2).Should().Be(6);
    }
}