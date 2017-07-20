/// <summary>
/// Chew session state.
/// </summary>
public class ChewState : GameState
{
    private readonly Paper paper;
    private readonly Toolbox tolbox;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChewState"/> class.
    /// </summary>
    /// <param name="paper">The paper.</param>
    /// <param name="tolbox">The tolbox.</param>
    public ChewState(Paper paper, Toolbox tolbox)
    {
        this.paper = paper;
        this.tolbox = tolbox;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public override void Initialize()
    {
        tolbox.gameObject.SetActive(true);
    }

    /// <summary>
    /// Chews this instance.
    /// </summary>
    public void Chew()
    {
        paper.Chew(tolbox.CurrentStencil);
        tolbox.NextStencil();
    }
}
