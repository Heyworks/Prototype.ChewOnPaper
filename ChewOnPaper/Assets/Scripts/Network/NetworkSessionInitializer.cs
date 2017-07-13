using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
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

    private JsonSerializerSettings serializerSettings;

    private void Start()
    {
        serializerSettings = CreateSerializerSettings();
    }

    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="playerIds">The player identifiers.</param>
    public void InitializeSession(string[] playerIds)
    {
        if (PhotonNetwork.isMasterClient)
        {
            var session = sessionInitializer.InitializeSession(playerIds);
            var serializedSession = Serialize(session);
            photonView.RPC("RPC_NotifySessionInitialized", PhotonTargets.OthersBuffered, serializedSession);
            OnSessionCreated(session);
        }
    }

    [PunRPC]
    private void RPC_NotifySessionInitialized(string serializedSession)
    {
        OnSessionCreated(Deserialize(serializedSession));
    }

    private GameSession Deserialize(string serializedData)
    {
        return JsonConvert.DeserializeObject(serializedData, typeof (GameSession), serializerSettings) as GameSession;
    }

    private string Serialize(GameSession session)
    {
        return JsonConvert.SerializeObject(session, Formatting.None, serializerSettings);
    }

    private static JsonSerializerSettings CreateSerializerSettings()
    {
        return new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver(),
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
        };
    }

    private void OnSessionCreated(GameSession gameSession)
    {
        var handler = SessionCreated;
        if (handler != null) handler(gameSession);
    }
}