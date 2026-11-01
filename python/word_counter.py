# Your three functions. split_words is written for you. The comment inside
# each of the others says what it should return, with examples. Replace
# each return line with your own code, and write the function's growth
# rate in its comment.
import re


def split_words(text):
    """
    The words of a text, in order, in lowercase: every run of the letters a to z.

    split_words("The gym opens. The gym closes!") -> ["the", "gym", "opens", "the", "gym", "closes"]
    """
    return re.findall("[a-z]+", text.lower())


def count_words(words):
    """
    How many times each word appears: a dict from each different word to
    its count. Walk the words once.

    count_words(["the", "gym", "the"]) -> {"the": 2, "gym": 1}
    count_words([]) -> {}

    Growth rate: (write it here)
    """
    return {}


def most_common(counts, how_many):
    """
    The how_many most common words, most common first. Words with the same
    count go from A to Z. If there are fewer different words than how_many,
    return them all.

    most_common({"the": 3, "gym": 2, "swam": 1}, 2) -> ["the", "gym"]
    most_common({"pool": 2, "maya": 2, "leo": 1}, 2) -> ["maya", "pool"]

    Growth rate: (write it here)
    """
    return []


def used_once(counts):
    """
    Every word used exactly once, from A to Z.

    used_once({"the": 2, "swam": 1, "bench": 1}) -> ["bench", "swam"]

    Growth rate: (write it here)
    """
    return []
