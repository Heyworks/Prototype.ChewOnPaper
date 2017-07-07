using System;
using System.Collections.Generic;
using System.Linq;
using ExitGames.Client.Photon;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Represents rooms provider for photon network.
/// </summary>
public class PhotonRoomsProvider : MonoBehaviour, IRoomsProvider
{
    #region [IRoomsProvider Members]

    /// <summary>
    /// Occurs when error has been occured.
    /// </summary>
    public event Action ErrorOccured;

    /// <summary>
    /// Occurs when room has been created.
    /// </summary>
    public event Action<RoomData> RoomCreated;

    /// <summary>
    /// Occurs when room has been joined.
    /// </summary>
    public event Action<RoomData> RoomJoined;

    /// <summary>
    /// Creates the room.
    /// </summary>
    /// <param name="settings">The settings.</param>
    public void CreateRoom(RoomSettings settings)
    {
        var customOptions = new Hashtable();
        customOptions.Add("LastTurnScore", settings.LastTurnScore);
        customOptions.Add("RightAnswerScore", settings.RightAnswerScore);
        customOptions.Add("TurnTime", settings.TurnTime);
        PhotonNetwork.CreateRoom(settings.Name, new RoomOptions() { MaxPlayers = (byte)settings.MaxPlayers, CustomRoomProperties = customOptions }, null);
    }

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
    /// <param name="roomName">The room name.</param>
    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    #endregion

    #region [Unity events]

    public void Awake()
    {
        // the following line checks if this client was just created (and not yet online). if so, we connect
        if (PhotonNetwork.connectionStateDetailed == ClientState.PeerCreated)
        {
            // Connect to the photon master-server. We use the settings saved in PhotonServerSettings (a .asset file in this project)
            PhotonNetwork.ConnectUsingSettings("0.9");
        }

        // generate a name for this player, if none is assigned yet
        if (String.IsNullOrEmpty(PhotonNetwork.playerName))
        {
            PhotonNetwork.playerName = "Guest" + Random.Range(1, 9999);
        }
    }

    #endregion

    #region [Photon callbacks]

    /// <summary>
    /// Photon connect to master feedback.
    /// </summary>
    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    /// <summary>
    /// Photon create room feedback.
    /// </summary>
    public void OnCreatedRoom()
    {
        OnRoomCreated(ConvertToRoomData(PhotonNetwork.room));
    }

    /// <summary>
    /// Photon Room join feedback.
    /// </summary>
    public void OnJoinedRoom()
    {
        OnRoomJoined(ConvertToRoomData(PhotonNetwork.room));
    }

    /// <summary>
    /// Called when failed to connect to photon.
    /// </summary>
    /// <param name="parameters">The parameters.</param>
    public void OnFailedToConnectToPhoton(object parameters)
    {
        OnErrorOccured();
    }

    /// <summary>
    /// Called when disconnected from photon.
    /// </summary>
    public void OnDisconnectedFromPhoton()
    {
        OnErrorOccured();
    }

    /// <summary>
    /// Called when photon join room failed.
    /// </summary>
    /// <param name="cause">The cause.</param>
    public void OnPhotonJoinRoomFailed(object[] cause)
    {
        OnErrorOccured();
    }

    /// <summary>
    /// Called when photon create room failed.
    /// </summary>
    public void OnPhotonCreateRoomFailed()
    {
        OnErrorOccured();
    }

    #endregion

    #region [Private methods]

    private RoomData ConvertToRoomData(RoomInfo photonData)
    {
        var roomData = new RoomData();
        roomData.Name = photonData.Name;
        roomData.MaxPlayers = photonData.MaxPlayers;
        roomData.PlayerCount = photonData.PlayerCount;

        return roomData;
    }

    private void OnErrorOccured()
    {
        Action handler = ErrorOccured;
        if (handler != null) handler();
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

    #endregion
}