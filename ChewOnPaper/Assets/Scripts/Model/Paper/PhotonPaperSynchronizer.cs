using System;
using UnityEngine;

/// <summary>
/// Photon implementation of paper synchronizer.
/// </summary>
public sealed class PhotonPaperSynchronizer : Photon.MonoBehaviour, IPaperSynchronizer
{
    /// <summary>
    /// Occurs when paper was chopped.
    /// </summary>
    public event Action<ChewEventArgs> PaperChewed;

    /// <summary>
    /// Notifies all clients about chewing the paper.
    /// </summary>
    /// <param name="stencilId">The stencil identifier.</param>
    /// <param name="position">The position.</param>
    /// <param name="rotation">The rotation.</param>
    public void NotifyAboutPaperChewed(int stencilId, Vector3 position, float rotation)
    {
        photonView.RPC("RPC_NotifyAboutPaperChewed", PhotonTargets.OthersBuffered, stencilId, position, rotation);
    }

    private void RPC_NotifyAboutPaperChewed(int stencilId, Vector3 position, float rotation)
    {
        OnPaperChewed(new ChewEventArgs(stencilId, position, rotation));
    }

    private void OnPaperChewed(ChewEventArgs args)
    {
        var handler = PaperChewed;
        if (handler != null)
        {
            handler(args);
        }
    }
}
