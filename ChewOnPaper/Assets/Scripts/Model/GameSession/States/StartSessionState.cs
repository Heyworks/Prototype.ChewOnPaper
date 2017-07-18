using Zenject;

/// <summary>
/// Start session state.
/// </summary>
public class StartSessionState: GameSessionState
{
    private readonly Paper paper;
    private readonly Toolbox tolbox;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChewSessionState"/> class.
    /// </summary>
    /// <param name="paper">The paper.</param>
    /// <param name="tolbox">The tolbox.</param>
    public StartSessionState(Paper paper, Toolbox tolbox)
    {
        this.paper = paper;
        this.tolbox = tolbox;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void Initialize()
    {
        tolbox.FillPalette();
    }
}
