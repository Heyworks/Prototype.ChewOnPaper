using Zenject;

/// <summary>
/// Represents custom game session state factory.
/// </summary>
public class CustomGameStateFactory : IFactory<StateParameters, GameState>
{
    private readonly DiContainer container;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameStateFactory"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public CustomGameStateFactory(DiContainer container)
    {
        this.container = container;
    }

    /// <summary>
    /// Creates game session on the base of session state data.
    /// </summary>
    /// <param name="parameters">The data.</param>
    public GameState Create(StateParameters parameters)
    {
        return container.Instantiate<ChewState>();
    }
}
