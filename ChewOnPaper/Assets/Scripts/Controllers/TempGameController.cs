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

    /// <summary>
    /// Chews this instance.
    /// </summary>
    public void Chew()
    {
        paper.Chew(toolbox.CurrentStencil);
        toolbox.NextStencil();
    }

    private void Start()
    {
        toolbox.FillPalette();
    }
}
