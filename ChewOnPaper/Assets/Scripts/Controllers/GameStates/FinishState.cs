/// <summary>
/// Finish session state.
/// </summary>
public class FinishState: GameState
{
    private readonly Toolbox tolbox;
    private readonly ChatView chatView;
    private readonly Game game;
    private readonly LeaderboardView leaderboardView;

    /// <summary>
    /// Initializes a new instance of the <see cref="FinishState" /> class.
    /// </summary>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="chatView">The chat view.</param>
    /// <param name="game">The game.</param>
    /// <param name="leaderboardView">The leaderboard view.</param>
    public FinishState(Toolbox tolbox, ChatView chatView, Game game, LeaderboardView leaderboardView)
    {
        this.tolbox = tolbox;
        this.chatView = chatView;
        this.game = game;
        this.leaderboardView = leaderboardView;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void Initialize()
    {
        tolbox.Hide();
        chatView.SetInteractable(false);
        leaderboardView.UpdateLeaderboard(game.Players);
    }
}
