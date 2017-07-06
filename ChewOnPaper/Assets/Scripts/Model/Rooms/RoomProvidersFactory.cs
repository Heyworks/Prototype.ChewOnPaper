using UnityEngine;

/// <summary>
/// Factory for room providers.
/// </summary>
public static class RoomProvidersFactory
{
    /// <summary>
    /// Creates the room provider.
    /// </summary>
    public static IRoomsProvider CreateRoomProvider()
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