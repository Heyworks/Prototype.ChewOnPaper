/// <summary>
/// Represents base class for all game states.
/// </summary>
public abstract class GameState
{
    /// <summary>
    /// Gets a value indicating whether this state is active.
    /// </summary>
    protected bool IsActive { get; private set; }

    /// <summary>
    /// Gets the network session synchronizer.
    /// </summary>
    protected NetworkSessionSynchronizer NetworkSessionSynchronizer { get; private set; }

    private readonly GameStateMachine gameStateMachine;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameState" /> class.
    /// </summary>
    /// <param name="gameStateMachine">The game state machine.</param>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    protected GameState(GameStateMachine gameStateMachine, NetworkSessionSynchronizer networkSessionSynchronizer)
    {
        this.gameStateMachine = gameStateMachine;
        NetworkSessionSynchronizer = networkSessionSynchronizer;
    }

    /// <summary>
    /// Acticates this state.
    /// </summary>
    public virtual void Acticate()
    {
        IsActive = true;
    }

    /// <summary>
    /// Deactivates this State.
    /// </summary>
    public void Deactivate()
    {
        IsActive = false;
    }

    /// <summary>
    /// Switches to state.
    /// </summary>
    /// <param name="nextState">State of the next.</param>
    protected void SwitchToState(GameState nextState)
    {
        gameStateMachine.SwitchToState(nextState);
    }
}