using System.Collections.Generic;

/// <summary>
/// Represents init state of game state machine.
/// </summary>
public class GameInitState : GameState
{
    private readonly SessionInitializer sessionInitializer;
    private readonly GameState nextState;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameInitState" /> class.
    /// </summary>
    /// <param name="gameStateMachine">The game state machine.</param>
    /// <param name="nextState">State of the next.</param>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    public GameInitState(GameStateMachine gameStateMachine, GameState nextState, NetworkSessionSynchronizer networkSessionSynchronizer, Game game)
        : base(gameStateMachine, networkSessionSynchronizer, game)
    {
        this.nextState = nextState;
        sessionInitializer = new SessionInitializer();
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
        Game.UpdateGameData(null, players);

        var sessionData = sessionInitializer.InitializeSession(Game);
        NetworkSessionSynchronizer.InitializeSession(sessionData);
        SwitchToState(nextState);
    }
}