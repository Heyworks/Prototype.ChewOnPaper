using System.Collections.Generic;

/// <summary>
/// Represents Game model presentation.
/// </summary>
public class Game
{
    /// <summary>
    /// Gets the current player identifier.
    /// </summary>
    public int CurrentPlayerId { get; private set; }

    /// <summary>
    /// Gets the previous session winner.
    /// </summary>
    public int?PreviousSessionWinner { get; private set; }

    /// <summary>
    /// Gets the players.
    /// </summary>
    public List<Player> Players { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game" /> class.
    /// </summary>
    /// <param name="currentPlayerId">The current player identifier.</param>
    /// <param name="previousSessionWinner">The previous session winner.</param>
    /// <param name="players">The players.</param>
    public Game(int currentPlayerId, int? previousSessionWinner, List<Player> players)
    {
        CurrentPlayerId = currentPlayerId;
        Players = players;
        PreviousSessionWinner = previousSessionWinner;
    }
}
