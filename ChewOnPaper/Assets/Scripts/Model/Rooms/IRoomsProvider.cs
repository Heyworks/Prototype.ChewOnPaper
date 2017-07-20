using System;
using System.Collections.Generic;

/// <summary>
/// Represents information about network rooms.
/// </summary>
public interface IRoomsProvider
{
    /// <summary>
    /// Occurs when room has been created.
    /// </summary>
    event Action<RoomData> RoomCreated;

    /// <summary>
    /// Occurs when room has been joined.
    /// </summary>
    event Action<RoomData> RoomJoined;

    /// <summary>
    /// Occurs when error has been occured.
    /// </summary>
    event Action ErrorOccured;

    /// <summary>
    /// Gets the existing rooms.
    /// </summary>
    IList<RoomData> GetExistingRooms();

    /// <summary>
    /// Joins the room.
    /// </summary>
    /// <param name="name">The name.</param>
    void JoinRoom(string name);

    /// <summary>
    /// Creates the room.
    /// </summary>
    /// <param name="settings">The settings.</param>
    void CreateRoom(RoomSettings settings);

    /// <summary>
    /// Updates the name of the player.
    /// </summary>
    /// <param name="playerName">Name of the player.</param>
    void UpdatePlayerName(string playerName);
}