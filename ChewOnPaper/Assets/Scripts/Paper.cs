using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField]
    private StencilCollection stencils;

    /// <summary>
    /// Chews with the specified stencil.
    /// </summary>
    /// <param name="stencilId">The stencil identifier.</param>
    /// <param name="position">The position.</param>
    /// <param name="rotation">The rotation.</param>
    /// <param name="instant">If chew is instant or with animation.</param>
    public void Chew(int stencilId, Vector3 position, float rotation, bool instant)
    {
        var stencil = stencils.InstantiateStencil(stencilId);
        stencil.Chew(position, rotation, instant);
    }

    #region Tests

    [ContextMenu("TestChew")]
    private void TestChew()
    {
        Chew(0, new Vector3(100, 100, 0), 70, false);
    }

    #endregion
}
