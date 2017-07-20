/// <summary>
/// Guess session state.
/// </summary>
public class GuessState : GameState
{
    private readonly GuessChat guessChat;

    /// <summary>
    /// Initializes a new instance of the <see cref="GuessState"/> class.
    /// </summary>
    /// <param name="guessChat">The guess chat.</param>
    public GuessState(GuessChat guessChat)
    {
        this.guessChat = guessChat;
    }

    /// <summary>
    /// Initializes this instance.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void Initialize()
    {
        //throw new System.NotImplementedException();
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
