using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Represents stencil object.
/// </summary>
public class Stencil : MonoBehaviour, IDragHandler, IRotationHandler
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
    /// Gets or sets a value indicating whether this instance is active.
    /// </summary>
    public bool IsActive
    {
        get;
        set;
    }

    /// <summary>
    /// Animates chewing the paper.
    /// </summary>
    public void Animate()
    {
        gameObject.ColorTo(Color.black, chewAnimationTime, 0);
    }

    /// <summary>
    /// When draging is occuring this will be called every time the cursor is moved.
    /// </summary>
    /// <param name="eventData">Current event data.</param>
    public void OnDrag(PointerEventData eventData)
    {
        if (!IsActive)
        {
            return;
        }

        transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    /// <summary>
    /// Called when rotating the object.
    /// </summary>
    /// <param name="eventData">The event data.</param>
    public void OnRotate(PointerEventData eventData)
    {
        if (!IsActive)
        {
            return;
        }

        var to = eventData.position - new Vector2(transform.position.x, transform.position.y);
        var from = to - eventData.delta;
        var sign = Mathf.Sign(from.x * to.y - from.y * to.x);
        var rotation = Vector2.Angle(from, to) * sign;
        transform.Rotate(0, 0, rotation);
    }

    #region Tests

    [ContextMenu("Test_Animate")]
    private void Test_Animate()
    {
        Animate();
    }

    #endregion
}
