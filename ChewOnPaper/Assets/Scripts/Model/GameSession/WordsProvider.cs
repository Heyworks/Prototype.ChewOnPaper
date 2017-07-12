using System.Linq;
using UnityEngine;
using Random = System.Random;

/// <summary>
/// Represents words for guess provider.
/// </summary>
public class WordsProvider
{
    private const string TEXT_FILE_NAME = "words";
    private readonly Random randomizer;
    private string[] words;

    /// <summary>
    /// Initializes a new instance of the <see cref="WordsProvider"/> class.
    /// </summary>
    public WordsProvider()
    {
        randomizer = new Random();
        LoadWordsBase();
    }

    /// <summary>
    /// Gets the random word.
    /// </summary>
    public string GetRandomWord()
    {
        var index = randomizer.Next(words.Count());
        return words[index];
    }

    private void LoadWordsBase()
    {
        var textAsset = Resources.Load<TextAsset>(TEXT_FILE_NAME);
        words = textAsset.text.Split('\n', ' ');
    }
}