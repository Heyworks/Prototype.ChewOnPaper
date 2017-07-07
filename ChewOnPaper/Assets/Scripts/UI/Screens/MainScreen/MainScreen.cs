using UnityEngine;

/// <summary>
/// Represents main screen for room setup and select.
/// </summary>
public class MainScreen : MonoBehaviour
{
    [SerializeField]
    private MainScreenView view;

    private MainScreenPresenter presenter;

    private void Start()
    {
        presenter = new MainScreenPresenter(view);
        presenter.Activate();
    }

    private void OnDestroy()
    {
        presenter.Deactivate();
    }
}