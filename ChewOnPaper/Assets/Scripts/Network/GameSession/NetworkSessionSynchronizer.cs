using System;
using Zenject;

/// <summary>
/// Photon implementation of network session synchronize.
/// </summary>
public class NetworkSessionSynchronizer : Photon.PunBehaviour
{
    [Inject]
    private Game game;

    /// <summary>
    /// Occurs when session has been initialized.
    /// </summary>
    public event Action<SessionInitDTO> SessionInitialized;

    /// <summary>
    /// Occurs when game dto has been received.
    /// </summary>
    public event Action<GameDTO> GameDTOReceived;

    /// <summary>
    /// Occurs when player joined game room.
    /// </summary>
    public event Action PlayerJoined;

    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="sessionData">The session.</param>
    public void InitializeSession(InitSessionData sessionData)
    {
        SendInitSessionData(sessionData);
    }

    /// <summary>
    /// Initializes the game.
    /// </summary>
    /// <param name="gameDto">The game dto.</param>
    public void InitializeGame(GameDTO gameDto)
    {
        var serializedData = JsonSerializer.SerializeGameDto(gameDto);
        photonView.RPC("RPC_NotifyGameInitialized", PhotonTargets.All, serializedData);
    }

    private void SendInitSessionData(InitSessionData sessionData)
    {
        var isYourTurn = true;
        string serializedData;
        foreach (var item in sessionData.PlayerRoles)
        {
            if (item.Value == PlayerRole.Guesser)
            {
                serializedData = JsonSerializer.SerializeSessionInitDto(new SessionInitDTO(PlayerRole.Guesser, sessionData.GuessedWord, false));
            }
            else
            {
                serializedData = JsonSerializer.SerializeSessionInitDto(new SessionInitDTO(PlayerRole.Chewer, sessionData.GuessedWord, isYourTurn));
                isYourTurn = false;
            }

            photonView.RPC("RPC_NotifySessionInitialized", PhotonPlayer.Find(item.Key), serializedData);
        }
    }

    [PunRPC]
    private void RPC_NotifySessionInitialized(string serializedSession)
    {
        OnSessionCreated(JsonSerializer.DeserializeSessionInitDto(serializedSession));

        game.ChangeState(new StateParameters(typeof(ChewState)));
    }

    [PunRPC]
    private void RPC_NotifyGameInitialized(string serializedGame)
    {
        OnGameDtoReceived(JsonSerializer.DeserializeGameDto(serializedGame));

        game.ChangeState(new StateParameters(typeof(StartState)));
    }

    /// <summary>
    /// Called when a remote player entered the room. This PhotonPlayer is already added to the playerlist at this time.
    /// </summary>
    /// <param name="newPlayer"></param>
    /// <remarks>
    /// If your game starts with a certain number of players, this callback can be useful to check the
    /// Room.playerCount and find out if you can start.
    /// </remarks>
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        base.OnPhotonPlayerConnected(newPlayer);
        OnPlayerJoined();
    }

    private void OnPlayerJoined()
    {
        var handler = PlayerJoined;
        if (handler != null)
        {
            handler();
        }
    }

    private void OnGameDtoReceived(GameDTO dto)
    {
        var handler = GameDTOReceived;
        if (handler != null)
        {
            handler(dto);
        }
    }

    private void OnSessionCreated(SessionInitDTO initSessionData)
    {
        var handler = SessionInitialized;
        if (handler != null) handler(initSessionData);
    }
}