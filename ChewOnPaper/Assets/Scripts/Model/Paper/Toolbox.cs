using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Represents toolbox for stencils.
/// </summary>
public class Toolbox : MonoBehaviour
{
    [SerializeField]
    private StencilCollection stencilCollection;
    [SerializeField]
    private Vector3 paletteOffset;
    [SerializeField]
    private Vector3 initialPositionInPallete;
    [SerializeField]
    private int numberOfStencilesInPalette = 1;
    [SerializeField]
    private float stencilHeight = 80;
    [SerializeField]
    private Button chewButton;
    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Toggle chewToggle;

    private readonly Queue<Stencil> stencils = new Queue<Stencil>();
    private ChewMode currentMode = ChewMode.Chew;

    /// <summary>
    /// Occurs when chew button has been clicked.
    /// </summary>
    public event Action ChewButtonClicked;

    /// <summary>
    /// Gets the current stencil.
    /// </summary>
    public Stencil CurrentStencil
    {
        get
        {
            return stencils.Peek();
        }
    }

    /// <summary>
    /// Gets the current mode.
    /// </summary>
    /// <value>
    /// The current mode.
    /// </value>
    public ChewMode CurrentMode
    {
        get
        {
            return currentMode;
        }
    }

    /// <summary>
    /// Calls when chews the button has been clicked.
    /// </summary>
    public void ChewButtonClick()
    {
        OnChewButtonClicked();
    }

    /// <summary>
    /// Fills the palette.
    /// </summary>
    public void FillPalette()
    {
        foreach (var stencil in stencils)
        {
            Destroy(stencil.gameObject);
        }
        stencils.Clear();

        for (int i = 0; i < numberOfStencilesInPalette; i++)
        {
            LoadRandomStencilInPalette();
        }

        stencils.Peek().IsActive = true;

        AlignStencils();
    }

    /// <summary>
    /// Generates next stencil.
    /// </summary>
    public void NextStencil()
    {
        stencils.Dequeue();
        LoadRandomStencilInPalette();
        stencils.Peek().IsActive = true;

        AlignStencils();
    }

    /// <summary>
    /// Creates the stencil.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="position">The position.</param>
    /// <param name="rotation">The rotation.</param>
    public Stencil CreateStencil(int id, Vector3 position, float rotation)
    {
        var stencil = stencilCollection.InstantiateStencil(id);
        stencil.transform.localPosition = position;
        stencil.transform.localRotation = Quaternion.Euler(0, 0, rotation);
        return stencil;
    }

    /// <summary>
    /// Hides toolbox.
    /// </summary>
    public void Hide()
    {
        foreach (var stencil in stencils)
        {
            stencil.gameObject.SetActive(false);
        }

        chewButton.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        chewToggle.gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows toolbox.
    /// </summary>
    public void Show()
    {
        foreach (var stencil in stencils)
        {
            stencil.gameObject.SetActive(true);
        }

        chewButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        chewToggle.gameObject.SetActive(true);
    }

    /// <summary>
    /// Changes the chew mode.
    /// </summary>
    public void ChangeChewMode()
    {
        currentMode = (ChewMode)(((int)currentMode + 1) % 2);
    }

    private void OnChewButtonClicked()
    {
        var handler = ChewButtonClicked;
        if (handler != null)
        {
            handler();
        }
    }

    private void LoadRandomStencilInPalette()
    {
        var stencil = stencilCollection.InstantiateRandomStencil();
        stencil.FitHeight(stencilHeight);
        stencils.Enqueue(stencil);
    }

    private void AlignStencils()
    {
        var offset = initialPositionInPallete;
        int siblingIndex = stencils.Count;

        foreach (var stencil in stencils)
        {
            stencil.transform.SetSiblingIndex(--siblingIndex);
            stencil.transform.localPosition = offset;
            offset += paletteOffset;
        }
    }

    #region [Test]

    [ContextMenu("Test_FillPalette")]
    private void Test_FillPalette()
    {
        FillPalette();
    }

    [ContextMenu("Test_NextStencil")]
    private void Test_NextStencil()
    {
        NextStencil();
    }

    #endregion
}
