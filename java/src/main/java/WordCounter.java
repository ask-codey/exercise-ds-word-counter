import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

// Your three methods. splitWords is written for you. The comment above
// each of the others says what it should return, with examples. Replace
// each return line with your own code, and write the method's growth
// rate in its comment.
public class WordCounter {
    // The words of a text, in order, in lowercase: every run of the letters a to z.
    // "The gym opens. The gym closes!" -> ["the", "gym", "opens", "the", "gym", "closes"]
    public static List<String> splitWords(String text) {
        List<String> words = new ArrayList<>();
        Matcher matcher = Pattern.compile("[a-z]+").matcher(text.toLowerCase());
        while (matcher.find()) {
            words.add(matcher.group());
        }
        return words;
    }

    /*
     * How many times each word appears: a map from each different word to
     * its count. Walk the words once.
     *
     * ["the", "gym", "the"] -> { "the": 2, "gym": 1 }
     * [] -> {}
     *
     * Growth rate: (write it here)
     */
    public static Map<String, Integer> countWords(List<String> words) {
        return new HashMap<>();
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
    public static List<String> mostCommon(Map<String, Integer> counts, int howMany) {
        return new ArrayList<>();
    }

    /*
     * Every word used exactly once, from A to Z.
     *
     * { "the": 2, "swam": 1, "bench": 1 } -> ["bench", "swam"]
     *
     * Growth rate: (write it here)
     */
    public static List<String> usedOnce(Map<String, Integer> counts) {
        return new ArrayList<>();
    }
}
