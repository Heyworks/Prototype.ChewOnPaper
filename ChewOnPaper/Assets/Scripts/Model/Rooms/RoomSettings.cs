/// <summary>
/// Describe all game room settings
/// </summary>
public class RoomSettings
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets maximum count of players in the room.
    /// </summary>
    public int MaxPlayers { get; set; }

    /// <summary>
    /// Gets or sets time for player's turn.
    /// </summary>
    public int TurnTime { get; set; }

    /// <summary>
    /// Gets or sets score bonus for right answer.
    /// </summary>
    public int RightAnswerScore { get; set; }

    /// <summary>
    /// Gets or sets base score for chewers. 
    /// </summary>
    public int ChewerBaseScore { get; set; }

    /// <summary>
    /// Gets or sets the max session time.
    /// </summary>
    public int MaxSessionTime { get; set; }

    /// <summary>
    /// Gets a value indicating whether this room settings are valid.
    /// </summary>
    public bool IsValid
    {
        get
        {
            return !string.IsNullOrEmpty(Name);
        }
    }

    /// <summary>
    /// Converts from photon room.
    /// </summary>
    /// <param name="photonRoom">The photon room.</param>
    public static RoomSettings ConvertFromPhotonRoom(Room photonRoom)
    {
        var roomSettings = new RoomSettings();
        roomSettings.MaxPlayers = photonRoom.MaxPlayers;
        roomSettings.Name = photonRoom.Name;
        object hashTableOut;
        photonRoom.CustomProperties.TryGetValue("ChewerBaseScore", out hashTableOut);
        roomSettings.ChewerBaseScore = (int) hashTableOut;
        photonRoom.CustomProperties.TryGetValue("RightAnswerScore", out hashTableOut);
        roomSettings.RightAnswerScore = (int)hashTableOut;
        photonRoom.CustomProperties.TryGetValue("TurnTime", out hashTableOut);
        roomSettings.TurnTime = (int)hashTableOut;
        photonRoom.CustomProperties.TryGetValue("MaxSessionTime", out hashTableOut);
        roomSettings.MaxSessionTime = (int)hashTableOut;
        return roomSettings;
    }
}
