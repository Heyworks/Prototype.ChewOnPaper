/// <summary>
///  Represents data about session init result for chewers. 
/// </summary>
public class ChewerSessionInitTransferData : SessionInitTransferData
{
    /// <summary>
    /// Gets the guessed word.
    /// </summary>
    public string GuessedWord { get; private set; }

    /// <summary>
    /// Gets a value indicating whether your turn is the first.
    /// </summary>
    public bool IsYourTurnFirst { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ChewerSessionInitTransferData"/> class.
    /// </summary>
    /// <param name="currentPlayerRole">The current player role.</param>
    /// <param name="guessedWord">The guessed word.</param>
    /// <param name="isYourTurnFirst">A value indicating whether your turn is the first.</param>
    public ChewerSessionInitTransferData(PlayerRole currentPlayerRole, string guessedWord, bool isYourTurnFirst)
        : base(currentPlayerRole)
    {
        GuessedWord = guessedWord;
        IsYourTurnFirst = isYourTurnFirst;
    }
}