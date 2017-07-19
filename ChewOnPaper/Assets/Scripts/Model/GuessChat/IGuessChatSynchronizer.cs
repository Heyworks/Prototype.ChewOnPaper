using System;

/// <summary>
/// Represents interface for guess chat synchronizer.
/// </summary>
public interface IGuessChatSynchronizer
{
    /// <summary>
    /// Guesses.
    /// </summary>
    void Guess(Guess guess);

    /// <summary>
    /// Occurs when new guess arrived.
    /// </summary>
    event Action<Guess> NewGuessArrived;
}
