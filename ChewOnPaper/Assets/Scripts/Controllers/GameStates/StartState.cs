/// <summary>
/// Start session state.
/// </summary>
public class StartState: GameState
{
    private readonly Paper paper;
    private readonly Toolbox tolbox;
    private readonly Game game;
    private readonly HUD hud;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChewState" /> class.
    /// </summary>
    /// <param name="paper">The paper.</param>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="game">The game.</param>
    /// <param name="hud">The hud.</param>
    public StartState(Paper paper, Toolbox tolbox, Game game, HUD hud)
    {
        this.paper = paper;
        this.tolbox = tolbox;
        this.game = game;
        this.hud = hud;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void Initialize()
    {
        tolbox.FillPalette();
        paper.Clear();
        hud.ShowSessionCountdown(game.GameRoomSettings.MaxSessionTime);
    }
}
