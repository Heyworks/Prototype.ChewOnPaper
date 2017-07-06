/// <summary>
/// Describe all game room settings
/// </summary>
public class RoomSettings
{
    /// <summary>
    /// Gets or sets maximum count of players in the room.
    /// </summary>
    public int MaxPlayers{get;set;}

    /// <summary>
    /// Gets or sets time for player's turn.
    /// </summary>
    public int TurnTime{get;set;}

    /// <summary>
    /// Gets or sets score bonus for right answer.
    /// </summary>
    public int RightAnswerScore{get;set;}

    /// <summary>
    /// Gets or sets score bonus for last turn. 
    /// </summary>
    public int LastTurnScore { get; set; }
}
