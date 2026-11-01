using WordCount;

// Tries your word counter on a short story. Run it with: dotnet run --project WordCount
string story = "The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
    + "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
    + "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
    + "On the third morning everything was open, and the three friends did something new: they traded. "
    + "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.";

List<string> words = WordCounter.SplitWords(story);
Dictionary<string, int> counts = WordCounter.CountWords(words);
List<string> common = new List<string>();
foreach (string word in WordCounter.MostCommon(counts, 10))
{
    common.Add(word + " " + counts[word]);
}
List<string> once = WordCounter.UsedOnce(counts);

Console.WriteLine("Words: " + words.Count);
Console.WriteLine("Different words: " + counts.Count);
Console.WriteLine("Ten most common: " + string.Join(", ", common));
Console.WriteLine("Used only once: " + once.Count + " words, starting " + string.Join(", ", once.GetRange(0, Math.Min(5, once.Count))));
