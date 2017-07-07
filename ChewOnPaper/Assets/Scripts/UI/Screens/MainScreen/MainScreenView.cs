using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents main menu view.
/// </summary>
public class MainScreenView : MonoBehaviour
{
    [SerializeField]
    private SettingsView settingsView;
    [SerializeField]
    private Button createRoomButton;
    [SerializeField]
    private ExistingRoomsView existingRoomsView;
    
    /// <summary>
    /// Occurs when Create room button has been clicked.
    /// </summary>
    public event Action<RoomSettings> CreateRoomButtonClicked;

    /// <summary>
    /// Occurs when Join room button has been clicked.
    /// </summary>
    public event Action<RoomData> JoinRoomButtonClicked;

    private void Awake()
    {
        createRoomButton.onClick.AddListener(OnCreateButtonClick);
        existingRoomsView.JoinButtonClicked += ExistingRoomsView_JoinButtonClicked;
    }
    
    private void OnCreateButtonClick()
    {
        var settings = settingsView.ReadSettings();
        OnCreateRoomButtonClicked(settings);
    }

    /// <summary>
    /// Shows the available rooms.
    /// </summary>
    /// <param name="availableRooms">The available rooms.</param>
    public void ShowAvailableRooms(IList<RoomData> availableRooms)
    {
        existingRoomsView.ShowRooms(availableRooms);
    }

    private void OnJoinRoomButtonClicked(RoomData roomData)
    {
        var handler = JoinRoomButtonClicked;
        if (handler != null) handler(roomData);
    }

    private void ExistingRoomsView_JoinButtonClicked(RoomData roomData)
    {
        OnJoinRoomButtonClicked(roomData);
    }
    
    private void OnCreateRoomButtonClicked(RoomSettings roomData)
    {
        var handler = CreateRoomButtonClicked;
        if (handler != null) handler(roomData);
    }
}
