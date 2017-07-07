using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents view for avialable for join rooms.
/// </summary>
public class ExistingRoomsView : MonoBehaviour
{
    private readonly IList<ExistingRoomView> roomViews = new List<ExistingRoomView>();
    
    [SerializeField]
    private Transform contentRoot;
    [SerializeField]
    private ExistingRoomView roomViewPrefab;
    
    /// <summary>
    /// Occurs when join button has been clicked.
    /// </summary>
    public event Action<RoomData> JoinButtonClicked;
    /// <summary>
    /// Shows the rooms.
    /// </summary>
    /// <param name="rooms">The rooms.</param>
    public void ShowRooms(IList<RoomData> rooms)
    {
        ClearView();
        CreateViews(rooms);
    }

    private void CreateViews(IList<RoomData> roomsData)
    {
        foreach (var roomData in roomsData)
        {
            var roomView = Instantiate(roomViewPrefab, contentRoot);
            roomView.Initialize(roomData);
            roomView.JoinButtonClicked += RoomView_JoinButtonClicked;
            roomViews.Add(roomView);
        }
    }

    private void ClearView()
    {
        foreach (var item in roomViews)
        {
            item.JoinButtonClicked -= RoomView_JoinButtonClicked;
            Destroy(item.gameObject);
        }

        roomViews.Clear();
    }

    private void OnJoinButtonClicked(RoomData roomData)
    {
        var handler = JoinButtonClicked;
        if (handler != null) handler(roomData);
    }

    private void RoomView_JoinButtonClicked(RoomData roomData)
    {
        OnJoinButtonClicked(roomData);
    }
}
