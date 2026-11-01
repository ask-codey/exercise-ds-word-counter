# Tries your word counter on a short story. Run it with: python demo.py
from word_counter import count_words, most_common, split_words, used_once

story = ("The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
         "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
         "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
         "On the third morning everything was open, and the three friends did something new: they traded. "
         "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.")

words = split_words(story)
counts = count_words(words)
common = [f"{word} {counts[word]}" for word in most_common(counts, 10)]
once = used_once(counts)

print(f"Words: {len(words)}")
print(f"Different words: {len(counts)}")
print(f"Ten most common: {', '.join(common)}")
print(f"Used only once: {len(once)} words, starting {', '.join(once[:5])}")
