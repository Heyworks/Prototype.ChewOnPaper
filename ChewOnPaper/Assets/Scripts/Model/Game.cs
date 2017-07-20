using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
    /// Gets the current session.
    /// </summary>
    public Session CurrentSession
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
        ChangeState(new StateParameters(typeof(LobbyState)));
    }

    /// <summary>
    /// Updates the game data.
    /// </summary>
    /// <param name="gameDto">The game dto.</param>
    public void InitializeGame(GameDTO gameDto)
    {
        UpdateGameData(gameDto.PreviousSessionWinner, gameDto.Players);
    }

    /// <summary>
    /// Starts the new session.
    /// </summary>
    /// <param name="session">The session.</param>
    public void StartNewSession(Session session)
    {
        CurrentSession = session;

        ChangeState(new StateParameters(typeof(StartState)));
    }

    /// <summary>
    /// Starts the chewing.
    /// </summary>
    /// <param name="chewerId">The chewer identifier.</param>
    public void StartChewing(int chewerId)
    {
        if (CurrentSession.CurrentPlayerRole == PlayerRole.Guesser)
        {
            ChangeState(new StateParameters(typeof(GuessState)));
        }
        else if (chewerId == CurrentPlayerId)
        {
            ChangeState(new StateParameters(typeof(ChewState)));
        }
        else
        {
            ChangeState(new StateParameters(typeof(WaitState)));
        }
    }

    /// <summary>
    /// Starts the chewing.
    /// </summary>
    /// <param name="chewerId">The chewer identifier.</param>
    public void FinishChewing(int chewerId)
    {
        // TODO: use polymorphism instead?
        if (CurrentSession.CurrentPlayerRole == PlayerRole.Chewer && chewerId == CurrentPlayerId)
        {
            ((ChewState)CurrentState).Chew();
        }
    }

    /// <summary>
    /// Finishes the session.
    /// </summary>
    /// <param name="gameDto">The game dto.</param>
    public void FinishSession(GameDTO gameDto)
    {
        UpdateGameData(gameDto.PreviousSessionWinner, gameDto.Players);

        ChangeState(new StateParameters(typeof(FinishState)));
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
    /// Processes the session end.
    /// </summary>
    /// <param name="winnerId">The winner identifier.</param>
    /// <param name="lastChewerId">The last chewer identifier.</param>
    // TODO: Move to state class.
    public void ProcessSessionEnd(int winnerId, int lastChewerId)
    {
        GetPlayer(winnerId).AddScore(GameRoomSettings.RightAnswerScore);
        GetPlayer(lastChewerId).AddScore(GameRoomSettings.LastTurnScore);
        PreviousSessionWinner = winnerId;
    }

    /// <summary>
    /// Gets the player.
    /// </summary>
    /// <param name="playerId">The player identifier.</param>
    public Player GetPlayer(int playerId)
    {
        return Players.FirstOrDefault(item => item.Id == playerId);
    }

    private void ChangeState(StateParameters parameters)
    {
        CurrentState = stateFactory.Create(parameters);
        CurrentState.Initialize();

        Debug.Log("Changing state to " + CurrentState.GetType());
    }

    private RoomSettings CreateRoomSettings()
    {
        var currentRoom = PhotonNetwork.room;
        return RoomSettings.ConvertFromPhotonRoom(currentRoom);
    }


   
}
