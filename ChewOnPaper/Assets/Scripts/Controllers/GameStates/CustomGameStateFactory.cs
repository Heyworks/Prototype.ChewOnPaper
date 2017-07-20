using Zenject;

/// <summary>
/// Represents custom game session state factory.
/// </summary>
public class CustomGameStateFactory : IFactory<StateParameters, GameState>
{
    private readonly DiContainer container;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameState.GameStateFactory"/> class.
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
        if (parameters.StateType == typeof(LobbyState))
        {
            return container.Instantiate<LobbyState>();
        }

        if (parameters.StateType == typeof(StartState))
        {
            return container.Instantiate<StartState>();
        }

        if (parameters.StateType == typeof(GuessState))
        {
            return container.Instantiate<GuessState>();
        }

        if (parameters.StateType == typeof(ChewState))
        {
            return container.Instantiate<ChewState>();
        }

        if (parameters.StateType == typeof(WaitState))
        {
            return container.Instantiate<WaitState>();
        }

        if (parameters.StateType == typeof(FinishState))
        {
            return container.Instantiate<FinishState>();
        }

        return container.Instantiate<LobbyState>();
    }
}
