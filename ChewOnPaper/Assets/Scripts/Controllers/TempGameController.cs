using UnityEngine;
using Zenject;

/// <summary>
/// Represents game controller.
/// </summary>
public class TempGameController : MonoBehaviour
{
    [Inject]
    private GameStateController controller;

    /// <summary>
    /// Chews this instance.
    /// </summary>
    public void Chew()
    {
        controller.GetCurrentState<ChewState>().Chew();
    }
}
