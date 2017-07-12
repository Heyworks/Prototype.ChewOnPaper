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
    /// <param name="playerIds">The player identifiers.</param>
    /// <returns>Createt game session</returns>
    public GameSession InitializeSession(string[] playerIds)
    {
        var guessedWord = ChooseWord();
        RefreshRoles(playerIds);
        var gameSession = new GameSession(guessedWord, playerRoles);

        return gameSession;
    }

    private void RefreshRoles(string[] playerIds)
    {
        playerRoles.Clear();
        AddGuessers(playerIds);
        AddChewers(playerIds);
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
