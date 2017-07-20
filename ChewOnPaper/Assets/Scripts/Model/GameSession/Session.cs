/// <summary>
/// Represents current game session.
/// </summary>
public class Session
{
    private readonly Game game;

    /// <summary>
    /// Initializes a new instance of the <see cref="Session" /> class.
    /// </summary>
    /// <param name="currentPlayerRole">The current player role.</param>
    /// <param name="guessedWord">The guessed word.</param>
    /// <param name="game">The game.</param>
    public Session(PlayerRole currentPlayerRole, string guessedWord, Game game)
    {
        CurrentPlayerRole = currentPlayerRole;
        GuessedWord = guessedWord;
        this.game = game;
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

