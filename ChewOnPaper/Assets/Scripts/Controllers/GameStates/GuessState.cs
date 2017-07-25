/// <summary>
/// Guess session state.
/// </summary>
public class GuessState : GameState
{
    private readonly GuessChat guessChat;
    private readonly Toolbox tolbox;
    private readonly ChatView chatView;
    private readonly HUD hud;
    private readonly Game game;

    /// <summary>
    /// Initializes a new instance of the <see cref="GuessState" /> class.
    /// </summary>
    /// <param name="guessChat">The guess chat.</param>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="chatView">The chat view.</param>
    /// <param name="hud">The hud.</param>
    /// <param name="game">The game.</param>
    public GuessState(GuessChat guessChat, Toolbox tolbox, ChatView chatView, HUD hud, Game game)
    {
        this.tolbox = tolbox;
        this.chatView = chatView;
        this.guessChat = guessChat;
        this.hud = hud;
        this.game = game;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void Initialize()
    {
        tolbox.Hide();
        chatView.SetInteractable(true);
        hud.HideSecretWord();
        var session = game.CurrentSession;
        hud.ShowChewing(game.GetPlayer(session.CurrentChewerId).Name, game.GameRoomSettings.TurnTime, false);
    }

    /// <summary>
    /// Guesses the specified word.
    /// </summary>
    /// <param name="word">The word.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Guess(string word)
    {
        guessChat.Guess(word);
    }
}
