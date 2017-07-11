using System;
using UnityEngine;
using Zenject;

/// <summary>
/// Photon implementation of paper synchronizer.
/// </summary>
public sealed class PhotonPaperSynchronizer : Photon.MonoBehaviour
{
    [Inject]
    private Paper paper;
    [Inject]
    private Toolbox toolbox;

    private void Start()
    {
        paper.Chewed += Paper_Chewed;
    }

    [PunRPC]
    private void RPC_NotifyAboutPaperChewed(int stencilId, Vector3 position, float rotation)
    {
        ChewPaper(stencilId, position, rotation);
    }

    private void ChewPaper(int stencilId, Vector3 position, float rotation)
    {
        var stencil = toolbox.CreateStencil(stencilId, position, rotation);
        paper.Chew(stencil, true);
    }
    private void Paper_Chewed(ChewEventArgs args)
    {
        photonView.RPC("RPC_NotifyAboutPaperChewed", PhotonTargets.OthersBuffered, args.StencilId, args.Position, args.Rotation);
    }
}
