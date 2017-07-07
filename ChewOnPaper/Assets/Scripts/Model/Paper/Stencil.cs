using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents stencil object.
/// </summary>
public class Stencil : MonoBehaviour
{
    private const float chewAnimationTime = 1.0f;

    [SerializeField]
    private int id;

    /// <summary>
    /// Gets the identifier.
    /// </summary>
    public int Id
    {
        get
        {
            return id;
        }
    }

    /// <summary>
    /// Fixes the stencil on the paper.
    /// </summary>
    public void Chew(Vector3 position, float rotation, bool instant)
    {
        transform.localPosition = position;
        transform.localRotation = Quaternion.Euler(0, 0, rotation);

        if (instant)
        {
            GetComponent<Image>().color = Color.black;
        }
        else
        {
            gameObject.ColorTo(Color.black, chewAnimationTime, 0);
        }
    }

    #region Tests

    [ContextMenu("TestChew")]
    private void TestChew()
    {
        Chew(Vector3.zero, 20, false);
    }

    #endregion
}
