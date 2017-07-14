/// <summary>
/// Represents player model presentation.
/// </summary>
public class Player
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public string Id { get; private set; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the session role.
    /// </summary>
    public PlayerRole Role { get; set; }

    /// <summary>
    /// Gets or sets the score.
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    public Player(string id, string name)
    {
        Id = id;
        Name = name;
    }
}