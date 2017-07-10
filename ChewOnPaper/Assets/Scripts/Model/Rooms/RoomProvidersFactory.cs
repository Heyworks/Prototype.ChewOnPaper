using UnityEngine;
using Zenject;

/// <summary>
/// Factory for room providers.
/// </summary>
public class RoomProvidersFactory : IFactory<IRoomsProvider>
{
    /// <summary>
    /// Creates this instance.
    /// </summary>
    public IRoomsProvider Create()
    {
        return CreatePhotonProvider();
    }

    private static IRoomsProvider CreatePhotonProvider()
    {
        var go = new GameObject().AddComponent<PhotonRoomsProvider>();
        go.name = "PhotonRoomsProvider";

        return go;
    }
}