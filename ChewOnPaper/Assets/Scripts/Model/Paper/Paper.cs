﻿using System;
using UnityEngine;
using UnityEngine.UI;

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
    /// <param name="chewMode">The chew mode.</param>
    /// <param name="shouldBeSynchronized">if set to <c>true</c> the chew should be synchronized.</param>
    public void Chew(Stencil stencil, ChewMode chewMode, bool shouldBeSynchronized = true)
    {
        var position = stencil.transform.localPosition;
        var rotation = stencil.transform.localRotation.eulerAngles.z;

        stencil.transform.SetParent(transform);

        switch (chewMode)
        {
            case ChewMode.Chew:
                stencil.AnimateChewing();
                break;
            case ChewMode.Refit:
                stencil.AnimateRefit();
                break;
            default:
                throw new ArgumentOutOfRangeException("chewMode", chewMode, null);
        }

        stencil.IsActive = false;
        stencil.enabled = false;

        var args = new ChewEventArgs(stencil.Id, position, rotation, chewMode, shouldBeSynchronized);
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
