# Exercise: The Word Counter

Exercise code for the lesson **Exercise: The Word Counter** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

## The ticket

> **From:** the manager, the gym on Maple Street
>
> Members leave a comment in our app after each visit ("the pool was cold again", "loved the new spin bikes"). A year of comments comes to about 300,000 words, about 30,000 of them different. I want three things from them:
>
> 1. **How many times each word was used.**
> 2. **The ten words members use most,** most used first. Words used the same number of times go from A to Z, so the list is the same every time we run it.
> 3. **Every word used only once,** from A to Z. That's where the one-off complaints and the typos hide.
>
> Our first version kept a list of the words with their counts, and searched that list for every word it read. On a year of comments it ran for between 10 seconds and over 2 minutes, depending on the language, and the app froze while it did. **The whole report, all three parts, has to take under 2 seconds.**

The code that's there turns a text into its words: `splitWords` (`SplitWords` in C#, `split_words` in Python) gives the words in order, in lowercase, so "The" and "the" count as one word. Three functions are yours to finish:

- `countWords` (`CountWords`, `count_words`): how many times each word appears, each different word with its count
- `mostCommon` (`MostCommon`, `most_common`): the most common words, most common first, with ties from A to Z
- `usedOnce` (`UsedOnce`, `used_once`): every word used exactly once, from A to Z

Nine tests check them, ending with a year of comments: 300,000 words in under 2 seconds.

## Pick your language

The same exercise is here in five languages. Work in the folder for the language you set up; you only need one.

| Folder | Your code | The tests |
|---|---|---|
| `csharp/` | `WordCount/WordCounter.cs` | `WordCount.Tests/WordCounterTests.cs` |
| `java/` | `src/main/java/WordCounter.java` | `src/test/java/WordCounterTest.java` |
| `python/` | `word_counter.py` | `test_word_counter.py` |
| `javascript/` | `word-counter.js` | `word-counter.test.js` |
| `typescript/` | `word-counter.ts` | `word-counter.test.ts` |

Each function returns an empty answer for now. The comment above it says what it should return, with examples. Replace the `return` line with your own code, and write the function's growth rate on its **Growth rate:** line.

Every folder also has a small demo program that counts the words of a short story about the gym. You don't need to change the tests or the demo.

## Run it and check your work

Open your language's folder in VS Code (**File > Open Folder**), then open its terminal (**Terminal > New Terminal**) and run these commands there.

**C#**

```bash
dotnet run --project WordCount
dotnet test
```

**Java** (the Maven Wrapper downloads Maven the first time, so the first run takes a minute)

```bash
java src/main/java/Demo.java
./mvnw test
```

On Windows in PowerShell, write `.\mvnw test` instead of `./mvnw test`.

**Python** (once: make a virtual environment and install pytest into it)

```bash
python -m venv .venv
```

Then turn it on: `.venv\Scripts\Activate.ps1` in PowerShell on Windows, or `source .venv/bin/activate` on macOS (where the command is `python3`, not `python`). Then:

```bash
pip install -r requirements.txt
python demo.py
python -m pytest
```

**JavaScript**

```bash
node demo.js
npm test
```

**TypeScript** (once: `npm install`, which installs TypeScript)

```bash
node demo.ts
npm test
```

At first every test fails: that is expected. Each function you finish turns its tests green. A failing test's message starts with **Not yet:** and says what it expected.

<details>
<summary>Stuck?</summary>

- **Where to look:** the ticket's first job is the frequency count from the lesson *When a Loop Inside a Loop Is Too Slow: Hash Tables at Work*. Keep a **dictionary** from each word to its count, so finding a word's count is one step, not a search.
- **Start with `countWords`.** One loop over the words: read the word's count, or 0 if it has none yet, and add 1. The safe read is `GetValueOrDefault` (C#), `getOrDefault` (Java), `get(word, 0)` (Python) or `get(word) ?? 0` (JavaScript and TypeScript).
- **`mostCommon` sorts the different words**, not the whole year of comments: by count, biggest first, and by the word itself when two counts are equal. Then keep the first `howMany`, or all of them if there are fewer.
- **`usedOnce` is one pass over the counts**, keeping the words whose count is 1, then a sort.
- **Sort words the plain way.** The words are lowercase letters and digits, so your language's ordinary string order is A to Z. In C#, use `string.CompareOrdinal` for the tie-break.
- **Stuck on a growth rate?** `countWords` touches each of the n words once. The other two work on the k different words, and sorting k things is O(k log k).

</details>

<details>
<summary>Why Should I Choose This?</summary>

Open this once your tests are green. The year of comments is 300,000 words, 30,000 of them different.

- **A list of words with their counts, searched for every word:** each word read means looking through the words found so far, about 15,000 of them once the list fills up. That's O(n × k) for n words and k different ones, over 4 billion comparisons. Measured on the test: 10 seconds in C#, 15 in Java, 25 to 27 in JavaScript and TypeScript, and 139 in Python.
- **Taking each different word and counting it through all the comments:** the same loop inside a loop, turned around, and just as slow.
- **Sorting the words first, then counting each run of equal words:** O(n log n), about 5.5 million steps for 300,000 words. It's fast enough here, but it's more code, and it sorts all 300,000 words when only 30,000 different ones matter.
- **A dictionary from word to count:** finding a word's count is O(1) on average, so counting is one pass, O(n). Then only the 30,000 different words are sorted, O(k log k). Measured on the test: 0.03 seconds in Python, 0.05 in C#, 0.06 in JavaScript and TypeScript, and 0.08 in Java.
- **What it costs:** memory for one entry per different word, and the dictionary keeps no order, which is why `mostCommon` and `usedOnce` still sort.

</details>

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
