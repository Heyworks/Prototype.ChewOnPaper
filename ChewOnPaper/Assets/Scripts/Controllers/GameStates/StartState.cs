using Zenject;

/// <summary>
/// Start session state.
/// </summary>
public class StartState: GameState
{
    private readonly Paper paper;
    private readonly Toolbox tolbox;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChewState"/> class.
    /// </summary>
    /// <param name="paper">The paper.</param>
    /// <param name="tolbox">The tolbox.</param>
    public StartState(Paper paper, Toolbox tolbox)
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
        paper.Clear();
    }
}
