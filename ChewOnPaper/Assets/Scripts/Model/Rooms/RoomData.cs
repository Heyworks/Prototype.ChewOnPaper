/// <summary>
/// Represents info about network room.
/// </summary>
public class RoomData
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets number of players in room
    /// </summary>
    public int PlayerCount { get; set; }

    /// <summary>
    /// Gets or sets the maximum players.
    /// </summary>
    public int MaxPlayers { get; set; }
}