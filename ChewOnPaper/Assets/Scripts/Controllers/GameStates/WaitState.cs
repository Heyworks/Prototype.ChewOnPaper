/// <summary>
/// Wate session state.
/// </summary>
public class WaitState : GameState
{
    private readonly Toolbox tolbox;

    /// <summary>
    /// Initializes a new instance of the <see cref="WaitState"/> class.
    /// </summary>
    /// <param name="tolbox">The tolbox.</param>
    public WaitState(Toolbox tolbox)
    {
        this.tolbox = tolbox;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public override void Initialize()
    {
        tolbox.gameObject.SetActive(false);
    }
}
