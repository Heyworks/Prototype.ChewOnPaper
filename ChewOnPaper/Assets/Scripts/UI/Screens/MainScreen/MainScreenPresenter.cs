/// <summary>
/// Represents presenter of main screen presenter.
/// </summary>
public class MainScreenPresenter
{
    #region [Private fields]

    private readonly IRoomsProvider roomsProvider;
    private readonly MainScreenView view;

    #endregion

    #region [Construction and initialization]

    /// <summary>
    /// Initializes a new instance of the <see cref="MainScreenPresenter"/> class.
    /// </summary>
    /// <param name="view">The view.</param>
    public MainScreenPresenter(MainScreenView view)
    {
        roomsProvider = RoomProvidersFactory.CreateRoomProvider();
        this.view = view;
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
       var exisingRooms = roomsProvider.GetExistingRooms();
        view.ShowAvailableRooms(exisingRooms);
    }

    /// <summary>
    /// Deactivates presenter.
    /// </summary>
    public void Deactivate()
    {
        RemoveEventHandlers();
    }

    #endregion

    #region [Event handlers]

    private void RoomsProvider_ErrorOccured()
    {
        throw new System.NotImplementedException();
    }

    private void RoomsProvider_RoomCreated(RoomData roomData)
    {
        throw new System.NotImplementedException();
    }

    private void RoomsProvider_RoomJoined(RoomData roomData)
    {
        throw new System.NotImplementedException();
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
