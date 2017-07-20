using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents leaderboard view.
/// </summary>
public class LeaderboardView : MonoBehaviour
{
    [SerializeField]
    private Text leaderboardText;

    /// <summary>
    /// Updates the leaderboard.
    /// </summary>
    /// <param name="players">The players.</param>
    public void UpdateLeaderboard(IList<Player> players)
    {
        //TODO sort outside view?
        var orderedPlayers = players.OrderByDescending(item => item.Score);

        leaderboardText.text = string.Empty;

        foreach (var player in orderedPlayers)
        {
            leaderboardText.text += string.Format("{0} : {1} \n", player.Name, player.Score);
        }
    }
}
