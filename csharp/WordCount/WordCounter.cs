using System.Text.RegularExpressions;

namespace WordCount;

// Your three methods. SplitWords is written for you. The comment above
// each of the others says what it should return, with examples. Replace
// each return line with your own code, and write the method's growth
// rate in its comment.
public static class WordCounter
{
    // The words of a text, in order, in lowercase: every run of the letters a to z.
    // "The gym opens. The gym closes!" -> ["the", "gym", "opens", "the", "gym", "closes"]
    public static List<string> SplitWords(string text)
    {
        List<string> words = new List<string>();
        foreach (Match match in Regex.Matches(text.ToLowerInvariant(), "[a-z]+"))
        {
            words.Add(match.Value);
        }
        return words;
    }

    /*
     * How many times each word appears: a dictionary from each different
     * word to its count. Walk the words once.
     *
     * ["the", "gym", "the"] -> { "the": 2, "gym": 1 }
     * [] -> {}
     *
     * Growth rate: (write it here)
     */
    public static Dictionary<string, int> CountWords(List<string> words)
    {
        return new Dictionary<string, int>();
    }

    /*
     * The howMany most common words, most common first. Words with the same
     * count go from A to Z. If there are fewer different words than howMany,
     * return them all.
     *
     * { "the": 3, "gym": 2, "swam": 1 }, 2 -> ["the", "gym"]
     * { "pool": 2, "maya": 2, "leo": 1 }, 2 -> ["maya", "pool"]
     *
     * Growth rate: (write it here)
     */
    public static List<string> MostCommon(Dictionary<string, int> counts, int howMany)
    {
        return new List<string>();
    }

    /*
     * Every word used exactly once, from A to Z.
     *
     * { "the": 2, "swam": 1, "bench": 1 } -> ["bench", "swam"]
     *
     * Growth rate: (write it here)
     */
    public static List<string> UsedOnce(Dictionary<string, int> counts)
    {
        return new List<string>();
    }
}
