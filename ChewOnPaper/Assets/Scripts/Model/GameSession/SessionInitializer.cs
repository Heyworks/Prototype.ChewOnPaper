using System.Collections.Generic;

/// <summary>
/// Represents session initializer which works on master client.
/// </summary>
public class SessionInitializer 
{
    /// <summary>
    /// Gets the guessed word.
    /// </summary>
    public string GuessedWord { get; private set; }

    private Dictionary<string, PlayerRole> playerRoles = new Dictionary<string, PlayerRole>(); 

    /// <summary>
    /// Initialize a new session.
    /// </summary>
    /// <param name="playerIds">The player identifiers.</param>
    public void InitializeSession(string[] playerIds)
    {
        GuessedWord = ChooseWord();
        RefreshRoles(playerIds);
    }

    /// <summary>
    /// Processes the new player join.
    /// </summary>
    /// <param name="playerId">The player identifier.</param>
    public void ProcessPlayerJoin(string playerId)
    {
        playerRoles.Add(playerId, PlayerRole.Guesser);
    }

    private void RefreshRoles(string[] playerIds)
    {
        playerRoles.Clear();
        AddGuessers(playerIds);
        AddChewers(playerIds);
    }

    private void AddChewers(string[] playerIds)
    {
        //Temp impl.
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
        //TODO
        return string.Empty;
    }
}
