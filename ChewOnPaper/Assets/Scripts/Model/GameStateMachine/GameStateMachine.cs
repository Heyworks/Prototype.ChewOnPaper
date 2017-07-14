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

    private void CreateStates()
    {
        
    }
}
