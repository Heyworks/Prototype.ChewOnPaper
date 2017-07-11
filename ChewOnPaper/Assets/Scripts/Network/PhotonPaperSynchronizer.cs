using System;
using UnityEngine;

/// <summary>
/// Photon implementation of paper synchronizer.
/// </summary>
public sealed class PhotonPaperSynchronizer : Photon.MonoBehaviour, IPaperSynchronizer
{
    [SerializeField]
    private Paper paper;
    [SerializeField]
    private Toolbox toolbox;

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
        ChewPaper(stencilId, position, rotation);
    }

    private void ChewPaper(int stencilId, Vector3 position, float rotation)
    {
        var stencil = toolbox.CreateStencil(stencilId, position, rotation);
        paper.Chew(stencil, true);
    }
}
