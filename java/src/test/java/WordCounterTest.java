import static org.junit.jupiter.api.Assertions.assertEquals;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import org.junit.jupiter.api.Test;

// The tests for your word counter. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
class WordCounterTest {
    private static final String STORY = "The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
        + "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
        + "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
        + "On the third morning everything was open, and the three friends did something new: they traded. "
        + "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.";

    private static Map<String, Integer> counts(String... words) {
        return WordCounter.countWords(List.of(words));
    }

    @Test
    void countWordsCountsEachWord() {
        Map<String, Integer> counts = counts("the", "gym", "the");
        assertEquals(2, counts.size(), "Not yet: \"the\" and \"gym\" are 2 different words.");
        assertEquals(2, counts.getOrDefault("the", 0), "Not yet: \"the\" appears 2 times.");
        assertEquals(1, counts.getOrDefault("gym", 0), "Not yet: \"gym\" appears once.");
        assertEquals(0, counts().size(), "Not yet: no words means no counts.");
    }

    @Test
    void countWordsWorksOnASentence() {
        Map<String, Integer> counts = WordCounter.countWords(WordCounter.splitWords("The gym opens. The gym closes!"));
        assertEquals(4, counts.size(), "Not yet: the sentence has 4 different words: the, gym, opens, closes.");
        assertEquals(2, counts.getOrDefault("the", 0), "Not yet: \"The\" and \"the\" are the same word, so \"the\" appears 2 times.");
        assertEquals(1, counts.getOrDefault("closes", 0), "Not yet: \"closes\" appears once.");
    }

    @Test
    void countWordsHandlesABigBook() {
        List<String> book = new ArrayList<>();
        for (int i = 0; i < 100000; i++) {
            book.add("word" + (i % 1000));
        }
        Map<String, Integer> counts = WordCounter.countWords(book);
        assertEquals(1000, counts.size(), "Not yet: the big book has 1,000 different words.");
        assertEquals(100, counts.getOrDefault("word7", 0), "Not yet: each of the 1,000 words appears 100 times.");
    }

    @Test
    void mostCommonPutsTheBiggestCountFirst() {
        assertEquals(List.of("the", "gym"), WordCounter.mostCommon(counts("swam", "the", "the", "gym", "the", "gym"), 2),
            "Not yet: \"the\" (3 times) comes first, then \"gym\" (2 times).");
    }

    @Test
    void mostCommonBreaksTiesFromAToZ() {
        assertEquals(List.of("maya", "pool", "track"), WordCounter.mostCommon(counts("pool", "maya", "track", "maya", "pool", "track", "leo"), 3),
            "Not yet: maya, pool and track all appear twice, so they come from A to Z.");
    }

    @Test
    void mostCommonGivesEveryWordWhenAskedForMore() {
        assertEquals(List.of("the", "gym"), WordCounter.mostCommon(counts("the", "gym", "the"), 10),
            "Not yet: asked for 10 but there are only 2 different words, so both come back.");
    }

    @Test
    void usedOnceListsTheRareWordsFromAToZ() {
        assertEquals(List.of("bench", "laughed", "swam"), WordCounter.usedOnce(counts("the", "swam", "the", "bench", "laughed")),
            "Not yet: bench, laughed and swam appear once each, listed from A to Z.");
        assertEquals(List.of(), WordCounter.usedOnce(counts("the", "the")),
            "Not yet: every word appears more than once, so none is used only once.");
    }

    @Test
    void theWholeStory() {
        Map<String, Integer> counts = WordCounter.countWords(WordCounter.splitWords(STORY));
        assertEquals(List.of("the", "morning", "and", "maya", "on", "priya", "was", "gym", "swam", "closed"), WordCounter.mostCommon(counts, 10),
            "Not yet: the story's ten most common words are the, morning, and, maya, on, priya, was, gym, swam, closed.");
        assertEquals(28, WordCounter.usedOnce(counts).size(), "Not yet: 28 of the story's words are used only once.");
    }
}
