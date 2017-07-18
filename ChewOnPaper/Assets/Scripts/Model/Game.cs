using System.Collections.Generic;

/// <summary>
/// Represents Game model presentation.
/// </summary>
public class Game
{
    /// <summary>
    /// Gets the current player identifier.
    /// </summary>
    public int CurrentPlayerId
    {
        get
        {
            return PhotonNetwork.player.ID;
        }
    }

    /// <summary>
    /// Gets the previous session winner.
    /// </summary>
    public int? PreviousSessionWinner { get; private set; }

    /// <summary>
    /// Gets the players.
    /// </summary>
    public List<Player> Players { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    public Game()
    {
        Players = new List<Player>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Game" /> class.
    /// </summary>
    /// <param name="previousSessionWinner">The previous session winner.</param>
    /// <param name="players">The players.</param>
    public void UpdateGameData(int? previousSessionWinner, List<Player> players)
    {
        Players = players;
        PreviousSessionWinner = previousSessionWinner;
    }
}
