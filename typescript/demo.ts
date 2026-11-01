// Tries your word counter on a short story. Run it with: node demo.ts
import { countWords, mostCommon, splitWords, usedOnce } from "./word-counter.ts";

const story = "The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
  + "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
  + "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
  + "On the third morning everything was open, and the three friends did something new: they traded. "
  + "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.";

const words = splitWords(story);
const counts = countWords(words);
const common = mostCommon(counts, 10).map((word) => `${word} ${counts.get(word)}`);
const once = usedOnce(counts);

console.log(`Words: ${words.length}`);
console.log(`Different words: ${counts.size}`);
console.log(`Ten most common: ${common.join(", ")}`);
console.log(`Used only once: ${once.length} words, starting ${once.slice(0, 5).join(", ")}`);
