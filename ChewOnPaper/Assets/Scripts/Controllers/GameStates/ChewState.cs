/// <summary>
/// Chew session state.
/// </summary>
public class ChewState : GameState
{
    private readonly Paper paper;
    private readonly Toolbox tolbox;
    private readonly ChatView chatView;
    private readonly HUD hud;
    private readonly Game game;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChewState" /> class.
    /// </summary>
    /// <param name="paper">The paper.</param>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="chatView">The chat view.</param>
    /// <param name="hud">The hud.</param>
    /// <param name="game">The game.</param>
    public ChewState(Paper paper, Toolbox tolbox, ChatView chatView, HUD hud, Game game)
    {
        this.paper = paper;
        this.tolbox = tolbox;
        this.chatView = chatView;
        this.hud = hud;
        this.game = game;
        hud.ChewButtonClicked += Hud_ChewButtonClicked;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    public override void Initialize()
    {
        tolbox.Show();
        chatView.SetInteractable(false);
        var session = game.CurrentSession;
        hud.ShowSecretWord(session.GuessedWord);
        hud.ShowChewing(game.GetPlayer(session.CurrentChewerId).Name, game.GameRoomSettings.TurnTime, true);
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
    
    private void Hud_ChewButtonClicked()
    {
        Chew();
    }
}
