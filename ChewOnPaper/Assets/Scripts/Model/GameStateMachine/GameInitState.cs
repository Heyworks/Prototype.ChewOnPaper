using Zenject;

/// <summary>
/// Represents init state of game state machine.
/// </summary>
public class GameInitState : GameState
{
    [Inject]
    private SessionInitializer sessionInitializer;

    [Inject]
    private Game game;

    [Inject]
    private NetworkSessionSynchronizer networkSessionSynchronizer;

    private readonly GameState nextState;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameInitState" /> class.
    /// </summary>
    /// <param name="gameStateMachine">The game state machine.</param>
    /// <param name="nextState">State of the next.</param>
    public GameInitState(GameStateMachine gameStateMachine, GameState nextState)
        : base(gameStateMachine)
    {
        this.nextState = nextState;
    }

    /// <summary>
    /// Acticates this state.
    /// </summary>
    public override void Acticate()
    {
        base.Acticate();
        var sessionData = sessionInitializer.InitializeSession(game);
        networkSessionSynchronizer.InitializeSession(sessionData);
        SwitchToState(nextState);
    }
}