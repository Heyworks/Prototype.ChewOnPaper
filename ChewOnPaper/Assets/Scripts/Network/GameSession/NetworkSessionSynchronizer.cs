using System;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Zenject;

/// <summary>
/// Photon implementation of network session synchronize.
/// </summary>
public class NetworkSessionSynchronizer : Photon.MonoBehaviour
{
    /// <summary>
    /// Occurs when session has been created.
    /// </summary>
    public event Action<InitSessionData> SessionCreated;

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
    /// <param name="sessionData">The session.</param>
    public void InitializeSession(InitSessionData sessionData)
    {
        if (PhotonNetwork.isMasterClient)
        {
            var serializedSession = Serialize(sessionData);
            photonView.RPC("RPC_NotifySessionInitialized", PhotonTargets.OthersBuffered, serializedSession);
            OnSessionCreated(sessionData);
        }
    }



    [PunRPC]
    private void RPC_NotifySessionInitialized(string serializedSession)
    {
        OnSessionCreated(Deserialize(serializedSession));
    }

    private InitSessionData Deserialize(string serializedData)
    {
        return JsonConvert.DeserializeObject(serializedData, typeof (InitSessionData), serializerSettings) as InitSessionData;
    }

    private string Serialize(InitSessionData sessionData)
    {
        return JsonConvert.SerializeObject(sessionData, Formatting.None, serializerSettings);
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

    private void OnSessionCreated(InitSessionData initSessionData)
    {
        var handler = SessionCreated;
        if (handler != null) handler(initSessionData);
    }
}