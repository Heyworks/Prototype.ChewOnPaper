/// <summary>
/// Represents game state machine.
/// </summary>
public class GameStateMachine
{
    private GameState currentState;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameStateMachine"/> class.
    /// </summary>
    public GameStateMachine()
    {
        CreateStates();
    }

    /// <summary>
    /// Starts state machine work.
    /// </summary>
    public void Start()
    {
        currentState.Acticate();
    }

    /// <summary>
    /// Switches to state.
    /// </summary>
    /// <param name="nextState">State of the next.</param>
    public void SwitchToState(GameState nextState)
    {
        currentState.Deactivate();
        nextState.Acticate();
        currentState = nextState;
    }

    private void CreateStates()
    {
        
    }
}
