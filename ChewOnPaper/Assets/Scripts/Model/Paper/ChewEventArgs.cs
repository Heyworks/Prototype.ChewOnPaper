using System;
using UnityEngine;

/// <summary>
/// Chew event args.
/// </summary>
public class ChewEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChewEventArgs" /> class.
    /// </summary>
    /// <param name="stencilId">The stencil identifier.</param>
    /// <param name="position">The position.</param>
    /// <param name="rotation">The rotation.</param>
    /// <param name="chewMode">The chew mode.</param>
    /// <param name="shouldBeSynchronized">Indicating whether chew should be synchronized with other clients.</param>
    public ChewEventArgs(int stencilId, Vector3 position, float rotation, ChewMode chewMode, bool shouldBeSynchronized)
    {
        StencilId = stencilId;
        Position = position;
        Rotation = rotation;
        ChewMode = chewMode;
        ShouldBeSynchronized = shouldBeSynchronized;
    }

    /// <summary>
    /// Gets the stencil identifier.
    /// </summary>
    public int StencilId
    {
        get; private set;
    }

    /// <summary>
    /// Gets the position.
    /// </summary>
    public Vector3 Position
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the rotation.
    /// </summary>
    public float Rotation
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the chew mode.
    /// </summary>
    public ChewMode ChewMode
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets a value indicating whether chew should be synchronized with other clients.
    /// </summary>
    public bool ShouldBeSynchronized
    {
        get;
        private set;
    }
}
