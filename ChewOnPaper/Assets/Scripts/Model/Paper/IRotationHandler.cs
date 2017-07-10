using UnityEngine.EventSystems;

/// <summary>
/// Represents interface for objects that handles rotation.
/// </summary>
public interface IRotationHandler: IEventSystemHandler
{
    /// <summary>
    /// Called when rotating the object.
    /// </summary>
    /// <param name="eventData">The event data.</param>
    void OnRotate(PointerEventData eventData);
}
