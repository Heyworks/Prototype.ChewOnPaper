using UnityEngine;
using Zenject;

/// <summary>
/// Represents game controller.
/// </summary>
public class TempGameController : MonoBehaviour
{
    [Inject]
    private Toolbox toolbox;
    [Inject]
    private Paper paper;
    [Inject]
    private GameSession gameSession;

    /// <summary>
    /// Chews this instance.
    /// </summary>
    public void Chew()
    {
        ((ChewSessionState) gameSession.CurrentState).Chew();
    }
}
