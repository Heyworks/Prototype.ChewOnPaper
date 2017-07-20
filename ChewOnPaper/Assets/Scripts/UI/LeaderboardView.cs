using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

/// <summary>
/// Represents leaderboard view.
/// </summary>
public class LeaderboardView : MonoBehaviour
{
    [Inject]
    private Game game;

    [SerializeField]
    private Text leaderboardText;

    /// <summary>
    /// Updates the leaderboard.
    /// </summary>
    public void UpdateLeaderboard()
    {
        var players = game.Players.OrderByDescending(item => item.Score);

        leaderboardText.text = string.Empty;

        foreach (var player in players)
        {
            leaderboardText.text += string.Format("{0} : {1} \n", player.Name, player.Score);
        }
    }
}
