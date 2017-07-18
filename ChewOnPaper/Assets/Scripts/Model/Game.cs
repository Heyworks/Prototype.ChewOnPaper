using System.Collections.Generic;
using Zenject;

/// <summary>
/// Represents Game model presentation.
/// </summary>
//TODO: Move Photon communication to another place.
public class Game
{
    private readonly GameState.GameStateFactory stateFactory;

    /// <summary>
    /// Gets the state of the current session.
    /// </summary>
    public GameState CurrentState
    {
        get;
        private set;
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
    /// Gets the game room settings.
    /// </summary>
    public RoomSettings GameRoomSettings { get; private set; }

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
    public Game(GameState.GameStateFactory stateFactory)
    {
        this.stateFactory = stateFactory;

        Players = new List<Player>();
        GameRoomSettings = CreateRoomSettings();
        ChangeState(new StateParameters(typeof (LobbyState)));
    }

    /// <summary>
    /// Changes the state.
    /// </summary>
    public void ChangeState(StateParameters parameters)
    {
        CurrentState = stateFactory.Create(parameters);
        CurrentState.Initialize();
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
    /// Updates the game data.
    /// </summary>
    /// <param name="gameDto">The game dto.</param>
    public void UpdateGameData(GameDTO gameDto)
    {
        Players = gameDto.Players;
        PreviousSessionWinner = gameDto.PreviousSessionWinner;
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

    private RoomSettings CreateRoomSettings()
    {
        var currentRoom = PhotonNetwork.room;
        return RoomSettings.ConvertFromPhotonRoom(currentRoom);
    }
}
