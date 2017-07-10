using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    /// Fixes the stencil on the paper.
    /// </summary>
    /// <param name="position">The position of chew.</param>
    /// <param name="rotation">The rotation of chew.</param>
    /// <param name="instant">if set to <c>true</c> no animation is played.</param>
    public void Chew(Vector3 position, float rotation, bool instant)
    {
        transform.localPosition = position;
        transform.localRotation = Quaternion.Euler(0, 0, rotation);

        Chew(instant);
    }

    /// <summary>
    /// Fixes the stencil on the paper.
    /// </summary>
    /// <param name="instant">if set to <c>true</c> no animation is played.</param>
    public void Chew(bool instant)
    {
        if (instant)
        {
            GetComponent<Image>().color = Color.black;
        }
        else
        {
            gameObject.ColorTo(Color.black, chewAnimationTime, 0);
        }
    }

    /// <summary>
    /// When draging is occuring this will be called every time the cursor is moved.
    /// </summary>
    /// <param name="eventData">Current event data.</param>
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += new Vector3(eventData.delta.x, eventData.delta.y);
    }

    /// <summary>
    /// Called when rotating the object.
    /// </summary>
    /// <param name="eventData">The event data.</param>
    public void OnRotate(PointerEventData eventData)
    {
        var to = eventData.position - new Vector2(transform.position.x, transform.position.y);
        var from = to - eventData.delta;
        var sign = Mathf.Sign(from.x * to.y - from.y * to.x);
        var rotation = Vector2.Angle(from, to) * sign;
        transform.Rotate(0, 0, rotation);
    }

    #region Tests

    [ContextMenu("TestChew")]
    private void TestChew()
    {
        Chew(Vector3.zero, 20, false);
    }

    #endregion
}
