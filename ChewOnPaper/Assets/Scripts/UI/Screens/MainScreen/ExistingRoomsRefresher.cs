using System.Collections;
using UnityEngine;

/// <summary>
/// Represents existing rooms list refresher.
/// </summary>
public class ExistingRoomsRefresher
{
    private readonly MainScreenView view;
    private readonly IRoomsProvider roomsProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExistingRoomsRefresher"/> class.
    /// </summary>
    /// <param name="view">The view.</param>
    /// <param name="roomsProvider">The rooms provider.</param>
    public ExistingRoomsRefresher(MainScreenView view, IRoomsProvider roomsProvider)
    {
        this.view = view;
        this.roomsProvider = roomsProvider;
    }

    /// <summary>
    /// Starts to refresh.
    /// </summary>
    /// <param name="refreshRate">The delay between updates in seconds.</param>
    public void StartRefresh(float refreshRate)
    {
        var wait = new WaitForSeconds(refreshRate);
        view.StartCoroutine(RefreshCoroutine(wait));
    }
    
    /// <summary>
    /// Stops to refresh.
    /// </summary>
    public void StopRefresh()
    {
        view.StopAllCoroutines();
    }

    private IEnumerator RefreshCoroutine(WaitForSeconds wait)
    {
        while (true)
        {
            var exisingRooms = roomsProvider.GetExistingRooms();
            view.ShowAvailableRooms(exisingRooms);

            yield return wait;
        }
    }
}