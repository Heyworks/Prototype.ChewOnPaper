using UnityEngine;
using Zenject;

/// <summary>
/// Represents main screen for room setup and select.
/// </summary>
public class MainScreen : MonoBehaviour
{
    [SerializeField]
    private MainScreenView view;

    [Inject]
    private MainScreenPresenter presenter;

    private void Start()
    {
        presenter.Activate();
    }

    private void OnDestroy()
    {
        presenter.Deactivate();
    }
}