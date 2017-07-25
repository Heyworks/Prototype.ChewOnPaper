using System;
using UnityEngine;
using Zenject;

/// <summary>
/// Photon implementation of network session synchronize.
/// </summary>
public class NetworkSessionSynchronizer : Photon.PunBehaviour
{
    [Inject]
    private GameStateController gameStateController;

    [Inject]
    private HUD hud;

    /// <summary>
    /// Occurs when player joined game room.
    /// </summary>
    public event Action PlayerJoined;

    /// <summary>
    /// Occurs when chew action applied by player before countdown finish.
    /// </summary>
    public event Action ChewForceApplied;

    private void Start()
    {
        hud.ChewButtonClicked += Hud_ChewButtonClicked;
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

    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="sessionData">The session.</param>
    public void InitializeSession(InitSessionData sessionData)
    {
        SendInitSessionData(sessionData);
    }

    /// <summary>
    /// Starts the chewing.
    /// </summary>
    /// <param name="chewerId">Index of the chewer.</param>
    public void StartChewing(int chewerId)
    {
        photonView.RPC("RPC_NotifyStartChewing", PhotonTargets.All, chewerId);
    }

    /// <summary>
    /// Finishes the chewing.
    /// </summary>
    /// <param name="chewerId">The chewer identifier.</param>
    public void FinishChewing(int chewerId)
    {
        photonView.RPC("RPC_NotifyFinishChewing", PhotonTargets.All, chewerId);
    }

    /// <summary>
    /// Finishes the session.
    /// </summary>
    /// <param name="gameDto">The game dto.</param>
    public void FinishSession(GameDTO gameDto)
    {
        var serializedData = JsonSerializer.SerializeGameDto(gameDto);

        photonView.RPC("RPC_NotifyFinishSession", PhotonTargets.All, serializedData);
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
    private void RPC_NotifyGameInitialized(string serializedGame)
    {
        Debug.Log("RPC_NotifyGameInitialized");

        var data = JsonSerializer.DeserializeGameDto(serializedGame);
        gameStateController.InitializeGame(data);

        Debug.Log("PreviousSessionWinner" + data.PreviousSessionWinner);
    }

    [PunRPC]
    private void RPC_NotifySessionInitialized(string serializedSession)
    {
        Debug.Log("RPC_NotifySessionInitialized");

        var sessionData = JsonSerializer.DeserializeSessionInitDto(serializedSession);
        var session = new Session(sessionData.CurrentPlayerRole, sessionData.GuessedWord);
        gameStateController.StartNewSession(session);

        Debug.Log("Word: " + sessionData.GuessedWord);
        Debug.Log("Role: " + sessionData.CurrentPlayerRole);
        Debug.Log("Is you turn: " + sessionData.IsYourTurnFirst);
    }

    [PunRPC]
    private void RPC_NotifyStartChewing(int chewerId)
    {
        Debug.Log("RPC_NotifyStartChewing. Chewer Id: " + chewerId);

        gameStateController.StartChewing(chewerId);
    }

    [PunRPC]
    private void RPC_NotifyFinishChewing(int chewerId)
    {
        Debug.Log("RPC_NotifyFinishChewing. Chewer Id: " + chewerId);

        gameStateController.FinishChewing(chewerId);
    }

    [PunRPC]
    private void RPC_NotifyFinishSession(string serializedGame)
    {
        Debug.Log("RPC_NotifyFinishSession");

        var data = JsonSerializer.DeserializeGameDto(serializedGame);
        gameStateController.FinishSession(data);
    }

    [PunRPC]
    private void RPC_NotifyChewForceApplied()
    {
        Debug.Log("RPC_NotifyChewForceApplied");
        OnChewForceApplied();
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

    private void OnChewForceApplied()
    {
        var handler = ChewForceApplied;
        if (handler != null)
        {
            handler();
        }
    }

    private void Hud_ChewButtonClicked()
    {
        photonView.RPC("RPC_NotifyChewForceApplied", PhotonTargets.MasterClient);
    }
}