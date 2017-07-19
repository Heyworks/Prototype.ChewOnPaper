using UnityEngine;

/// <summary>
/// Represents base class for all game states.
/// </summary>
public abstract class MasterState
{
    /// <summary>
    /// Gets a value indicating whether this state is active.
    /// </summary>
    protected bool IsActive { get; private set; }

    /// <summary>
    /// Gets the network session synchronizer.
    /// </summary>
    protected NetworkSessionSynchronizer NetworkSessionSynchronizer { get; private set; }

    /// <summary>
    /// Gets the game.
    /// </summary>
    protected Game Game { get; private set; }

    /// <summary>
    /// Gets the next state.
    /// </summary>
    protected MasterState NextState { get; private set; }

    /// <summary>
    /// Gets the context.
    /// </summary>
    protected MasterStateMachineContext StateMachineContext
    {
        get
        {
            return masterStateMachine.Context;
        }
    }

    /// <summary>
    /// Gets the context behaviour.
    /// </summary>
    protected MonoBehaviour ContextBehaviour
    {
        get
        {
            return NetworkSessionSynchronizer;
        }
    }

    private readonly MasterStateMachine masterStateMachine;

    /// <summary>
    /// Initializes a new instance of the <see cref="MasterState" /> class.
    /// </summary>
    /// <param name="masterStateMachine">The game state machine.</param>
    /// <param name="networkSessionSynchronizer">The network session synchronizer.</param>
    /// <param name="game">The game.</param>
    /// <param name="nextState">State of the next.</param>
    protected MasterState(MasterStateMachine masterStateMachine, NetworkSessionSynchronizer networkSessionSynchronizer, Game game)
    {
        this.masterStateMachine = masterStateMachine;
        NetworkSessionSynchronizer = networkSessionSynchronizer;
        Game = game;
    }

    /// <summary>
    /// Sets the state of the next.
    /// </summary>
    /// <param name="nextState">State of the next.</param>
    public void SetNextState(MasterState nextState)
    {
        NextState = nextState;
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
    public virtual void Deactivate()
    {
        IsActive = false;
    }

    /// <summary>
    /// Switches to state.
    /// </summary>
    /// <param name="nextState">State of the next.</param>
    protected void SwitchToState(MasterState nextState)
    {
        masterStateMachine.SwitchToState(nextState);
    }
}