using Zenject;

/// <summary>
/// Base class for all session states.
/// </summary>
public abstract class GameState
{
    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Represents session state factory.
    /// </summary>
    public class GameStateFactory : Factory<StateParameters, GameState>
    {
    }
}
