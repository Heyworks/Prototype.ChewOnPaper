/// <summary>
/// Represents game state machine.
/// </summary>
public class MasterStateMachine
{
    private readonly NetworkSessionSynchronizer networkSessionSynchronizer;
    private readonly Game game;
    private MasterState currentState;

    /// <summary>
    /// Gets the state machine context.
    /// </summary>
    public MasterStateMachineContext Context { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MasterStateMachine" /> class.
    /// </summary>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    public MasterStateMachine(NetworkSessionSynchronizer networkSessionSynchronizer, Game game)
    {
        this.networkSessionSynchronizer = networkSessionSynchronizer;
        this.game = game;
        Context = new MasterStateMachineContext();
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
        var initState = new MasterInitState(this, networkSessionSynchronizer, game);
        var chewer0State = new MasterChewingState(0, initState, this, networkSessionSynchronizer, game);
        var chewer1State = new MasterChewingState(1, initState, this, networkSessionSynchronizer, game);
        chewer0State.SetNextState(chewer1State);
        chewer1State.SetNextState(chewer0State);
        initState.SetNextState(chewer0State);
        var pendingState = new MasterPendingState(this, networkSessionSynchronizer, game);
        pendingState.SetNextState(initState);
        currentState = pendingState;
    }
}
