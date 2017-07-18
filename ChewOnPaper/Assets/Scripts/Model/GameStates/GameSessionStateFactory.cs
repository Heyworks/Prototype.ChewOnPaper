using Zenject;

/// <summary>
/// Represents custom game session state factory.
/// </summary>
public class CustomGameStateFactory : IFactory<SessionStateData, GameState>
{
    private readonly DiContainer container;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSessionStateFactory"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public CustomGameStateFactory(DiContainer container)
    {
        this.container = container;
    }

    /// <summary>
    /// Creates game session on the base of session state data.
    /// </summary>
    /// <param name="data">The data.</param>
    public GameState Create(SessionStateData data)
    {
        return container.Instantiate<ChewState>();
    }
}

/// <summary>
/// Represents session state factory.
/// </summary>
public class GameSessionStateFactory : Factory<SessionStateData, GameState>
{
}

