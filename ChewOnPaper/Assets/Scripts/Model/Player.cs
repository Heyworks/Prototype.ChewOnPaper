/// <summary>
/// Represents player model presentation.
/// </summary>
public class Player
{
    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets or sets the score.
    /// </summary>
    public int Score { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Player" /> class.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="name">The name.</param>
    /// <param name="score">The score.</param>
    public Player(int id, string name, int score)
    {
        Id = id;
        Name = name;
        Score = score;
    }

    /// <summary>
    /// Updates the score.
    /// </summary>
    /// <param name="additionalScore">The additional score.</param>
    public void AddScore(int additionalScore)
    {
        Score += additionalScore;
    }
}