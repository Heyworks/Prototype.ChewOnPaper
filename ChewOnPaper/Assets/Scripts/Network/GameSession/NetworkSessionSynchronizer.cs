using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using UnityEngine;

/// <summary>
/// Photon implementation of network session synchronize.
/// </summary>
public class NetworkSessionSynchronizer : Photon.MonoBehaviour
{
    /// <summary>
    /// Occurs when session has been initialized.
    /// </summary>
    public event Action<SessionInitTransferData> SessionInitialized;

    /// <summary>
    /// Occurs when player joined game room.
    /// </summary>
    public event Action PlayerJoined;
    
    private JsonSerializerSettings serializerSettings;

    private void Awake()
    {
        serializerSettings = CreateSerializerSettings();
    }

    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="sessionData">The session.</param>
    public void InitializeSession(InitSessionData sessionData)
    {
        if (PhotonNetwork.isMasterClient)
        {
            SendInitSessionData(sessionData);
        }
    }

    /// <summary>
    /// Initializes the game.
    /// </summary>
    /// <param name="game">The game.</param>
    public void InitializeGame(Game game)
    {
        Debug.Log("InitializeGame");
    }

    private void SendInitSessionData(InitSessionData sessionData)
    {
        var isYourTurn = true;
        string serializedData;
        foreach (var item in sessionData.PlayerRoles)
        {
            if (item.Value == PlayerRole.Guesser)
            {
                serializedData = Serialize(new SessionInitTransferData(PlayerRole.Guesser, sessionData.GuessedWord, false));
            }
            else
            {
                serializedData = Serialize(new SessionInitTransferData(PlayerRole.Chewer, sessionData.GuessedWord, isYourTurn));
                isYourTurn = false;
            }

            photonView.RPC("RPC_NotifySessionInitialized", PhotonPlayer.Find(item.Key), serializedData);
        }
    }

    [PunRPC]
    private void RPC_NotifySessionInitialized(string serializedSession)
    {
        OnSessionCreated(Deserialize(serializedSession));
    }

    private SessionInitTransferData Deserialize(string serializedData)
    {
        return JsonConvert.DeserializeObject(serializedData, typeof(SessionInitTransferData), serializerSettings) as SessionInitTransferData;
    }

    private string Serialize(SessionInitTransferData sessionData)
    {
        return JsonConvert.SerializeObject(sessionData, Formatting.None, serializerSettings);
    }

    private static JsonSerializerSettings CreateSerializerSettings()
    {
        return new JsonSerializerSettings
               {
                   TypeNameHandling = TypeNameHandling.Auto,
                   NullValueHandling = NullValueHandling.Ignore,
                   ContractResolver = new DefaultContractResolver(),
                   ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
               };
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

    private void OnSessionCreated(SessionInitTransferData initSessionData)
    {
        var handler = SessionInitialized;
        if (handler != null) handler(initSessionData);
    }
}