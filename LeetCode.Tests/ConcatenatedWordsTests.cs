using LeetCode.Solutions.ConcatenatedWords;

namespace TestProject1;

public class ConcatenatedWordsTests
{
    private ConcatenatedWords _sut;
    
    [SetUp]
    public void SetUp()
    {
        _sut = new ConcatenatedWords();
    }

    [TestCase(new string[] { "cat", "dog", "catdog" }, new string[] { "catdog" })]
    [TestCase(new string[] { "cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat" }, new string[] { "catsdogcats","dogcatsdog","ratcatdogcat" })]
    public void ConcatenatedWords_OrdinaryCase_ShouldPass(string[] input, string[] expected)
    {
        // Act
        var result = _sut.FindAllConcatenatedWordsInADict(input);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [TestCase( "catsdogcats", new string[] { "cat","cats","catsdogcats","dog","dogcatsdog", "rat" } )]
    public void IsWordValid(string word, string[] words)
    {
        // Act
        var result = _sut.IsContained(word, words);

        // Assert
        Assert.True(result);
    }
}