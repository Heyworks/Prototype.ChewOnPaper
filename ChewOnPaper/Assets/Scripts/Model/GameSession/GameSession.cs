using System.Collections.Generic;

/// <summary>
/// Represents game session.
/// </summary>
public class InitSessionData
{
    /// <summary>
    /// Gets the guessed word.
    /// </summary>
    public string GuessedWord { get; private set; }

    /// <summary>
    /// Gets the roles for every player.
    /// </summary>
    public Dictionary<string, PlayerRole> PlayerRoles { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="InitSessionData"/> class.
    /// </summary>
    /// <param name="guessedWord">The guessed word.</param>
    /// <param name="playerRoles">The player roles.</param>
    public InitSessionData(string guessedWord, Dictionary<string, PlayerRole> playerRoles)
    {
        GuessedWord = guessedWord;
        PlayerRoles = playerRoles;
    }
}
