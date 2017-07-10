using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Represents rotation controller for stencils.
/// </summary>
public class RotationController: MonoBehaviour, IDragHandler
{
    [SerializeField]
    private GameObject target;

    /// <summary>
    /// When draging is occuring this will be called every time the cursor is moved.
    /// </summary>
    /// <param name="eventData">Current event data.</param>
    public void OnDrag(PointerEventData eventData)
    {
        ExecuteEvents.Execute<IRotationHandler>(target, eventData, (x, y) => x.OnRotate(eventData));
    }
}
