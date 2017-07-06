using System;
using System.Collections.Generic;
using UnityEngine;

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
    /// <param name="name">The name.</param>
    /// <param name="settings">The settings.</param>
    void CreateRoom(string name, RoomSettings settings);
   
}