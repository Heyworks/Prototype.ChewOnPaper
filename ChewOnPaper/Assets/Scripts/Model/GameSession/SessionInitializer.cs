using System.Collections.Generic;

/// <summary>
/// Represents session initializer which works on master client.
/// </summary>
public class SessionInitializer
{
    private readonly Dictionary<string, PlayerRole> playerRoles = new Dictionary<string, PlayerRole>();
    private readonly WordsProvider wordsProvider = new WordsProvider();
    
    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="players">The players.</param>
    /// <returns>Createt game session</returns>
    public InitSessionData InitializeSession(IList<Player> players)
    {
        var guessedWord = ChooseWord();
        RefreshRoles(players);
        var gameSession = new InitSessionData(guessedWord, playerRoles);

        return gameSession;
    }

    private void RefreshRoles(IList<Player> players)
    {
        playerRoles.Clear();
        //AddGuessers(playerIds);
        //AddChewers(playerIds);
    }

    private void AddChewers(string[] playerIds)
    {
        //TODO: Temp impl.
        for (int i = 0; i < 2 && i < playerRoles.Count; i++)
        {
            playerRoles[playerIds[i]] = PlayerRole.Guesser;
        }
    }

    private void AddGuessers(string[] playerIds)
    {
        foreach (var playerId in playerIds)
        {
            playerRoles.Add(playerId, PlayerRole.Guesser);
        }
    }

    private string ChooseWord()
    {
        return wordsProvider.GetRandomWord();
    }
}
