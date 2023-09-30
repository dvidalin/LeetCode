using Microsoft.VisualBasic;

namespace LeetCode.Solutions.ConcatenatedWords;

public class ConcatenatedWords
{
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        var ret = new List<string>();

        foreach (var word in words)
        {
            var contained = words
                .Where(x => x != word)
                .Where(x => word.Contains(x));

            foreach (var c in contained)
            {
                var x = word.Split(c).Where(x => x.Length > 0);
                var t = 1;
            }
        }

        return ret;
    }

    public bool IsContained(string word, string[] words)
    {
        var contained = words
            .Where(x => x != word)
            .Where(word.Contains)
            .Where(words.Contains);

        foreach (var con in contained)
        {
            var t = word
                .Split(con);

            if (t.All(x => x.Length == 0))
                return true;

            var filtered = t
                .Where(x => x != string.Empty)
                .Where(x => !words.Contains(x));

            if (filtered.Any(x => !words.Contains(x)))
                continue;
            
            return IsContained(word, filtered.ToArray());
        }
        return false;
    }
}