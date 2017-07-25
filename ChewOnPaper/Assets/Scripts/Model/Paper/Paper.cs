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
        var rotation = stencil.transform.localRotation.eulerAngles.z;

        stencil.transform.SetParent(transform);
        stencil.AnimateChewing();
        stencil.IsActive = false;
        stencil.enabled = false;

        var args = new ChewEventArgs(stencil.Id, position, rotation, !silent);
        OnChewed(args);
    }

    /// <summary>
    /// Clears this paper.
    /// </summary>
    public void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var t = transform.GetChild(i);
            Destroy(t.gameObject);
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
