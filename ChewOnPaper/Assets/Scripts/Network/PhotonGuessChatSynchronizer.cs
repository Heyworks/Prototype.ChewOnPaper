using System;

/// <summary>
/// Represents photon guess chat synchronizer.
/// </summary>
public class PhotonGuessChatSynchronizer : Photon.MonoBehaviour, IGuessChatSynchronizer
{
    /// <summary>
    /// Occurs when new guess arrived.
    /// </summary>
    public event Action<Guess> NewGuessArrived;

    /// <summary>
    /// Guesses.
    /// </summary>
    /// <param name="guess"></param>
    /// <exception cref="System.NotImplementedException"></exception>
    public void Guess(Guess guess)
    {
        var data = JsonSerializer.SerializeGuess(guess);

        photonView.RPC("RPC_SendGuess", PhotonTargets.OthersBuffered, data);
    }

    [PunRPC]
    private void RPC_SendGuess(string data)
    {
        var guess = JsonSerializer.DeserializeGuess(data);

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
