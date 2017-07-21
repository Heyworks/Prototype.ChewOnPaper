/// <summary>
/// Represents lobby state.
/// </summary>
public class LobbyState : GameState
{
    private readonly HUD hud;
    private readonly Game game;

    /// <summary>
    /// Initializes a new instance of the <see cref="LobbyState"/> class.
    /// </summary>
    /// <param name="game">The game.</param>
    /// <param name="hud">The hud.</param>
    public LobbyState(Game game, HUD hud)
    {
        this.game = game;
        this.hud = hud;
    }

    public override void Initialize()
    {
        var name = game.CurrentPlayerName;
        hud.Initialize(name);
    }
}
