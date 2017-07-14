using System.Collections.Generic;

/// <summary>
/// Represents Game model presentation.
/// </summary>
public class Game
{
    /// <summary>
    /// Gets the current player identifier.
    /// </summary>
    public string CurrentPlayerId { get; private set; }

    /// <summary>
    /// Gets the players.
    /// </summary>
    public List<Player> Players { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    /// <param name="currentPlayerId">The current player identifier.</param>
    /// <param name="players">The players.</param>
    public Game(string currentPlayerId, List<Player> players)
    {
        CurrentPlayerId = currentPlayerId;
        Players = players;
    }
}
