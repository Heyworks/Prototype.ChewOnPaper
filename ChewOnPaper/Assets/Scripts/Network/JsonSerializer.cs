using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

/// <summary>
/// Reptesents json serializer.
/// </summary>
/// TODO: a.dezhurko Use instead https://doc.photonengine.com/en/realtime/current/reference/serialization-in-photon
public static class JsonSerializer
{
    private static JsonSerializerSettings serializerSettings;

    static JsonSerializer()
    {
        serializerSettings = CreateSerializerSettings();
    }

    /// <summary>
    /// Serializes Game to json.
    /// </summary>
    /// <param name="gameDTO">The game dto.</param>
    public static string SerializeGameDto(GameDTO gameDTO)
    {
        return JsonConvert.SerializeObject(gameDTO, Formatting.None, serializerSettings);
    }

    /// <summary>
    /// Deserializes the game dto.
    /// </summary>
    /// <param name="json">The json.</param>
    public static GameDTO DeserializeGameDto(string json)
    {
        return JsonConvert.DeserializeObject(json, typeof(GameDTO), serializerSettings) as GameDTO;
    }

    /// <summary>
    /// Deserializes the session initialize dto.
    /// </summary>
    /// <param name="serializedData">The serialized data.</param>
    public static SessionInitDTO DeserializeSessionInitDto(string serializedData)
    {
        return JsonConvert.DeserializeObject(serializedData, typeof(SessionInitDTO), serializerSettings) as SessionInitDTO;
    }

    /// <summary>
    /// Serializes the session initialize dto.
    /// </summary>
    /// <param name="sessionData">The session data.</param>
    public static string SerializeSessionInitDto(SessionInitDTO sessionData)
    {
        return JsonConvert.SerializeObject(sessionData, Formatting.None, serializerSettings);
    }


    /// <summary>
    /// Deserializes the guess.
    /// </summary>
    /// <param name="serializedData">The serialized data.</param>
    public static Guess DeserializeGuess(string serializedData)
    {
        return JsonConvert.DeserializeObject(serializedData, typeof(Guess), serializerSettings) as Guess;
    }

    /// <summary>
    /// Serializes the guess.
    /// </summary>
    /// <param name="guess">The guess.</param>
    public static string SerializeGuess(Guess guess)
    {
        return JsonConvert.SerializeObject(guess, Formatting.None, serializerSettings);
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
}

