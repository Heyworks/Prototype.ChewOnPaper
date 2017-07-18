using Zenject;

/// <summary>
/// Represents game session.
/// </summary>
public class GameSession
{
    private readonly Factory<SessionStateData, GameState> stateFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSession"/> class.
    /// </summary>
    /// <param name="stateFactory">The state factory.</param>
    public GameSession(Factory<SessionStateData, GameState> stateFactory)
    {
        this.stateFactory = stateFactory;
    }

    /// <summary>
    /// Gets the state of the current session.
    /// </summary>
    public GameState CurrentState
    {
        get;
        private set;
    }

    /// <summary>
    /// Changes the state.
    /// </summary>
    public void ChangeState(SessionStateData data)
    {
        CurrentState = stateFactory.Create(data);
        CurrentState.Initialize();
    }

}
