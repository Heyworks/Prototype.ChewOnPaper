using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents stencil object.
/// </summary>
public class Stencil : MonoBehaviour
{
    [SerializeField]
    private int id;

    private Image image;

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

    private void Start()
    {
        image = GetComponent<Image>();
    }

    /// <summary>
    /// Fixes the stencil on the paper.
    /// </summary>
    public void CutPaper()
    {
        //image.color.
    }
}
