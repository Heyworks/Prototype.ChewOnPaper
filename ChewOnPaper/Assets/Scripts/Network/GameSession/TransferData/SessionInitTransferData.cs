/// <summary>
/// Represents data about session init result. 
/// </summary>
public class SessionInitTransferData
{
    /// <summary>
    /// Gets the current player role.
    /// </summary>
    public PlayerRole CurrentPlayerRole { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionInitTransferData"/> class.
    /// </summary>
    /// <param name="currentPlayerRole">The current player role.</param>
    public SessionInitTransferData(PlayerRole currentPlayerRole)
    {
        CurrentPlayerRole = currentPlayerRole;
    }
}
