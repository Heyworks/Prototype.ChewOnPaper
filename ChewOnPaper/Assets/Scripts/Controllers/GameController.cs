using UnityEngine;

/// <summary>
/// Represents game controller.
/// </summary>
public class GameController : MonoBehaviour
{
    [SerializeField]
    private Toolbox toolbox;
    [SerializeField]
    private Paper paper;

    private void Start()
    {
        toolbox.FillPalette();
    }

    /// <summary>
    /// Chews this instance.
    /// </summary>
    public void Chew()
    {
        paper.Chew(toolbox.CurrentStencil);
        toolbox.NextStencil();
    }
}
