using Zenject;

/// <summary>
/// Represents game session.
/// </summary>
public class GameSession
{
    private readonly Factory<SessionStateData, GameSessionState> stateFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameSession"/> class.
    /// </summary>
    /// <param name="stateFactory">The state factory.</param>
    public GameSession(Factory<SessionStateData, GameSessionState> stateFactory)
    {
        this.stateFactory = stateFactory;
    }

    /// <summary>
    /// Gets the state of the current session.
    /// </summary>
    public GameSessionState CurrentState
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
