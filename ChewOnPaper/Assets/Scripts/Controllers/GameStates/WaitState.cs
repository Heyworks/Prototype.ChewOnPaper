/// <summary>
/// Wate session state.
/// </summary>
public class WaitState : GameState
{
    private readonly Toolbox tolbox;
    private readonly ChatView chatView;

    /// <summary>
    /// Initializes a new instance of the <see cref="WaitState" /> class.
    /// </summary>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="chatView">The chat view.</param>
    public WaitState(Toolbox tolbox, ChatView chatView)
    {
        this.tolbox = tolbox;
        this.chatView = chatView;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public override void Initialize()
    {
        tolbox.Hide();
        chatView.SetInteractable(false);
    }
}
