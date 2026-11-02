// The tests for your word counter. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
import assert from "node:assert/strict";
import { test } from "node:test";
import { countWords, mostCommon, splitWords, usedOnce } from "./word-counter.js";

const STORY = "The little gym on Maple Street opened at six. Every morning the same three friends came in before work. "
  + "Maya ran on the track, Leo lifted the heavy weights, and Priya swam in the cold pool. "
  + "One morning the pool was closed, so Priya ran with Maya. The next morning the track was closed, so Maya swam with Priya. "
  + "On the third morning everything was open, and the three friends did something new: they traded. "
  + "Leo swam, Priya lifted, and Maya rested on a bench and laughed. The gym was the same gym, but the morning felt new.";

test("countWords counts each word", () => {
  const counts = countWords(["the", "gym", "the"]);
  assert.equal(counts.size, 2, 'Not yet: "the" and "gym" are 2 different words.');
  assert.equal(counts.get("the") ?? 0, 2, 'Not yet: "the" appears 2 times.');
  assert.equal(counts.get("gym") ?? 0, 1, 'Not yet: "gym" appears once.');
  assert.equal(countWords([]).size, 0, "Not yet: no words means no counts.");
});

test("countWords works on a sentence", () => {
  const counts = countWords(splitWords("The gym opens. The gym closes!"));
  assert.equal(counts.size, 4, "Not yet: the sentence has 4 different words: the, gym, opens, closes.");
  assert.equal(counts.get("the") ?? 0, 2, 'Not yet: "The" and "the" are the same word, so "the" appears 2 times.');
  assert.equal(counts.get("closes") ?? 0, 1, 'Not yet: "closes" appears once.');
});

test("countWords handles a big book", () => {
  const book = [];
  for (let i = 0; i < 100000; i++) {
    book.push(`word${i % 1000}`);
  }
  const counts = countWords(book);
  assert.equal(counts.size, 1000, "Not yet: the big book has 1,000 different words.");
  assert.equal(counts.get("word7") ?? 0, 100, "Not yet: each of the 1,000 words appears 100 times.");
});

test("mostCommon puts the biggest count first", () => {
  assert.deepEqual(mostCommon(countWords(["swam", "the", "the", "gym", "the", "gym"]), 2), ["the", "gym"],
    'Not yet: "the" (3 times) comes first, then "gym" (2 times).');
});

test("mostCommon breaks ties from A to Z", () => {
  assert.deepEqual(mostCommon(countWords(["pool", "maya", "track", "maya", "pool", "track", "leo"]), 3), ["maya", "pool", "track"],
    "Not yet: maya, pool and track all appear twice, so they come from A to Z.");
});

test("mostCommon gives every word when asked for more", () => {
  assert.deepEqual(mostCommon(countWords(["the", "gym", "the"]), 10), ["the", "gym"],
    "Not yet: asked for 10 but there are only 2 different words, so both come back.");
});

test("usedOnce lists the rare words from A to Z", () => {
  assert.deepEqual(usedOnce(countWords(["the", "swam", "the", "bench", "laughed"])), ["bench", "laughed", "swam"],
    "Not yet: bench, laughed and swam appear once each, listed from A to Z.");
  assert.deepEqual(usedOnce(countWords(["the", "the"])), [],
    "Not yet: every word appears more than once, so none is used only once.");
});

test("the whole story", () => {
  const counts = countWords(splitWords(STORY));
  assert.deepEqual(mostCommon(counts, 10), ["the", "morning", "and", "maya", "on", "priya", "was", "gym", "swam", "closed"],
    "Not yet: the story's ten most common words are the, morning, and, maya, on, priya, was, gym, swam, closed.");
  assert.equal(usedOnce(counts).length, 28, "Not yet: 28 of the story's words are used only once.");
});

test("a year of comments takes under 2 seconds", () => {
  const comments = [];
  for (let i = 0; i < 300000; i++) {
    comments.push(`word${(i * 7) % 30000}`);
  }
  const started = performance.now();
  const counts = countWords(comments);
  const top = mostCommon(counts, 10);
  const once = usedOnce(counts);
  const seconds = (performance.now() - started) / 1000;
  assert.equal(counts.size, 30000, "Not yet: a year of comments has 300,000 words and 30,000 different ones.");
  assert.deepEqual(top.slice(0, 3), ["word0", "word1", "word10"],
    "Not yet: every word appears 10 times, so the most common come from A to Z: word0, word1, word10.");
  assert.deepEqual(once, [], "Not yet: every word appears 10 times, so none is used only once.");
  assert.ok(seconds < 2, `Not yet: a year of comments took ${seconds.toFixed(1)} seconds. When each word's count is found in one step, it takes well under one.`);
});
