/// <summary>
/// Chew session state.
/// </summary>
public class ChewState : GameState
{
    private readonly Paper paper;
    private readonly Toolbox tolbox;
    private readonly ChatView chatView;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChewState" /> class.
    /// </summary>
    /// <param name="paper">The paper.</param>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="chatView">The chat view.</param>
    public ChewState(Paper paper, Toolbox tolbox, ChatView chatView)
    {
        this.paper = paper;
        this.tolbox = tolbox;
        this.chatView = chatView;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public override void Initialize()
    {
        tolbox.Show();
        chatView.SetInteractable(false);
    }

    /// <summary>
    /// Chews this instance.
    /// </summary>
    public void Chew()
    {
        var currentStencil = tolbox.CurrentStencil;
        if (currentStencil.IsExtruded)
        {
            paper.Chew(tolbox.CurrentStencil);
            tolbox.NextStencil();
        }
    }
}
