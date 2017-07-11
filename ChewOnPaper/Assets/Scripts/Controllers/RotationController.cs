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
        ExecuteEventRecursively(target, eventData);
    }

    private bool ExecuteEventRecursively(GameObject go, PointerEventData eventData)
    {
        ExecuteEvents.Execute<IRotationHandler>(go, eventData, (x, y) => x.OnRotate(eventData));

        for (int index = 0; index < go.transform.childCount; index++)
        {
            var t = go.transform.GetChild(index);
            ExecuteEventRecursively(t.gameObject, eventData);
        }

        return false;
    }
}
