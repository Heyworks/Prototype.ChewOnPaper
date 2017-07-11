using System;
using UnityEngine;

/// <summary>
/// Represents paper class.
/// </summary>
public class Paper : MonoBehaviour
{
    /// <summary>
    /// Occurs when paper was chopped.
    /// </summary>
    public event Action<ChewEventArgs> Chewed;

    /// <summary>
    /// Chews with the specified stencil.
    /// </summary>
    /// <param name="stencil">The stencil.</param>
    /// <param name="silent">if set to <c>true</c> no event will be rised.</param>
    public void Chew(Stencil stencil, bool silent = false)
    {
        var position = stencil.transform.localPosition;
        var rotation = stencil.transform.localRotation.z;

        stencil.transform.SetParent(transform);
        stencil.Animate();
        stencil.IsActive = false;
        stencil.enabled = false;

        if (!silent)
        {
            var args = new ChewEventArgs(stencil.Id, position, rotation);
            OnChewed(args);
        }
    }
    
    private void OnChewed(ChewEventArgs args)
    {
        var handler = Chewed;
        if (handler != null)
        {
            handler(args);
        }
    }
}
