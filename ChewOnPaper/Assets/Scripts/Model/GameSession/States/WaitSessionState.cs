/// <summary>
/// Wate session state.
/// </summary>
public class WaitSessionState : GameSessionState
{
    private readonly Toolbox tolbox;

    /// <summary>
    /// Initializes a new instance of the <see cref="WaitSessionState"/> class.
    /// </summary>
    /// <param name="tolbox">The tolbox.</param>
    public WaitSessionState(Toolbox tolbox)
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
