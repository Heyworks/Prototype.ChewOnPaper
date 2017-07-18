/// <summary>
/// Represents data about session init result. 
/// </summary>
public class SessionInitDTO
{
    /// <summary>
    /// Gets the current player role.
    /// </summary>
    public PlayerRole CurrentPlayerRole { get; private set; }

     /// <summary>
    /// Gets the guessed word.
    /// </summary>
    public string GuessedWord { get; private set; }

    /// <summary>
    /// Gets a value indicating whether your turn is the first.
    /// </summary>
    public bool IsYourTurnFirst { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionInitDTO"/> class.
    /// </summary>
    /// <param name="currentPlayerRole">The current player role.</param>
    /// <param name="guessedWord">The guessed word.</param>
    /// <param name="isYourTurnFirst">A value indicating whether your turn is the first.</param>
    public SessionInitDTO(PlayerRole currentPlayerRole, string guessedWord, bool isYourTurnFirst)
    {
        GuessedWord = guessedWord;
        IsYourTurnFirst = isYourTurnFirst;
        CurrentPlayerRole = currentPlayerRole;
    }
}
