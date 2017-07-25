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
    private Text chewerBaseScore;
    [SerializeField]
    private Text maxSessionTime;
    [SerializeField]
    private Text roomName;

    /// <summary>
    /// Write settings to view.
    /// </summary>
    public void WriteSettings(RoomSettings settings)
    {
        maxPlayersText.text = settings.MaxPlayers.ToString();
        turnTimeText.text = settings.TurnTime.ToString();
        rightAnswerScoreText.text = settings.RightAnswerScore.ToString();
        chewerBaseScore.text = settings.ChewerBaseScore.ToString();
        maxSessionTime.text = settings.MaxSessionTime.ToString();
        roomName.text = settings.Name;
    }

    /// <summary>
    /// Read settings from view.
    /// </summary>
    /// <returns></returns>
    public RoomSettings ReadSettings()
    {
        var settings = new RoomSettings();
        settings.MaxPlayers = int.Parse(maxPlayersText.text);
        settings.ChewerBaseScore = int.Parse(chewerBaseScore.text);
        settings.Name = roomName.text;
        settings.RightAnswerScore = int.Parse(rightAnswerScoreText.text);
        settings.TurnTime = int.Parse(turnTimeText.text);
        settings.MaxSessionTime = int.Parse(maxSessionTime.text);
        
        return settings;
    }

}
