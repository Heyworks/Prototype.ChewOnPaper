using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents collection of stencils.
/// </summary>
public class StencilCollection : MonoBehaviour
{
    [SerializeField]
    private Stencil[] stencils;

    /// <summary>
    /// Instantiates the stencil by id.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="position">The position.</param>
    public Stencil InstantiateStencil(int id, Vector3 position)
    {
        return null;
    }
}
