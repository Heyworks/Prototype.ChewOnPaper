/// <summary>
/// Represents game state machine.
/// </summary>
public class MasterStateMachine
{
    private MasterState currentState;
    private readonly NetworkSessionSynchronizer networkSessionSynchronizer;
    private Game game;

    /// <summary>
    /// Initializes a new instance of the <see cref="MasterStateMachine" /> class.
    /// </summary>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    public MasterStateMachine(NetworkSessionSynchronizer networkSessionSynchronizer, Game game)
    {
        this.networkSessionSynchronizer = networkSessionSynchronizer;
        this.game = game;
    }

    /// <summary>
    /// Starts state machine work.
    /// </summary>
    public void Start()
    {
        CreateStates();
        currentState.Acticate();
    }

    /// <summary>
    /// Switches to state.
    /// </summary>
    /// <param name="nextState">State of the next.</param>
    public void SwitchToState(MasterState nextState)
    {
        currentState.Deactivate();
        if (nextState != null)
        {
            nextState.Acticate();
            currentState = nextState;
        }
    }

    private void CreateStates()
    {
        var initState = new MasterInitState(this, null, networkSessionSynchronizer, game);
        var pendingState = new MasterPendingState(this, networkSessionSynchronizer, game, initState);
        currentState = pendingState;
    }
}
