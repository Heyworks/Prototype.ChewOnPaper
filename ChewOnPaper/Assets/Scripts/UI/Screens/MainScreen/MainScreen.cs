using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents main screen for room setup and select.
/// </summary>
public class MainScreen : MonoBehaviour
{
    [SerializeField]
    private Button test;

    [SerializeField] private SettingsView settingsView;

    private void Start()
    {
        test.onClick.AddListener(OnClick);
        var defSettings = new RoomSettings();
        defSettings.MaxPlayers = 4;
        settingsView.WriteSettings(defSettings);
    }

    private void OnClick()
    {
        var settings = settingsView.ReadSettings();
        Debug.Log("settings.MaxPlayers " + settings.MaxPlayers);
    }
}