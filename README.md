# Exercise: The Word Counter

Exercise code for the lesson **Exercise: The Word Counter** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

Count every word in a book, list the most common ones, and find the words used only once, with a dictionary doing the counting. `splitWords` (`SplitWords` in C#, `split_words` in Python), which turns a text into its lowercase words, is already written. There are three functions to finish:

- `countWords` (`CountWords`, `count_words`): how many times each word appears, as a dictionary from word to count
- `mostCommon` (`MostCommon`, `most_common`): the most common words, most common first, with ties from A to Z
- `usedOnce` (`UsedOnce`, `used_once`): every word used exactly once, from A to Z

## Pick your language

The same exercise is here in five languages. Work in the folder for the language you set up; you only need one.

| Folder | Your code | The tests |
|---|---|---|
| `csharp/` | `WordCount/WordCounter.cs` | `WordCount.Tests/WordCounterTests.cs` |
| `java/` | `src/main/java/WordCounter.java` | `src/test/java/WordCounterTest.java` |
| `python/` | `word_counter.py` | `test_word_counter.py` |
| `javascript/` | `word-counter.js` | `word-counter.test.js` |
| `typescript/` | `word-counter.ts` | `word-counter.test.ts` |

Each function returns an empty dictionary or an empty list for now. The comment above it says what it should return, with examples. Replace the `return` line with your own code, and write the function's growth rate on its **Growth rate:** line.

Every folder also has a small demo program that counts the words of a short story. You don't need to change the tests or the demo.

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

## Tips

- **Start with `countWords`.** One loop over the words: read the word's count, or 0 if it has none yet, and add 1.
- **`mostCommon` sorts the different words**, not the whole book: by count, biggest first, and by the word itself when two counts are equal. Then keep the first `howMany`.
- **`usedOnce` is one pass over the counts**, keeping the words whose count is 1, then a sort.
- **Sort words the plain way.** The words are lowercase letters and digits, so your language's ordinary string order is A to Z. In C#, use `string.CompareOrdinal` for the tie-break.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
