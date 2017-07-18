using UnityEngine;
using Zenject;

/// <summary>
/// Represents game controller.
/// </summary>
public class TempGameController : MonoBehaviour
{
    [Inject]
    private Game game;

    /// <summary>
    /// Chews this instance.
    /// </summary>
    public void Chew()
    {
        ((ChewState)game.CurrentState).Chew();
    }
}
