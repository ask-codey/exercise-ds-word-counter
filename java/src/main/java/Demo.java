import java.util.ArrayList;
import java.util.List;
import java.util.Map;

// Tries your word counter on a short story. Run it with: java src/main/java/Demo.java
public class Demo {
    public static void main(String[] args) {
        String story = "The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
            + "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
            + "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
            + "On the third morning everything was open, and the three friends did something new: they traded. "
            + "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.";

        List<String> words = WordCounter.splitWords(story);
        Map<String, Integer> counts = WordCounter.countWords(words);
        List<String> common = new ArrayList<>();
        for (String word : WordCounter.mostCommon(counts, 10)) {
            common.add(word + " " + counts.get(word));
        }
        List<String> once = WordCounter.usedOnce(counts);

        System.out.println("Words: " + words.size());
        System.out.println("Different words: " + counts.size());
        System.out.println("Ten most common: " + String.join(", ", common));
        System.out.println("Used only once: " + once.size() + " words, starting " + String.join(", ", once.subList(0, Math.min(5, once.size()))));
    }
}
