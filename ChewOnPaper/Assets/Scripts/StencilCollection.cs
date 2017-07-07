using System;
using System.Linq;
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
    public Stencil InstantiateStencil(int id)
    {
        var stencil = FindById(id);

        if (stencil == null)
        {
            throw new InvalidOperationException("Can't find stencil with id: " + id);
        }

        return Instantiate(stencil, transform);
    }

    private Stencil FindById(int id)
    {
        return stencils.FirstOrDefault(s => s.Id == id);
    }

    #region Tests

    [ContextMenu("TestInstantiateStencil")]
    private void TestInstantiateStencil()
    {
        InstantiateStencil(0);
    }

    #endregion
}
