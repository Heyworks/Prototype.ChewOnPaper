using System;
using UnityEngine;

public interface IPaperSynchronizer
{
    /// <summary>
    /// Notifies all clients about chewing the paper.
    /// </summary>
    /// <param name="stencilId">The stencil identifier.</param>
    /// <param name="position">The position.</param>
    /// <param name="rotation">The rotation.</param>
    void NotifyAboutPaperChewed(int stencilId, Vector3 position, float rotation);
}
