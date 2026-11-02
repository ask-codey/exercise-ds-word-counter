using System.Diagnostics;
using WordCount;

namespace WordCount.Tests;

// The tests for your word counter. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.

[TestClass]
public class WordCounterTests
{
    private const string Story = "The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
        + "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
        + "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
        + "On the third morning everything was open, and the three friends did something new: they traded. "
        + "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.";

    private static Dictionary<string, int> Counts(params string[] words)
    {
        return WordCounter.CountWords(new List<string>(words));
    }

    [TestMethod]
    public void CountWordsCountsEachWord()
    {
        Dictionary<string, int> counts = Counts("the", "gym", "the");
        Assert.AreEqual(2, counts.Count, "Not yet: \"the\" and \"gym\" are 2 different words.");
        Assert.AreEqual(2, counts.GetValueOrDefault("the"), "Not yet: \"the\" appears 2 times.");
        Assert.AreEqual(1, counts.GetValueOrDefault("gym"), "Not yet: \"gym\" appears once.");
        Assert.AreEqual(0, Counts().Count, "Not yet: no words means no counts.");
    }

    [TestMethod]
    public void CountWordsWorksOnASentence()
    {
        Dictionary<string, int> counts = WordCounter.CountWords(WordCounter.SplitWords("The gym opens. The gym closes!"));
        Assert.AreEqual(4, counts.Count, "Not yet: the sentence has 4 different words: the, gym, opens, closes.");
        Assert.AreEqual(2, counts.GetValueOrDefault("the"), "Not yet: \"The\" and \"the\" are the same word, so \"the\" appears 2 times.");
        Assert.AreEqual(1, counts.GetValueOrDefault("closes"), "Not yet: \"closes\" appears once.");
    }

    [TestMethod]
    public void CountWordsHandlesABigBook()
    {
        List<string> book = new List<string>();
        for (int i = 0; i < 100000; i++)
        {
            book.Add("word" + (i % 1000));
        }
        Dictionary<string, int> counts = WordCounter.CountWords(book);
        Assert.AreEqual(1000, counts.Count, "Not yet: the big book has 1,000 different words.");
        Assert.AreEqual(100, counts.GetValueOrDefault("word7"), "Not yet: each of the 1,000 words appears 100 times.");
    }

    [TestMethod]
    public void MostCommonPutsTheBiggestCountFirst()
    {
        CollectionAssert.AreEqual(new List<string> { "the", "gym" },
            WordCounter.MostCommon(Counts("swam", "the", "the", "gym", "the", "gym"), 2),
            "Not yet: \"the\" (3 times) comes first, then \"gym\" (2 times).");
    }

    [TestMethod]
    public void MostCommonBreaksTiesFromAToZ()
    {
        CollectionAssert.AreEqual(new List<string> { "maya", "pool", "track" },
            WordCounter.MostCommon(Counts("pool", "maya", "track", "maya", "pool", "track", "leo"), 3),
            "Not yet: maya, pool and track all appear twice, so they come from A to Z.");
    }

    [TestMethod]
    public void MostCommonGivesEveryWordWhenAskedForMore()
    {
        CollectionAssert.AreEqual(new List<string> { "the", "gym" },
            WordCounter.MostCommon(Counts("the", "gym", "the"), 10),
            "Not yet: asked for 10 but there are only 2 different words, so both come back.");
    }

    [TestMethod]
    public void UsedOnceListsTheRareWordsFromAToZ()
    {
        CollectionAssert.AreEqual(new List<string> { "bench", "laughed", "swam" },
            WordCounter.UsedOnce(Counts("the", "swam", "the", "bench", "laughed")),
            "Not yet: bench, laughed and swam appear once each, listed from A to Z.");
        CollectionAssert.AreEqual(new List<string>(), WordCounter.UsedOnce(Counts("the", "the")),
            "Not yet: every word appears more than once, so none is used only once.");
    }

    [TestMethod]
    public void TheWholeStory()
    {
        Dictionary<string, int> counts = WordCounter.CountWords(WordCounter.SplitWords(Story));
        CollectionAssert.AreEqual(new List<string> { "the", "morning", "and", "maya", "on", "priya", "was", "gym", "swam", "closed" },
            WordCounter.MostCommon(counts, 10),
            "Not yet: the story's ten most common words are the, morning, and, maya, on, priya, was, gym, swam, closed.");
        Assert.AreEqual(28, WordCounter.UsedOnce(counts).Count, "Not yet: 28 of the story's words are used only once.");
    }

    [TestMethod]
    public void AYearOfCommentsTakesUnderTwoSeconds()
    {
        List<string> comments = new List<string>();
        for (int i = 0; i < 300000; i++)
        {
            comments.Add("word" + (i * 7 % 30000));
        }
        Stopwatch watch = Stopwatch.StartNew();
        Dictionary<string, int> counts = WordCounter.CountWords(comments);
        List<string> top = WordCounter.MostCommon(counts, 10);
        List<string> once = WordCounter.UsedOnce(counts);
        watch.Stop();
        Assert.AreEqual(30000, counts.Count, "Not yet: a year of comments has 300,000 words and 30,000 different ones.");
        CollectionAssert.AreEqual(new List<string> { "word0", "word1", "word10" }, top.GetRange(0, Math.Min(3, top.Count)),
            "Not yet: every word appears 10 times, so the most common come from A to Z: word0, word1, word10.");
        Assert.AreEqual(0, once.Count, "Not yet: every word appears 10 times, so none is used only once.");
        Assert.IsTrue(watch.Elapsed.TotalSeconds < 2, "Not yet: a year of comments took " + watch.Elapsed.TotalSeconds.ToString("0.0") + " seconds. When each word's count is found in one step, it takes well under one.");
    }
}
