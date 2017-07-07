using System;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using UnityEngine;

/// <summary>
/// Represents rooms provider for photon network.
/// </summary>
public class PhotonRoomsProvider : MonoBehaviour, IRoomsProvider
{
    public event Action<RoomData> RoomCreated;
    public event Action<RoomData> RoomJoined;

    /// <summary>
    /// Gets the existing rooms.
    /// </summary>
    public IList<RoomData> GetExistingRooms()
    {
        var photonRooms = PhotonNetwork.GetRoomList();
        return photonRooms.Select(ConvertToRoomData).ToList();
    }

    /// <summary>
    /// Joins the room.
    /// </summary>
    /// <param name="name">The name.</param>
    public void JoinRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);
    }

    /// <summary>
    /// Creates the room.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="settings">The settings.</param>
    public void CreateRoom(string name, RoomSettings settings)
    {
        var customOptions = new Hashtable();
        customOptions.Add("LastTurnScore", settings.LastTurnScore);
        customOptions.Add("RightAnswerScore", settings.RightAnswerScore);
        customOptions.Add("TurnTime", settings.TurnTime);
        PhotonNetwork.CreateRoom(name, new RoomOptions() { MaxPlayers = (byte)settings.MaxPlayers, CustomRoomProperties = customOptions }, null);
    }

    /// <summary>
    /// Photon Room join feedback.
    /// </summary>
    public void OnJoinedRoom()
    {
        OnRoomJoined(ConvertToRoomData(PhotonNetwork.room));
    }

    /// <summary>
    /// Photon create room feedback.
    /// </summary>
    public void OnCreatedRoom()
    {
        OnRoomCreated(ConvertToRoomData(PhotonNetwork.room));
    }

    private void OnRoomCreated(RoomData roomData)
    {
        Action<RoomData> handler = RoomCreated;
        if (handler != null) handler(roomData);
    }

    private void OnRoomJoined(RoomData roomData)
    {
        Action<RoomData> handler = RoomJoined;
        if (handler != null) handler(roomData);
    }

    private RoomData ConvertToRoomData(RoomInfo photonData)
    {
        var roomData = new RoomData();
        roomData.Name = photonData.Name;
        roomData.MaxPlayers = photonData.MaxPlayers;
        roomData.PlayerCount = photonData.PlayerCount;

        return roomData;
    }
}