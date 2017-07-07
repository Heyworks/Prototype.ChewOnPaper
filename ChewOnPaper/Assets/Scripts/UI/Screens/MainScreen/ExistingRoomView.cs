using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents available for join room view.
/// </summary>
public class ExistingRoomView : MonoBehaviour
{
    #region [Private fields]

    [SerializeField] private Button button;
    
    private RoomData roomData;
    [SerializeField] private Text roomName;

    #endregion

    #region [Events]

    /// <summary>
    /// Occurs when join button has been clicked.
    /// </summary>
    public event Action<RoomData> JoinButtonClicked;

    #endregion

    #region [Unity events]

    private void Awake()
    {
        button.onClick.AddListener(OnClick);
    }

    #endregion

    #region [Public methods]

    public void Initialize(RoomData roomData)
    {
        this.roomData = roomData;
        roomName.text = roomData.Name;
    }

    #endregion

    #region [Private methods]

    private void OnClick()
    {
        OnJoinButtonClicked(roomData);
    }

    private void OnJoinButtonClicked(RoomData roomData)
    {
        var handler = JoinButtonClicked;
        if (handler != null) handler(roomData);
    }

    #endregion
}