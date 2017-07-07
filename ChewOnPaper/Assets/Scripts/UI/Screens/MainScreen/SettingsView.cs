using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Room settings view.
/// </summary>
public class SettingsView : MonoBehaviour
{
    [SerializeField]
    private Text maxPlayersText;
    [SerializeField]
    private Text turnTimeText;
    [SerializeField]
    private Text rightAnswerScoreText;
    [SerializeField]
    private Text lastTurnScoreText;
    [SerializeField]
    private Text roomName;

    /// <summary>
    /// Write settings to view.
    /// </summary>
    public void WriteSettings(RoomSettings settings)
    {
        maxPlayersText.text = settings.MaxPlayers.ToString();
    }

    /// <summary>
    /// Read settings from view.
    /// </summary>
    /// <returns></returns>
    public RoomSettings ReadSettings()
    {
        var settings = new RoomSettings();
        settings.MaxPlayers = int.Parse(maxPlayersText.text);
       
        return settings;
    }

}
