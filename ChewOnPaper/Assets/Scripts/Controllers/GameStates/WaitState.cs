/// <summary>
/// Wate session state.
/// </summary>
public class WaitState : GameState
{
    private readonly Toolbox tolbox;
    private readonly ChatView chatView;
    private readonly HUD hud;
    private readonly Game game;

    /// <summary>
    /// Initializes a new instance of the <see cref="WaitState" /> class.
    /// </summary>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="chatView">The chat view.</param>
    /// <param name="hud">The hud.</param>
    /// <param name="game">The game.</param>
    public WaitState(Toolbox tolbox, ChatView chatView, HUD hud, Game game)
    {
        this.tolbox = tolbox;
        this.chatView = chatView;
        this.hud = hud;
        this.game = game;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public override void Initialize()
    {
        tolbox.Hide();
        chatView.SetInteractable(false);
        var session = game.CurrentSession;
        hud.ShowSecretWord(session.GuessedWord);
        hud.ShowChewing(game.GetPlayer(session.CurrentChewerId).Name, game.GameRoomSettings.TurnTime);
    }
}
