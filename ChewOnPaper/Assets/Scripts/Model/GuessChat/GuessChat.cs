using System;
using System.Collections.Generic;

/// <summary>
/// Represents guess chat.
/// </summary>
public class GuessChat
{
    private readonly IGuessChatSynchronizer synchronizer;
    private readonly Queue<Guess> guesses;
    private readonly Game game;

    /// <summary>
    /// Initializes a new instance of the <see cref="GuessChat"/> class.
    /// </summary>
    /// <param name="synchronizer">The synchronizer.</param>
    /// <param name="game">The game.</param>
    public GuessChat(IGuessChatSynchronizer synchronizer, Game game)
    {
        this.synchronizer = synchronizer;
        this.game = game;
        synchronizer.NewGuessArrived += Synchronizer_NewGuessArrived;

        guesses = new Queue<Guess>();
    }

    /// <summary>
    /// Occurs when new guess arrived.
    /// </summary>
    public event Action<Guess> NewGuessArrived;

    /// <summary>
    /// Gets the guesses.
    /// </summary>
    public IEnumerable<Guess> Guesses
    {
        get
        {
            return guesses;
        }
    }

    /// <summary>
    /// Guesses the specified word.
    /// </summary>
    public void Guess(string word)
    {
        var guess = new Guess(word, game.CurrentPlayerId);
        guesses.Enqueue(guess);

        synchronizer.Guess(guess);
    }

    private void Synchronizer_NewGuessArrived(Guess guess)
    {
        guesses.Enqueue(guess);

        OnNewGuessArrived(guess);
    }

    private void OnNewGuessArrived(Guess guess)
    {
        var handler = NewGuessArrived;
        if (handler != null)
        {
            handler(guess);
        }
    }
}
