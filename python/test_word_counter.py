# The tests for your word counter. You don't need to change this file.
# Each message says what was expected, so a failing test tells you what to look at.
import time

from word_counter import count_words, most_common, split_words, used_once

STORY = ("The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
         "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
         "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
         "On the third morning everything was open, and the three friends did something new: they traded. "
         "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.")


def test_count_words_counts_each_word():
    counts = count_words(["the", "gym", "the"])
    assert len(counts) == 2, 'Not yet: "the" and "gym" are 2 different words.'
    assert counts.get("the", 0) == 2, 'Not yet: "the" appears 2 times.'
    assert counts.get("gym", 0) == 1, 'Not yet: "gym" appears once.'
    assert len(count_words([])) == 0, "Not yet: no words means no counts."


def test_count_words_works_on_a_sentence():
    counts = count_words(split_words("The gym opens. The gym closes!"))
    assert len(counts) == 4, "Not yet: the sentence has 4 different words: the, gym, opens, closes."
    assert counts.get("the", 0) == 2, 'Not yet: "The" and "the" are the same word, so "the" appears 2 times.'
    assert counts.get("closes", 0) == 1, 'Not yet: "closes" appears once.'


def test_count_words_handles_a_big_book():
    book = [f"word{i % 1000}" for i in range(100000)]
    counts = count_words(book)
    assert len(counts) == 1000, "Not yet: the big book has 1,000 different words."
    assert counts.get("word7", 0) == 100, "Not yet: each of the 1,000 words appears 100 times."


def test_most_common_puts_the_biggest_count_first():
    assert most_common(count_words(["swam", "the", "the", "gym", "the", "gym"]), 2) == ["the", "gym"], \
        'Not yet: "the" (3 times) comes first, then "gym" (2 times).'


def test_most_common_breaks_ties_from_a_to_z():
    assert most_common(count_words(["pool", "maya", "track", "maya", "pool", "track", "leo"]), 3) == ["maya", "pool", "track"], \
        "Not yet: maya, pool and track all appear twice, so they come from A to Z."


def test_most_common_gives_every_word_when_asked_for_more():
    assert most_common(count_words(["the", "gym", "the"]), 10) == ["the", "gym"], \
        "Not yet: asked for 10 but there are only 2 different words, so both come back."


def test_used_once_lists_the_rare_words_from_a_to_z():
    assert used_once(count_words(["the", "swam", "the", "bench", "laughed"])) == ["bench", "laughed", "swam"], \
        "Not yet: bench, laughed and swam appear once each, listed from A to Z."
    assert used_once(count_words(["the", "the"])) == [], \
        "Not yet: every word appears more than once, so none is used only once."


def test_the_whole_story():
    counts = count_words(split_words(STORY))
    assert most_common(counts, 10) == ["the", "morning", "and", "maya", "on", "priya", "was", "gym", "swam", "closed"], \
        "Not yet: the story's ten most common words are the, morning, and, maya, on, priya, was, gym, swam, closed."
    assert len(used_once(counts)) == 28, "Not yet: 28 of the story's words are used only once."


def test_a_year_of_comments_takes_under_2_seconds():
    comments = [f"word{(i * 7) % 30000}" for i in range(300000)]
    started = time.perf_counter()
    counts = count_words(comments)
    top = most_common(counts, 10)
    once = used_once(counts)
    seconds = time.perf_counter() - started
    assert len(counts) == 30000, "Not yet: a year of comments has 300,000 words and 30,000 different ones."
    assert top[:3] == ["word0", "word1", "word10"], (
        "Not yet: every word appears 10 times, so the most common come from A to Z: word0, word1, word10.")
    assert once == [], "Not yet: every word appears 10 times, so none is used only once."
    assert seconds < 2, (
        f"Not yet: a year of comments took {seconds:.1f} seconds. When each word's count is found in one step, it takes well under one.")
