/// <summary>
/// Represents init state of game state machine.
/// </summary>
public class MasterInitState : MasterState
{
    private readonly SessionInitializer sessionInitializer;

    /// <summary>
    /// Initializes a new instance of the <see cref="MasterInitState" /> class.
    /// </summary>
    /// <param name="masterStateMachine">The game state machine.</param>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    public MasterInitState(MasterStateMachine masterStateMachine, NetworkSessionSynchronizer networkSessionSynchronizer, Game game)
        : base(masterStateMachine, networkSessionSynchronizer, game)
    {
        sessionInitializer = new SessionInitializer();
    }

    /// <summary>
    /// Acticates this state.
    /// </summary>
    public override void Acticate()
    {
        base.Acticate();

        var sessionData = sessionInitializer.InitializeSession(Game);
        NetworkSessionSynchronizer.InitializeSession(sessionData);
        StateMachineContext.SessionData = sessionData;
        SwitchToState(NextState);
    }
}