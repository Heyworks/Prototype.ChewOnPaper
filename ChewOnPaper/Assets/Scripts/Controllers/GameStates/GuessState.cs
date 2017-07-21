/// <summary>
/// Guess session state.
/// </summary>
public class GuessState : GameState
{
    private readonly GuessChat guessChat;
    private readonly Toolbox tolbox;
    private readonly ChatView chatView;

    /// <summary>
    /// Initializes a new instance of the <see cref="GuessState" /> class.
    /// </summary>
    /// <param name="guessChat">The guess chat.</param>
    /// <param name="tolbox">The tolbox.</param>
    /// <param name="chatView">The chat view.</param>
    public GuessState(GuessChat guessChat, Toolbox tolbox, ChatView chatView)
    {
        this.tolbox = tolbox;
        this.chatView = chatView;
        this.guessChat = guessChat;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void Initialize()
    {
        tolbox.Hide();
        chatView.SetInteractable(true);
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
