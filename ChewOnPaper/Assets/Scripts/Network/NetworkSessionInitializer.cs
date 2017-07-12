using System;
using Zenject;

/// <summary>
/// Photon implementation of network session initializer.
/// </summary>
public class NetworkSessionInitializer : Photon.MonoBehaviour
{
    /// <summary>
    /// Occurs when session has been created.
    /// </summary>
    public event Action<GameSession> SessionCreated;

    [Inject]
    private SessionInitializer sessionInitializer;
    
    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="playerIds">The player identifiers.</param>
    public void InitializeSession(string[] playerIds)
    {
        if (PhotonNetwork.isMasterClient)
        {
            var session = sessionInitializer.InitializeSession(playerIds);
            photonView.RPC("RPC_NotifySessionInitialized", PhotonTargets.OthersBuffered, session);
            OnSessionCreated(session);
        }
    }

    [PunRPC]
    private void RPC_NotifySessionInitialized(GameSession gameSession)
    {
        OnSessionCreated(gameSession);
    }

    private void OnSessionCreated(GameSession gameSession)
    {
        var handler = SessionCreated;
        if (handler != null) handler(gameSession);
    }
}
