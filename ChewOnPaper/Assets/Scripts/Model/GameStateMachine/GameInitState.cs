using System.Collections.Generic;

/// <summary>
/// Represents init state of game state machine.
/// </summary>
public class GameInitState : GameState
{
    private readonly SessionInitializer sessionInitializer;
    private Game game;
    private readonly GameState nextState;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameInitState" /> class.
    /// </summary>
    /// <param name="gameStateMachine">The game state machine.</param>
    /// <param name="nextState">State of the next.</param>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    public GameInitState(GameStateMachine gameStateMachine, GameState nextState, NetworkSessionSynchronizer networkSessionSynchronizer)
        : base(gameStateMachine, networkSessionSynchronizer)
    {
        this.nextState = nextState;
        sessionInitializer = new SessionInitializer();
        game = new Game();
    }

    /// <summary>
    /// Acticates this state.
    /// </summary>
    public override void Acticate()
    {
        base.Acticate();

        //TODO Temp impl.
        var players = new List<Player>();
        players.Add(new Player(PhotonNetwork.player.ID, "Test"));
        game.UpdateGameData(null, players);

        var sessionData = sessionInitializer.InitializeSession(game);
        NetworkSessionSynchronizer.InitializeSession(sessionData);
        SwitchToState(nextState);
    }
}