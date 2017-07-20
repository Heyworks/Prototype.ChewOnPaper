/// <summary>
/// Represents current game session.
/// </summary>
public class Session
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Session" /> class.
    /// </summary>
    /// <param name="currentPlayerRole">The current player role.</param>
    /// <param name="guessedWord">The guessed word.</param>
    public Session(PlayerRole currentPlayerRole, string guessedWord)
    {
        CurrentPlayerRole = currentPlayerRole;
        GuessedWord = guessedWord;
    }

    /// <summary>
    /// Gets the current player role.
    /// </summary>
    public PlayerRole CurrentPlayerRole { get; private set; }

    /// <summary>
    /// Gets the guessed word.
    /// </summary>
    public string GuessedWord { get; private set; }
}

