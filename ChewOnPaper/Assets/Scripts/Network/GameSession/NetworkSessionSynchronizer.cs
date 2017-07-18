using System;

/// <summary>
/// Photon implementation of network session synchronize.
/// </summary>
public class NetworkSessionSynchronizer : Photon.MonoBehaviour
{
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
        photonView.RPC("RPC_NotifyGameInitialized", PhotonTargets.OthersBuffered, serializedData);
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
    }

    [PunRPC]
    private void RPC_NotifyGameInitialized(string serializedGame)
    {
        OnGameDtoReceived(JsonSerializer.DeserializeGameDto(serializedGame));
    }

    /// <summary>
    /// Photon Room join feedback.
    /// </summary>
    private void OnJoinedRoom()
    {
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