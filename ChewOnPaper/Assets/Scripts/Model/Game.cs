using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents Game model presentation.
/// </summary>
//TODO: Move Photon communication to another place.
public class Game
{
    /// <summary>
    /// Gets the current session.
    /// </summary>
    public Session CurrentSession
    {
        get;
        set;
    }

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
    /// Gets the current player identifier.
    /// </summary>
    public string CurrentPlayerName
    {
        get
        {
            return PhotonNetwork.player.NickName;
        }
    }

    /// <summary>
    /// Gets the game room settings.
    /// </summary>
    public RoomSettings GameRoomSettings { get; private set; }

    /// <summary>
    /// Gets the previous session winner.
    /// </summary>
    public int? PreviousSessionWinner { get; set; }

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
        GameRoomSettings = CreateRoomSettings();
    }

    /// <summary>
    /// Updates the game data.
    /// </summary>
    /// <param name="previousSessionWinner">The previous session winner.</param>
    /// <param name="players">The players.</param>
    public void UpdateGameData(int? previousSessionWinner, List<Player> players)
    {
        Players = players;
        PreviousSessionWinner = previousSessionWinner;
    }

    /// <summary>
    /// Converts to dto.
    /// </summary>
    /// TODO: Move to extension method.
    public GameDTO ConverToDto()
    {
        var dto = new GameDTO();
        dto.Players = Players;
        dto.PreviousSessionWinner = PreviousSessionWinner;

        return dto;
    }
    
    /// <summary>
    /// Gets the player.
    /// </summary>
    /// <param name="playerId">The player identifier.</param>
    public Player GetPlayer(int playerId)
    {
        return Players.FirstOrDefault(item => item.Id == playerId);
    }

    private RoomSettings CreateRoomSettings()
    {
        var currentRoom = PhotonNetwork.room;
        return RoomSettings.ConvertFromPhotonRoom(currentRoom);
    }
}
