using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

/// <summary>
/// Represents presenter of main screen presenter.
/// </summary>
public class MainScreenPresenter
{
    #region [Private fields]
    
    private readonly MainScreenView view;
    private readonly ExistingRoomsRefresher roomsRefresher;
    private readonly IRoomsProvider roomsProvider;
    
    #endregion

    #region [Construction and initialization]

    /// <summary>
    /// Initializes a new instance of the <see cref="MainScreenPresenter" /> class.
    /// </summary>
    /// <param name="view">The view.</param>
    /// <param name="roomsProvider">The rooms provider.</param>
    public MainScreenPresenter(MainScreenView view, IRoomsProvider roomsProvider)
    {
        this.view = view;
        this.roomsProvider = roomsProvider;
        roomsRefresher = new ExistingRoomsRefresher(view, roomsProvider);
        AddPermanentEventHandlers();
    }

    #endregion

    #region [Public methods]

    /// <summary>
    /// Activates presenter.
    /// </summary>
    public void Activate()
    {
        AddEventHandlers();
        roomsRefresher.StartRefresh(2f);
    }

    /// <summary>
    /// Deactivates presenter.
    /// </summary>
    public void Deactivate()
    {
        RemoveEventHandlers();
        roomsRefresher.StopRefresh();
    }

    #endregion

    #region [Event handlers]

    private void RoomsProvider_ErrorOccured()
    {
        Debug.LogError("Rooms provider. Error occured.");
    }

    private void RoomsProvider_RoomCreated(RoomData roomData)
    {
        ShowPaper();
    }

    private void RoomsProvider_RoomJoined(RoomData roomData)
    {
        ShowPaper();
    }

    private void View_CreateRoomButtonClicked(RoomSettings roomSettings)
    {
        CreateRoom(roomSettings);
    }

    private void View_JoinRoomButtonClicked(RoomData roomData)
    {
        roomsProvider.JoinRoom(roomData.Name);
    }

    #endregion

    #region [Private methods]

    private void ShowPaper()
    {
        Deactivate();
        SceneManager.LoadScene("InGame");
    }

    private void AddEventHandlers()
    {
        roomsProvider.RoomCreated += RoomsProvider_RoomCreated;
        roomsProvider.RoomJoined += RoomsProvider_RoomJoined;
        roomsProvider.ErrorOccured += RoomsProvider_ErrorOccured;
    }

    private void AddPermanentEventHandlers()
    {
        view.CreateRoomButtonClicked += View_CreateRoomButtonClicked;
        view.JoinRoomButtonClicked += View_JoinRoomButtonClicked;
    }

    private void CreateRoom(RoomSettings roomSettings)
    {
        if (roomSettings.IsValid)
        {
            roomsProvider.CreateRoom(roomSettings);
        }
    }

    private void RemoveEventHandlers()
    {
        roomsProvider.RoomCreated -= RoomsProvider_RoomCreated;
        roomsProvider.RoomJoined -= RoomsProvider_RoomJoined;
        roomsProvider.ErrorOccured -= RoomsProvider_ErrorOccured;
    }

    #endregion
}
