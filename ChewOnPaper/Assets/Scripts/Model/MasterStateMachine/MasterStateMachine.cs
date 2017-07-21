/// <summary>
/// Represents game state machine.
/// </summary>
public class MasterStateMachine
{
    private readonly NetworkSessionSynchronizer networkSessionSynchronizer;
    private readonly Game game;
    private MasterState currentState;
    private GuessChat chat;

    /// <summary>
    /// Gets the state machine context.
    /// </summary>
    public MasterStateMachineContext Context { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MasterStateMachine" /> class.
    /// </summary>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    /// <param name="chat">The chat.</param>
    public MasterStateMachine(NetworkSessionSynchronizer networkSessionSynchronizer, Game game, GuessChat chat)
    {
        this.networkSessionSynchronizer = networkSessionSynchronizer;
        this.game = game;
        this.chat = chat;
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
            currentState = nextState;
            nextState.Acticate();
        }
    }

    //TODO: Create states in DI.
    private void CreateStates()
    {
        var initState = new MasterInitState(this, networkSessionSynchronizer, game);
        var chewer0State = new MasterChewingState(0, initState, this, networkSessionSynchronizer, game, chat);
        var chewer1State = new MasterChewingState(1, initState, this, networkSessionSynchronizer, game, chat);
        chewer0State.SetNextState(chewer1State);
        chewer1State.SetNextState(chewer0State);
        initState.SetNextState(chewer0State);
        var pendingState = new MasterPendingState(this, networkSessionSynchronizer, game);
        pendingState.SetNextState(initState);
        currentState = pendingState;
    }
}
