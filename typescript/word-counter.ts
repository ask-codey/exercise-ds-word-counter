// Your three functions. splitWords is written for you. The comment above
// each of the others says what it should return, with examples. Replace
// each return line with your own code, and write the function's growth
// rate in its comment.

// The words of a text, in order, in lowercase: every run of the letters a to z.
// splitWords("The gym opens. The gym closes!") -> ["the", "gym", "opens", "the", "gym", "closes"]
export function splitWords(text: string): string[] {
  return text.toLowerCase().match(/[a-z]+/g) ?? [];
}

/*
 * How many times each word appears: a Map from each different word to
 * its count. Walk the words once.
 *
 * countWords(["the", "gym", "the"]) -> Map { "the" => 2, "gym" => 1 }
 * countWords([]) -> Map {}
 *
 * Growth rate: (write it here)
 */
export function countWords(words: string[]): Map<string, number> {
  return new Map();
}

/*
 * The howMany most common words, most common first. Words with the same
 * count go from A to Z. If there are fewer different words than howMany,
 * return them all.
 *
 * mostCommon(Map { "the" => 3, "gym" => 2, "swam" => 1 }, 2) -> ["the", "gym"]
 * mostCommon(Map { "pool" => 2, "maya" => 2, "leo" => 1 }, 2) -> ["maya", "pool"]
 *
 * Growth rate: (write it here)
 */
export function mostCommon(counts: Map<string, number>, howMany: number): string[] {
  return [];
}

/*
 * Every word used exactly once, from A to Z.
 *
 * usedOnce(Map { "the" => 2, "swam" => 1, "bench" => 1 }) -> ["bench", "swam"]
 *
 * Growth rate: (write it here)
 */
export function usedOnce(counts: Map<string, number>): string[] {
  return [];
}
