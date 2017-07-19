public class Guess
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Guess"/> class.
    /// </summary>
    /// <param name="word">The word.</param>
    /// <param name="playerId">The player identifier.</param>
    public Guess(string word, int playerId)
    {
        Word = word;
        PlayerId = playerId;
    }

    /// <summary>
    /// Gets the word.
    /// </summary>
    public string Word
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the player identifier.
    /// </summary>
    public int PlayerId
    {
        get;
        private set;
    }
}
