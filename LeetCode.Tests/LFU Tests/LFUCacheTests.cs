using AutoFixture;
using LeetCode.Solutions.LFUCache;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace TestProject1;

public class LFUCacheTests
{
    private Fixture _fixture = new();
    private LFUCache _sut;
    private int _capacity;
    
    [SetUp]
    public void SetUp()
    {
        _capacity = _fixture.Create<int>();
        _sut = new LFUCache(_capacity);
    }

    [Test]
    public void Constructor_ShouldSetCapacity()
    {
        // Assert
        _sut.Should().NotBeNull();
        _sut.Capacity.Should().Be(_capacity);
    }

    [TestCase(1, 1)]
    [TestCase(2, 4)]
    [TestCase(3, 67)]
    [TestCase(4, 453)]
    public void Put_OrdinaryCase_ShouldInsertItem(int key, int val)
    {
        // Arrange
        var putTime = DateTimeOffset.UtcNow;
        
        // Act
        _sut.Put(key, val);
        
        // Assert
        _sut.CachedItems.TryGetValue(key, out var item);
        item.Value.Should().Be(val);
        item.Frequency.Should().Be(1);
        item.LastUsed.Should().BeAfter(putTime);
    }

    [TestCase(1, 1)]
    [TestCase(2, 4)]
    [TestCase(3, 67)]
    [TestCase(4, 453)]
    public void Put_UpdateCase_ShouldUpdateAndInsertFrequency(int key, int val)
    {
        // Arrange
        var putTime = DateTimeOffset.UtcNow;

        // Act
        _sut.Put(key, val);
        _sut.Put(key, val+1);
        _sut.CachedItems.TryGetValue(key, out var item);

        // Assert
        item.Value.Should().Be(val + 1);
        item.Frequency.Should().Be(2);
        item.LastUsed.Should().BeAfter(putTime);
    }

    [TestCase(new int[] { 1, 2, 3 })]
    public void Put_CapacityFulLCase_ShouldRemoveOldKeys(int[] keys)
    {
        // Arrange
        _sut.Capacity = 2;
        var val = _fixture.Create<int>();
        
        // Act
        foreach (var key in keys)
        {
            _sut.Put(key, val);
        }
        
        // Assert
        var minExpectedIndex = keys.Length - _sut.Capacity;
        for (var i = 0; i < keys.Length; i++)
        {
            _sut.Get(keys[i]).Should().Be(i >= minExpectedIndex ? val : -1);
        }
    }

    [TestCase(1, 1)]
    [TestCase(2, 4)]
    [TestCase(3, 67)]
    [TestCase(4, 453)]
    public void Get_OrdinaryCase_ShouldReturnValue(int key, int val)
    {
        // Arrange
        _sut.Put(key, val);
        var getTime = DateTimeOffset.UtcNow;
        
        // Act
        var res = _sut.Get(key);
        _sut.CachedItems.TryGetValue(key, out var baseline);
        
        // Assert
        res.Should().Be(val);
        baseline.Frequency.Should().Be(2);
        baseline.LastUsed.Should().BeAfter(getTime);
    }
    
    [TestCase(1, 1)]
    [TestCase(2, 4)]
    [TestCase(3, 67)]
    [TestCase(4, 453)]
    public void Get_KeyNotPresentCase_ShouldReturnMinusOne(int key, int val)
    {
        // Arrange
        _sut.Put(key, val);
        
        // Act
        var res = _sut.Get(key + 1);
        
        // Assert
        res.Should().Be(-1);
    }

    [TestCase(new int[] { 1,2, 3})]
    public void GetLastUsedKey_AllFrequenciesSame_ShouldReturnFirstUsed(int[] keys)
    {
        // Arrange
        var val = _fixture.Create<int>();
        foreach (var key in keys)
        {
            _sut.Put(key, val);
        }
        
        // Act
        var res = _sut.GetLeastUsedKey();
        
        // Assert
        res.Should().Be(keys.First());
    }

    [TestCase(1, new int[] { 2, 3, 4 })]
    public void GetLastUsedKey_UsageDifference_ShouldReturnMin(int min, int[] keys)
    {
        // Arrange
        var val = _fixture.Create<int>();
        _sut.Put(min, val);
        foreach (var key in keys)
        {
            _sut.Put(key, val);
            _sut.Put(key, val);
        }
        
        // Act
        var res = _sut.GetLeastUsedKey();
        
        // Assert
        res.Should().Be(min);
    }

    [Test]
    public void LFUCahce_ProvidedTestCase_ShouldMatchExpectedOutput()
    {
        // cnt(x) = the use counter for key x
        // cache=[] will show the last used order for tiebreakers (leftmost element is  most recent)
        
        var lfu = new LFUCache(2);
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
        var lfu = new LFUCache(0);
        lfu.Put(0, 0);
        lfu.Get(0).Should().Be(-1);
    }

    [Test]
    public void LFUCache_FailedTestCase_Test17_ShouldPass()
    {
        var lfu = new LFUCache(2);

        lfu.Get(2).Should().Be(-1);
        lfu.Put(2,6);
        lfu.Get(1).Should().Be(-1);
        lfu.Put(1,5);
        lfu.Put(1,2);
        lfu.Get(1).Should().Be(2);
        lfu.Get(2).Should().Be(6);
    }
}