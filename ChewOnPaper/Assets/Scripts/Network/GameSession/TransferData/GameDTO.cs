using System.Collections.Generic;

public class GameDTO
{
    /// <summary>
    /// Gets the previous session winner.
    /// </summary>
    public int? PreviousSessionWinner { get; set; }

    /// <summary>
    /// Gets the players.
    /// </summary>
    public List<Player> Players { get; set; }
}
