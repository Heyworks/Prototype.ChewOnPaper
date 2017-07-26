using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents session initializer which works on master client.
/// </summary>
public class SessionInitializer
{
    private readonly WordsProvider wordsProvider = new WordsProvider();

    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="game">The game.</param>
    public InitSessionData InitializeSession(Game game)
    {
        var guessedWord = ChooseWord();
        var roles = CreateRoles(game);
        var initSessionData = new InitSessionData(guessedWord, roles);

        return initSessionData;
    }

    private Dictionary<int, PlayerRole> CreateRoles(Game game)
    {
        var playerRoles = new Dictionary<int, PlayerRole>();
        FillChewers(game, playerRoles, 2);
        FillGuessers(game, playerRoles);

        return playerRoles;
    }

    private void FillGuessers(Game game, Dictionary<int, PlayerRole> playerRoles)
    {
        foreach (var player in game.Players)
        {
            if (!playerRoles.ContainsKey(player.Id))
            {
                playerRoles.Add(player.Id, PlayerRole.Guesser);
            }
        }
    }

    private void FillChewers(Game game, Dictionary<int, PlayerRole> playerRoles, int chewersCount)
    {
        var sortedPlayers = game.Players.OrderBy(item => item.Score).ToArray();

        if (game.PreviousSessionWinner.HasValue)
        {
            playerRoles.Add(game.PreviousSessionWinner.Value, PlayerRole.Chewer);
        }

        var index = 0;
        while (playerRoles.Count < chewersCount && index < sortedPlayers.Length)
        {
            var player = sortedPlayers[index];
            if (!playerRoles.ContainsKey(player.Id))
            {
                playerRoles.Add(player.Id, PlayerRole.Chewer);
            }

            index++;
        }
    }

    private string ChooseWord()
    {
        return wordsProvider.GetRandomWord();
    }
}
