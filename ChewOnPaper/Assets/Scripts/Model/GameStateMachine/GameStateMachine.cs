﻿/// <summary>
/// Represents game state machine.
/// </summary>
public class GameStateMachine
{
    private GameState currentState;
    private readonly NetworkSessionSynchronizer networkSessionSynchronizer;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameStateMachine" /> class.
    /// </summary>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    public GameStateMachine(NetworkSessionSynchronizer networkSessionSynchronizer)
    {
        this.networkSessionSynchronizer = networkSessionSynchronizer;
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
    public void SwitchToState(GameState nextState)
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
        currentState = new GameInitState(this, null, networkSessionSynchronizer);
    }
}
